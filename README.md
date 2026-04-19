# Dynamic Session Automation

A professional multi-proxy, multi-user agent automation tool built with C# and .NET 8.0 using Microsoft WebView2.

## Features

- **Multi-Proxy Support**: Supports HTTP/HTTPS proxies with authentication.
- **Fingerprint Protection**: Overrides User-Agent, Platform, Hardware Concurrency, WebGL, Canvas, and AudioContext.
- **Security Check**: Mandatory 100% anonymity check via `whoer.net` before navigating to the target URL.
- **Session Management**: Each task runs in an isolated session with its own user data directory.
- **Modern UI**: Professional dark-themed UI with real-time color-coded logging and progress tracking.
- **Concurrent Execution**: Serial execution (one by one) to manage system resources efficiently.

## Prerequisites

- Visual Studio 2022
- .NET 8.0 SDK
- Microsoft Edge WebView2 Runtime

## Installation & Build

1. Clone or download the repository.
2. Open `DynamicSessionAutomation.csproj` in Visual Studio 2022.
3. The project will automatically restore NuGet packages (`Microsoft.Web.WebView2`, `Newtonsoft.Json`).
4. Build the project (Build -> Build Solution).
5. Run the application (F5).

## Creating an Installation Package

To create a professional `.exe` installer for distribution:

1. **Build Standalone**: Double-click `build_dist.bat`. This will generate a self-contained, single-file executable in `bin\Release\net8.0-windows\win-x64\publish\`.
2. **Install Inno Setup**: Download and install [Inno Setup](https://jrsoftware.org/isdl.php).
3. **Compile Installer**:
   - Right-click `installer_script.iss` and select **Compile**.
   - This will generate `DynamicSessionAutomation_Setup.exe` which you can share with others.

## How to Use

1. **Load Proxies**: Enter proxies in `ip:port:username:password` format (one per line) or use the "Load Proxies" button.
2. **Load User Agents**: Enter User Agent strings (one per line) or use the "Load UA" button.
3. **Set Target URL**: Enter the URL you want to automate.
4. **Configure Settings**: Adjust timeout, delay, and toggle headless mode if needed.
5. **Start**: Click "START AUTOMATION".
6. **Monitor**: Watch the live log and progress bar.
7. **Report**: After completion, export the session results to CSV.

## Code Structure

- `Models/`: Data structures for Proxies, Config, and Results.
- `Workers/`: Core logic for Session management and Proxy/UA parsing.
- `Helpers/`: Utility classes for Fingerprinting, Logging, and File operations.
- `Config/`: Application settings.
- `Resources/`: Sample data files.

## Technical Notes

- **WebView2 Handling**: Uses `AddScriptToExecuteOnDocumentCreatedAsync` for early-stage fingerprint injection.
- **Proxy Auth**: Handled via `BasicAuthenticationRequested` event.
- **Cleanup**: Automatically cleans up temporary session folders if enabled.
