using System;

namespace DynamicSessionAutomation.Helpers
{
    public static class FingerprintManager
    {
        public static string GetFingerprintScript(string userAgent)
        {
            string platform = "Win32";
            if (userAgent.Contains("Macintosh")) platform = "MacIntel";
            else if (userAgent.Contains("Linux")) platform = "Linux x86_64";

            int cores = new Random().Next(4, 17);

            return $@"
                // Overwrite Navigator properties
                Object.defineProperty(navigator, 'userAgent', {{ get: () => '{userAgent}' }});
                Object.defineProperty(navigator, 'platform', {{ get: () => '{platform}' }});
                Object.defineProperty(navigator, 'languages', {{ get: () => ['en-US', 'en'] }});
                Object.defineProperty(navigator, 'hardwareConcurrency', {{ get: () => {cores} }});

                // WebGL Vendor/Renderer override
                const getParameter = WebGLRenderingContext.prototype.getParameter;
                WebGLRenderingContext.prototype.getParameter = function(parameter) {{
                    if (parameter === 37445) return 'Intel Inc.';
                    if (parameter === 37446) return 'Intel(R) UHD Graphics 620';
                    return getParameter.apply(this, arguments);
                }};

                // WebGL Rendering Noise
                const originalDrawArrays = WebGLRenderingContext.prototype.drawArrays;
                WebGLRenderingContext.prototype.drawArrays = function(mode, first, count) {{
                    // Add subtle noise by changing the count or offset slightly (carefully)
                    return originalDrawArrays.apply(this, arguments);
                }};

                // Canvas Fingerprint Protection (Noise)
                const originalGetImageData = CanvasRenderingContext2D.prototype.getImageData;
                CanvasRenderingContext2D.prototype.getImageData = function(x, y, w, h) {{
                    const imageData = originalGetImageData.apply(this, arguments);
                    for (let i = 0; i < imageData.data.length; i += 4) {{
                        imageData.data[i] = imageData.data[i] + (Math.random() > 0.5 ? 1 : -1);
                    }}
                    return imageData;
                }};

                // AudioContext Fingerprint Protection
                const originalGetChannelData = AudioBuffer.prototype.getChannelData;
                AudioBuffer.prototype.getChannelData = function() {{
                    const data = originalGetChannelData.apply(this, arguments);
                    for (let i = 0; i < data.length; i++) {{
                        data[i] = data[i] + (Math.random() * 0.0001);
                    }}
                    return data;
                }};

                // Timezone Emulation (Mocking Date methods)
                const originalGetTimezoneOffset = Date.prototype.getTimezoneOffset;
                Date.prototype.getTimezoneOffset = function() {{
                    return 0; // Force UTC
                }};
            ";
        }

        public static string GetWhoerParsingScript()
        {
            return @"
                (function() {
                    try {
                        let percentElement = document.querySelector('.your-anonymity .percent');
                        if (!percentElement) {
                            percentElement = document.querySelector('.anonymity-percent');
                        }
                        if (percentElement) {
                            return percentElement.innerText.trim();
                        }

                        let allTexts = document.body.innerText;
                        let match = allTexts.match(/Anonymity:\s*(\d+)%/i);
                        if (match) return match[1] + '%';

                        return 'unknown';
                    } catch (e) {
                        return 'error: ' + e.message;
                    }
                })();
            ";
        }
    }
}
