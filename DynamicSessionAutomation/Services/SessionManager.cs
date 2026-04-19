using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using DynamicSessionAutomation.Models;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DynamicSessionAutomation.Services
{
    public class AutomationResult
    {
        public string Proxy { get; set; } = "";
        public string UserAgent { get; set; } = "";
        public string Status { get; set; } = "";
        public string Anonymity { get; set; } = "";
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }

    public class SessionManager
    {
        private readonly Logger _logger;
        private readonly string _targetUrl;
        private readonly string _userDataFolder;

        public SessionManager(Logger logger, string targetUrl)
        {
            _logger = logger;
            _targetUrl = targetUrl;
            _userDataFolder = Path.Combine(Path.GetTempPath(), "DynamicSessionAutomation_Sessions");
            if (Directory.Exists(_userDataFolder))
            {
                try { Directory.Delete(_userDataFolder, true); } catch { }
            }
        }

        public async Task<AutomationResult> RunSessionAsync(ProxyInfo proxy, UserAgentInfo ua, Control parent)
        {
            AutomationResult result = new AutomationResult
            {
                Proxy = proxy.ToString(),
                UserAgent = ua.UserAgent
            };

            WebView2 webView = new WebView2();

            // Set window size matching user agent
            webView.Width = ua.Width;
            webView.Height = ua.Height;

            try
            {
                // Must add to parent to ensure handle is created
                if (parent.InvokeRequired)
                {
                    parent.Invoke(new Action(() => parent.Controls.Add(webView)));
                }
                else
                {
                    parent.Controls.Add(webView);
                }
                webView.Visible = false; // Run in background

                _logger.Log($"Starting session for {proxy}", LogLevel.Info);

                string sessionFolder = Path.Combine(_userDataFolder, Guid.NewGuid().ToString());

                // Set up environment with proxy
                var options = new CoreWebView2EnvironmentOptions(
                    additionalBrowserArguments: $"--proxy-server=\"{proxy.IP}:{proxy.Port}\" --user-agent=\"{ua.UserAgent}\"");

                var env = await CoreWebView2Environment.CreateAsync(null, sessionFolder, options);

                await webView.EnsureCoreWebView2Async(env);

                // Handle Proxy Auth
                webView.CoreWebView2.BasicAuthenticationRequested += (s, e) =>
                {
                    e.Response.UserName = proxy.Username;
                    e.Response.Password = proxy.Password;
                };

                // Apply Fingerprint Protection scripts
                await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(@"
                    // Disable WebRTC
                    if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
                        navigator.mediaDevices.getUserMedia = function() {
                            return new Promise((resolve, reject) => reject(new Error('NotAllowedError')));
                        };
                    }

                    // Canvas Fingerprint Protection
                    const originalGetContext = HTMLCanvasElement.prototype.getContext;
                    HTMLCanvasElement.prototype.getContext = function(type) {
                        const context = originalGetContext.apply(this, arguments);
                        if (type === '2d') {
                            const originalGetImageData = context.getImageData;
                            context.getImageData = function() {
                                const imageData = originalGetImageData.apply(this, arguments);
                                // Slightly modify one pixel to break hash-based fingerprinting
                                imageData.data[0] = (imageData.data[0] + 1) % 256;
                                return imageData;
                            };
                        }
                        return context;
                    };

                    // AudioContext Fingerprint Protection
                    const originalGetChannelData = AudioBuffer.prototype.getChannelData;
                    AudioBuffer.prototype.getChannelData = function() {
                        const data = originalGetChannelData.apply(this, arguments);
                        for (let i = 0; i < data.length; i += 100) {
                            data[i] += Math.random() * 0.0001;
                        }
                        return data;
                    };

                    // WebGL Fingerprint Protection
                    const originalGetParameter = WebGLRenderingContext.prototype.getParameter;
                    WebGLRenderingContext.prototype.getParameter = function(parameter) {
                        if (parameter === 37445) return 'Intel Inc.'; // UNMASKED_VENDOR_WEBGL
                        if (parameter === 37446) return 'Intel(R) UHD Graphics 620'; // UNMASKED_RENDERER_WEBGL
                        return originalGetParameter.apply(this, arguments);
                    };
                ");

                // Navigate to Whoer.net
                _logger.Log("Checking anonymity on whoer.net...", LogLevel.Info);
                webView.CoreWebView2.Navigate("https://whoer.net/");

                string anonymity = "0%";
                bool checkPassed = false;

                // Wait for navigation and check anonymity
                int timeout = 30; // 30 seconds
                while (timeout > 0)
                {
                    await Task.Delay(2000);
                    timeout -= 2;

                    string script = @"(function() {
                        var element = document.querySelector('.main-anonymity-num');
                        return element ? element.innerText : '';
                    })()";

                    anonymity = await webView.CoreWebView2.ExecuteScriptAsync(script);
                    anonymity = anonymity.Trim('"').Trim('%').Trim();

                    if (!string.IsNullOrEmpty(anonymity) && anonymity != "null")
                    {
                        _logger.Log($"Anonymity check: {anonymity}%", anonymity == "100" ? LogLevel.Success : LogLevel.Warning);
                        result.Anonymity = anonymity + "%";

                        if (anonymity == "100")
                        {
                            checkPassed = true;
                        }
                        break;
                    }
                }

                if (checkPassed)
                {
                    _logger.Log($"Anonymity confirmed. Navigating to {_targetUrl}", LogLevel.Success);
                    webView.CoreWebView2.Navigate(_targetUrl);
                    result.Status = "Success";
                    await Task.Delay(5000); // Wait a bit on the target page
                }
                else
                {
                    _logger.Log($"Anonymity check failed ({anonymity}%). Skipping target.", LogLevel.Error);
                    result.Status = "Failed (Anonymity < 100%)";
                }
            }
            catch (Exception ex)
            {
                _logger.Log($"Error in session: {ex.Message}", LogLevel.Error);
                result.Status = $"Error: {ex.Message}";
            }
            finally
            {
                webView.Dispose();
            }

            return result;
        }
    }
}
