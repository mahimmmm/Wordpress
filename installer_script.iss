; Inno Setup Script for Dynamic Session Automation
; Use Inno Setup Compiler to compile this script into a Setup.exe

[Setup]
AppName=Dynamic Session Automation
AppVersion=2.0
DefaultDirName={{pf}}\DynamicSessionAutomation
DefaultGroupName=Dynamic Session Automation
UninstallDisplayIcon={{app}}\DynamicSessionAutomation.exe
OutputDir=.
OutputBaseFilename=DynamicSessionAutomation_Setup
Compression=lzma
SolidCompression=yes
ArchitecturesInstallIn64BitMode=x64

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; These files should be in the publish folder after running the build script
Source: "bin\Release\net8.0-windows\win-x64\publish\DynamicSessionAutomation.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\net8.0-windows\win-x64\publish\Config\*"; DestDir: "{app}\Config"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "bin\Release\net8.0-windows\win-x64\publish\Resources\*"; DestDir: "{app}\Resources"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\Dynamic Session Automation"; Filename: "{app}\DynamicSessionAutomation.exe"
Name: "{commondesktop}\Dynamic Session Automation"; Filename: "{app}\DynamicSessionAutomation.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\DynamicSessionAutomation.exe"; Description: "{cm:LaunchProgram,Dynamic Session Automation}"; Flags: nowait postinstall skipifsilent
