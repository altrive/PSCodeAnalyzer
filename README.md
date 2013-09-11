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
1. Download zip file from <https://github.com/altrive/PSCodeAnalyzer/releases> 
2. Unblock zip file and extract it. 
3. Run 'install.bat' file to install modules to PowerShell user module directory(under MyDocument)

2.How to use
--------------------
Open PowerShell ISE and execute following command. 
``` powershell
Import-Module PSCodeAnalyzer.ISEAddin
```

If you want to import module automatically when PowerShell ISE launched.
Execute following command (if you already created profile file, need to append line manually)

``` powershell
if(!Test-Path $profile.CurrentUserCurrentHost){
	"Import-Module PSCodeAnalyzer.ISEAddin" > $profile.CurrentUserCurrentHost
}
```

3.Keybord shortcut
--------------------
Following keybord shortcut is supported
- Format Document : Ctrl+K, Ctrl+D
- Format Selection: Ctrl+L, Ctrl+F (Currently not implemented. instead entire document is formatted)


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
