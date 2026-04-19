using System;

namespace DynamicSessionAutomation.Helpers
{
    public static class FingerprintManager
    {
        public static string GetFingerprintScript(string userAgent, string timezone = "UTC")
        {
            string platform = "Win32";
            if (userAgent.Contains("Macintosh")) platform = "MacIntel";
            else if (userAgent.Contains("Linux")) platform = "Linux x86_64";

            int cores = new Random().Next(4, 17);

            // Random MAC-like ID
            string macId = Guid.NewGuid().ToString("N").Substring(0, 12);

            return $@"
                // Overwrite Navigator properties
                Object.defineProperty(navigator, 'userAgent', {{ get: () => '{userAgent}' }});
                Object.defineProperty(navigator, 'platform', {{ get: () => '{platform}' }});
                Object.defineProperty(navigator, 'languages', {{ get: () => ['en-US', 'en'] }});
                Object.defineProperty(navigator, 'hardwareConcurrency', {{ get: () => {cores} }});

                // Mock MAC / Hardware ID
                (function() {{
                    const originalGetContext = HTMLCanvasElement.prototype.getContext;
                    HTMLCanvasElement.prototype.getContext = function(type, attributes) {{
                        const context = originalGetContext.apply(this, arguments);
                        if (type === 'webgl' || type === 'experimental-webgl' || type === 'webgl2') {{
                            // WebGL Vendor override
                            const getParameter = context.getParameter;
                            context.getParameter = function(parameter) {{
                                if (parameter === 37445) return 'Intel Inc.';
                                if (parameter === 37446) return 'Intel(R) UHD Graphics 620';
                                return getParameter.apply(this, arguments);
                            }};
                        }}
                        return context;
                    }};
                }})();

                // Canvas Fingerprint Protection (Noise)
                const originalGetImageData = CanvasRenderingContext2D.prototype.getImageData;
                CanvasRenderingContext2D.prototype.getImageData = function(x, y, w, h) {{
                    const imageData = originalGetImageData.apply(this, arguments);
                    for (let i = 0; i < imageData.data.length; i += 4) {{
                        imageData.data[i] = imageData.data[i] + (Math.random() > 0.5 ? 1 : -1);
                    }}
                    return imageData;
                }};

                // Timezone Emulation
                try {{
                    const IntlOriginal = Intl.DateTimeFormat().resolvedOptions().timeZone;
                    Intl.DateTimeFormat.prototype.resolvedOptions = (function() {{
                        const original = Intl.DateTimeFormat.prototype.resolvedOptions;
                        return function() {{
                            const options = original.apply(this, arguments);
                            options.timeZone = '{timezone}';
                            return options;
                        }};
                    }})();
                }} catch(e) {{}}

                // Override Date to match timezone
                // (Note: full Date override is complex, this handles basic JS timezone checks)
                Date.prototype.getTimezoneOffset = function() {{
                    // Simple offset logic could be added here if needed
                    return 0;
                }};
            ";
        }

        public static string GetWhoerParsingScript()
        {
            return @"
                (function() {
                    try {
                        let percentElement = document.querySelector('.your-anonymity .percent');
                        if (!percentElement) percentElement = document.querySelector('.anonymity-percent');
                        if (percentElement) return percentElement.innerText.trim();

                        let allTexts = document.body.innerText;
                        let match = allTexts.match(/Anonymity:\s*(\d+)%/i);
                        if (match) return match[1] + '%';

                        return 'unknown';
                    } catch (e) {
                        return 'error';
                    }
                })();
            ";
        }
    }
}
