@echo off
echo Removing Mark of the Web (Zone.Identifier) from all project files...
powershell -NoProfile -ExecutionPolicy Bypass -Command "Get-ChildItem -LiteralPath '%~dp0' -Recurse | Unblock-File"
echo Done! You can now Rebuild the solution in Visual Studio.
pause
