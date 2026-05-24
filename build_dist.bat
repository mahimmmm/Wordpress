@echo off
echo Building Dynamic Session Automation...
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:PublishReadyToRun=true /p:IncludeNativeLibrariesForSelfExtract=true
echo.
echo Build Complete!
echo Files are located in: bin\Release\net8.0-windows\win-x64\publish\
pause
