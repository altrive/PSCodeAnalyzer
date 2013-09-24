PSCodeAnalyzer
==============
PowerShell code analysis module.

Currently implemented following features
- PowerShell code formatter ISE addon

Supported environment is following
- Windows 8 / Windows 8.1
- PowerShell 3.0 / PowerShell 4.0

1.How to install
---------------
1. Open PowerShell ISE
2. Execute following command, it automatically download installer zip file and extract to PSModule directory.If you want to import module automatically when ISE started. select yes in prompt.

``` powershell
(New-Object Net.WebClient).DownloadString("https://github.com/altrive/PSCodeAnalyzer/releases/download/v0.3-beta/Install.ps1") | Invoke-Expression -Verbose
```

2.How to use
--------------------
Open PowerShell ISE and execute following command to load module.
``` powershell
Import-Module PSCodeAnalyzer.ISEAddin
```

Following keybord shortcut is supported
- Format Document : Ctrl+K, Ctrl+D
- Format Selection: Ctrl+K, Ctrl+F (Currently not implemented. instead entire document is formatted)


4.Code formating result verification
-------------------
Formatted result is verified by lexical token level,and compared to *before format* token sequence. 
If token sequence is not matched. ISE editor text is not changed (reverted to before format text).
Currently tested over 1000 PowerShell repository(about 70MB .ps1/.psm1) in GitHub and test passed.

*Note: Thought formatted result is verified, it may break existing code after formatting. please backup important files before execute code format*
When code formatting error occured, error line information displayed in ISE console pane. Please report error message.


5.TODO List
---------------
- [x] Basic code formating integration for PowerShell ISE
- [ ] Support various code formatter options
- [ ] Support partial range formatting
- [ ] GUI option settings page
- [ ] VS code formatter integration
