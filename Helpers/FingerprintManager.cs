using System;

namespace DynamicSessionAutomation.Helpers
{
    public static class FingerprintManager
    {
        public static string GetFingerprintScript(string userAgent, string timezone = "UTC", string macAddress = "")
        {
            string platform = "Win32";
            if (userAgent.Contains("Macintosh")) platform = "MacIntel";
            else if (userAgent.Contains("Linux")) platform = "Linux x86_64";

            int cores = new Random().Next(4, 17);

            // Use the provided MAC address or generate a unique Hardware/MAC-like ID for this profile
            string profileHardwareId = !string.IsNullOrEmpty(macAddress) ? macAddress.Replace(":", "") : Guid.NewGuid().ToString("N");
            string deviceId1 = Guid.NewGuid().ToString("N");
            string deviceId2 = Guid.NewGuid().ToString("N");

            return $@"
                // 1. Basic Navigator Overrides
                Object.defineProperty(navigator, 'userAgent', {{ get: () => '{userAgent}' }});
                Object.defineProperty(navigator, 'platform', {{ get: () => '{platform}' }});
                Object.defineProperty(navigator, 'languages', {{ get: () => ['en-US', 'en'] }});
                Object.defineProperty(navigator, 'hardwareConcurrency', {{ get: () => {cores} }});

                // 2. Hardware / MAC ID Spoofing (Mocking Media Devices)
                // Browsers don't expose the actual MAC address to JS for security,
                // but they expose unique Device IDs that can be tracked.
                if (navigator.mediaDevices && navigator.mediaDevices.enumerateDevices) {{
                    const originalEnumerateDevices = navigator.mediaDevices.enumerateDevices.bind(navigator.mediaDevices);
                    navigator.mediaDevices.enumerateDevices = async () => {{
                        const devices = await originalEnumerateDevices();
                        return devices.map((device, index) => {{
                            // Replace hardware IDs with our profile-specific unique IDs
                            const mockId = index === 0 ? '{deviceId1}' : '{deviceId2}_' + index;
                            return {{
                                deviceId: mockId,
                                kind: device.kind,
                                label: device.label,
                                groupId: '{profileHardwareId}'
                            }};
                        }});
                    }};
                }}

                // 3. WebGL Vendor & Renderer Overrides
                (function() {{
                    const originalGetContext = HTMLCanvasElement.prototype.getContext;
                    HTMLCanvasElement.prototype.getContext = function(type, attributes) {{
                        const context = originalGetContext.apply(this, arguments);
                        if (context && (type === 'webgl' || type === 'experimental-webgl' || type === 'webgl2')) {{
                            const getParameter = context.getParameter;
                            context.getParameter = function(parameter) {{
                                // UNMASKED_VENDOR_WEBGL
                                if (parameter === 37445) return 'Intel Inc.';
                                // UNMASKED_RENDERER_WEBGL
                                if (parameter === 37446) return 'Intel(R) UHD Graphics 620';
                                return getParameter.apply(this, arguments);
                            }};
                        }}
                        return context;
                    }};
                }})();

                // 4. Canvas Fingerprint Protection (Subtle Noise)
                const originalGetImageData = CanvasRenderingContext2D.prototype.getImageData;
                CanvasRenderingContext2D.prototype.getImageData = function(x, y, w, h) {{
                    const imageData = originalGetImageData.apply(this, arguments);
                    for (let i = 0; i < imageData.data.length; i += 4) {{
                        // Add persistent but unique noise for this profile
                        imageData.data[i] = imageData.data[i] + (Math.random() > 0.5 ? 1 : -1);
                    }}
                    return imageData;
                }};

                // 5. Timezone Emulation
                try {{
                    Intl.DateTimeFormat.prototype.resolvedOptions = (function() {{
                        const original = Intl.DateTimeFormat.prototype.resolvedOptions;
                        return function() {{
                            const options = original.apply(this, arguments);
                            options.timeZone = '{timezone}';
                            return options;
                        }};
                    }})();
                }} catch(e) {{}}

                // Force constant Date offset
                Date.prototype.getTimezoneOffset = function() {{ return 0; }};
            ";
        }

        public static string GetWhoerParsingScript()
        {
            return @"
                (function() {
                    try {{
                        let percentElement = document.querySelector('.your-anonymity .percent') || document.querySelector('.anonymity-percent');
                        if (percentElement) return percentElement.innerText.trim();
                        let match = document.body.innerText.match(/Anonymity:\s*(\d+)%/i);
                        return match ? match[1] + '%' : 'unknown';
                    }} catch (e) { return 'error'; }
                })();
            ";
        }
    }
}
