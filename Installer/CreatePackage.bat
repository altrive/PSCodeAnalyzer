@echo off
cd /D "%~dp0"

powershell.exe -ExecutionPolicy RemoteSigned -Sta -NoLogo -File CreatePackage.ps1

::start powershell_ise.exe
pause