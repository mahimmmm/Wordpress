using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using DynamicSessionAutomation.Models;
using DynamicSessionAutomation.Helpers;

namespace DynamicSessionAutomation.Workers
{
    public class SessionWorker : IDisposable
    {
        private readonly SessionConfig _config;
        private WebView2? _webView;
        private Form? _browserForm;
        private readonly CancellationToken _cancellationToken;
        private bool _isDisposed = false;

        public SessionWorker(SessionConfig config, CancellationToken ct)
        {
            _config = config;
            _cancellationToken = ct;
        }

        public async Task<AutomationResult> RunAsync()
        {
            var stopwatch = Stopwatch.StartNew();
            var result = new AutomationResult
            {
                Proxy = _config.Proxy?.ToString() ?? "None",
                UserAgent = _config.UserAgent
            };

            try
            {
                await RunInternalAsync(result);
            }
            catch (OperationCanceledException)
            {
                result.Success = false;
                result.Status = "Cancelled";
                result.ErrorMessage = "Task was cancelled by user.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = "Error";
                result.ErrorMessage = ex.Message;
                Logger.Log($"Session Error: {ex.Message}", LogType.Error);
            }
            finally
            {
                stopwatch.Stop();
                result.Duration = stopwatch.Elapsed;
                Cleanup();
            }

            return result;
        }

        private async Task RunInternalAsync(AutomationResult result)
        {
            var tcsInit = new TaskCompletionSource<bool>();

            Application.OpenForms[0]?.Invoke(new Action(async () =>
            {
                try
                {
                    _browserForm = new Form
                    {
                        Text = $"Automation Session - {_config.Proxy?.Ip}",
                        Size = WindowSizeDetector.GetSizeFromUA(_config.UserAgent),
                        StartPosition = FormStartPosition.Manual
                    };

                    var rand = new Random();
                    _browserForm.Location = new Point(rand.Next(0, 400), rand.Next(0, 300));

                    _webView = new WebView2 { Dock = DockStyle.Fill };
                    _browserForm.Controls.Add(_webView);

                    if (!_config.HeadlessMode)
                    {
                        _browserForm.Show();
                    }

                    var options = new CoreWebView2EnvironmentOptions();
                    if (_config.Proxy != null)
                    {
                        options.AdditionalBrowserArguments = $"--proxy-server=\"{_config.Proxy.Ip}:{_config.Proxy.Port}\" --disable-webrtc";
                    }

                    var env = await CoreWebView2Environment.CreateAsync(null, _config.UserDataDir, options);
                    await _webView.EnsureCoreWebView2Async(env);

                    if (_config.Proxy != null && !string.IsNullOrEmpty(_config.Proxy.Username))
                    {
                        _webView.CoreWebView2.BasicAuthenticationRequested += (s, e) =>
                        {
                            e.Response.UserName = _config.Proxy.Username;
                            e.Response.Password = _config.Proxy.Password;
                        };
                    }

                    string fpScript = FingerprintManager.GetFingerprintScript(_config.UserAgent);
                    await _webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(fpScript);

                    Logger.Log("Checking IP security on whoer.net...", LogType.Info);
                    _webView.CoreWebView2.Navigate("https://whoer.net");

                    tcsInit.SetResult(true);
                }
                catch (Exception ex)
                {
                    tcsInit.TrySetException(ex);
                }
            }));

            await tcsInit.Task;

            using var ctsCheck = CancellationTokenSource.CreateLinkedTokenSource(_cancellationToken);
            ctsCheck.CancelAfter(TimeSpan.FromSeconds(_config.TimeoutSeconds));

            try
            {
                await CheckAnonymityAsync(result, ctsCheck.Token);
            }
            catch (OperationCanceledException)
            {
                if (!_cancellationToken.IsCancellationRequested)
                {
                    result.Success = false;
                    result.Status = "Timeout";
                    result.ErrorMessage = "Whoer.net timeout.";
                    Logger.Log("whoer.net timed out.", LogType.Warning);
                }
                else
                {
                    throw;
                }
            }

            if (!result.Success) return;

            Logger.Log($"Anonymity: {result.Anonymity} - SECURE. Opening target URL...", LogType.Success);

            var targetTcs = new TaskCompletionSource<bool>();
            _webView!.Invoke(new Action(() => {
                if (!_isDisposed)
                {
                    _webView.CoreWebView2.Navigate(_config.TargetUrl);
                    targetTcs.SetResult(true);
                }
                else
                {
                    targetTcs.SetException(new ObjectDisposedException("WebView2"));
                }
            }));
            await targetTcs.Task;

            await Task.Delay(TimeSpan.FromSeconds(5), _cancellationToken);

            result.Success = true;
            result.Status = "Completed";
        }

        private async Task CheckAnonymityAsync(AutomationResult result, CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                await Task.Delay(2000, ct);

                if (_isDisposed) return;

                var evalTcs = new TaskCompletionSource<string>();

                _webView!.Invoke(new Action(async () =>
                {
                    try
                    {
                        if (_isDisposed) { evalTcs.TrySetResult("disposed"); return; }
                        string script = FingerprintManager.GetWhoerParsingScript();
                        var res = await _webView.CoreWebView2.ExecuteScriptAsync(script);
                        evalTcs.TrySetResult(res.Trim('"'));
                    }
                    catch { evalTcs.TrySetResult("error"); }
                }));

                string anonymity = await evalTcs.Task;

                if (anonymity != null && anonymity.Contains("%"))
                {
                    result.Anonymity = anonymity;
                    if (anonymity == "100%")
                    {
                        result.Success = true;
                        return;
                    }
                    else if (anonymity != "unknown" && !anonymity.StartsWith("error"))
                    {
                        result.Success = false;
                        result.Status = "Insecure";
                        result.ErrorMessage = $"Anonymity only {anonymity}";
                        Logger.Log($"Insecure IP: {anonymity}. Skipping...", LogType.Error);
                        return;
                    }
                }
            }
        }

        private void Cleanup()
        {
            if (_isDisposed) return;
            _isDisposed = true;

            try
            {
                _browserForm?.Invoke(new Action(() =>
                {
                    _webView?.Dispose();
                    _browserForm?.Close();
                    _browserForm?.Dispose();
                }));
            }
            catch { }
        }

        public void Dispose()
        {
            Cleanup();
        }
    }
}
