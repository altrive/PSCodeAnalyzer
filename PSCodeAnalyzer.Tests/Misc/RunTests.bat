@echo off
cd /D "%~dp0"

PATH=%PATH%;"%ProgramFiles(x86)%\Microsoft Visual Studio 12.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow"
VSTest.Console.exe ..\bin\Debug\PSCodeAnalyzer.Tests.dll /logger:trx

pause