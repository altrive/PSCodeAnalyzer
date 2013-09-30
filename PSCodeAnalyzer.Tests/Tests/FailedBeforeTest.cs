using System;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PSCodeAnalyzer.Tests
{


    [TestClass]
    public class FailedBeforeTest
    {
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void Init()
        {
            //Execution time is included in first test case?
            Context.Initialize();
            EditorImports.Initialize();
        }


        [TestMethod]
        public void NewObject_Parameter()
        {
            const string original =
                "$principalContext = New-Object DirectoryServices.AccountManagement.PrincipalContext Domain,$Domain";
            const string expected =
                "$principalContext = New-Object DirectoryServices.AccountManagement.PrincipalContext Domain, $Domain";
            Utility.ShouldMatch(original, expected);
        }

        [TestMethod]
        public void NewObject_Parameter_Number()
        {
            const string original = "$sb = New-Object Text.StringBuilder 16,$max";
            const string expected = "$sb = New-Object Text.StringBuilder 16, $max";
            Utility.ShouldMatch(original, expected);
        }

        [TestMethod]
        public void Foreach_In()
        {
            Utility.ShouldNotChanged("foreach ($line in $lines){}");
        }

        [TestMethod]
        public void ParseConsoleCommand()
        {
            Utility.ShouldNotChanged("& $sc failure $Name reset= $ResetFailureCount actions= $firstAction/$secondAction/$thirdAction");
            Utility.ShouldNotChanged("& $window.Resources.Scripts.$Name");


        }

        [TestMethod]
        public void AtParen()
        {
            {
                const string original = "Assert-Expression -Label 'number vs empty list' 4 @()";
                Utility.ShouldNotChanged(original);
            }
        }

        [TestMethod]
        public void AtCurly()
        {
            {
                const string original = "$script:showWindowAsync = Add-Type -memberDefinition @{";
                Utility.ShouldNotChanged(original);
            }
        }


        [TestMethod]
        public void Label()
        {

            Utility.ShouldNotChanged(":foreachLoop foreach ($p in $parsed){ break foreachLoop }");
            Utility.ShouldNotChanged(":foreachLoop foreach ($p in $parsed){ continue foreachLoop }");
        }




        [TestMethod]
        public void Dotsourced()
        {
            {
                const string original = @". { Write-Host 'aaa' }";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = @". MaybeAddUIProperty $ui";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = @". Script2.ps1";
                Utility.ShouldNotChanged(original);
            }

            {
                const string original = @". FunctionA";
                Utility.ShouldNotChanged(original);
            }

        }





        [TestMethod]
        public void DollorParen()
        {
            {
                const string original =
                    "$currentUser = New-Object Security.Principal.WindowsPrincipal $([Security.Principal.WindowsIdentity]::GetCurrent())";
                Utility.ShouldNotChanged(original);
            }
        }



        [TestMethod]
        public void LBracket()
        {
            {
                const string original = "$array[1].Member";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "Test-Command $array[1] $array[2]";
                Utility.ShouldNotChanged(original);
            }
        }



        [TestMethod]
        public void ClosingBlock()
        {
            Utility.ShouldNotChanged("(Get-Variable);");
            Utility.ShouldNotChanged("Import-Module (Join-Path $PSScriptRoot Carbon.psd1 -Resolve) -ErrorAction Stop");
        }


        [TestMethod]
        public void TypedVariable()
        {
            {
                Utility.ShouldNotChanged("[string] $test");
                Utility.ShouldNotChanged("[string[]] ${Path}");

                Utility.ShouldNotChanged("[string] $test");

            }
        }



        [TestMethod]
        public void CloseBracketRule()
        {
            {
                Utility.ShouldNotChanged("[string] $test");
                Utility.ShouldNotChanged("[string[]] $test");
                Utility.ShouldNotChanged("([string])::Empty");
                Utility.ShouldNotChanged("([string]).Assembly");
                Utility.ShouldNotChanged("{[string]}.Ast");

            }
        }







        [TestMethod]
        public void HashtableIndex()
        {
            {
                const string original = "$hash[$label]";
                Utility.ShouldNotChanged(original);
            }
        }

        [TestMethod]
        public void HashtableMember()
        {
            {
                const string original = "$hash[$label].Member";
                Utility.ShouldNotChanged(original);
            }
        }

        [TestMethod]
        public void Pipe()
        {
            {
                const string original = "$Results | Format-AsNUnit";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "'$Results' | iex";
                Utility.ShouldNotChanged(original);
            }
        }

        [TestMethod]
        public void LineSeparatorAtEndOfLine()
        {
            Utility.ShouldNotChanged("Colourize;");
            Utility.ShouldNotChanged("$test.Member;");
            Utility.ShouldNotChanged("1;");
            Utility.ShouldNotChanged("++$i;");
            Utility.ShouldNotChanged("$i--;");
        }



        [TestMethod]
        public void CatchException()
        {
            {
                const string original = "try {} catch [Exception]{} finally {}";
                Utility.ShouldNotChanged(original);
            }
        }


        [TestMethod]
        public void ExitCode()
        {
            {
                const string original = "exit -1";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "exit 'Get-Result $p)";
                Utility.ShouldNotChanged(original);
            }
        }


        [TestMethod]
        public void MinusMinusOperatorForCommandParameter()
        {
            Utility.ShouldNotChanged("echo --");
            Utility.ShouldNotChanged("echo -- -PSConsoleFile -Version -NoLogo -NoExit -Sta -NoProfile -NonInteractive");
            Utility.ShouldNotChanged("function glog{ git log --graph --pretty=format:'%Cred%h%Creset -%C(yellow)%d%Creset %s %Cgreen(%cr) %C(bold blue)<%an>%Creset' --abbrev-commit -- }");
        }

        [TestMethod]
        public void CommandArgument_Verbatim()
        {
            {
                const string original = "test.exe --% /a /b /c:abc";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "echoargs.exe --% \" % path % \"  # %path% is replaced with the value $env:path";
                Utility.ShouldNotChanged(original);
            }
        }

        [TestMethod]
        public void CallCmdlet()
        {
            {
                const string original = "& Get-Factorial 5";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "& 'Get-Factorial' 5";
                Utility.ShouldNotChanged(original);
            }
        }

        [TestMethod]
        public void Comment_InCommandModeParser()
        {
            Utility.ShouldNotChanged("Test-Item 'test' <# Or Rename or Move, etc.. #>");
            Utility.ShouldNotChanged("if (Test-Path $log){ Remove-Item $log <# Or Rename or Move, etc.. #> }");
            Utility.ShouldNotChanged("$ds.Tables[0].Rows | ForEach-Object { try { Add-NewAdmit $_ $admitTable.Item($_.Description) $admittedDn $studentTable.Item($_.Description) $studentDn $homeRoot<#$googleAppDn#> $moveStart $moveEnd $upnDomain $emailDomain } catch { Write-Host \"Error creating account: $_.CommonName\" $error[0]}}");
        }

        [TestMethod]
        public void CommandArgument_NativeCommand()
        {
            Utility.ShouldNotChanged(@"C:\cygwin\bin\bash.exe --login -- /usr/bin/ssh-host-config --yes --user cyg_server --pwd $password");
            Utility.ShouldNotChanged("$result = & $vboxmanage guestcontrol $vm exec \"C:\\Windows\\System32\\cmd.exe\" --username $username --password $password --wait-stdout -- /C echo hello world");
            Utility.ShouldNotChanged("$revision = ((git log \"$RefCommit..HEAD\" --pretty=format:\"%H\" -- (@($Path) | % { \"\"\"$_\"\"\" })) | Measure-Object).Count # Number of commits since our reference commit");
        }

        [TestMethod]
        public void CommandArgument_TokenBeforeLParen()
        {
            Utility.ShouldNotChanged("Join-Path $PWD('test')");
            Utility.ShouldNotChanged("Join-Path $PWD.PATH ('test')");
            Utility.ShouldNotChanged("Join-Path $PWD.PATH { 'test' }.Invoke()");
            Utility.ShouldNotChanged("Add-Member NoteProperty $_.Key (Get-HashtableAsObject $_.Value) -passThru");
        }


        [TestMethod]
        public void Other()
        {
            Utility.ShouldNotChanged("$test.Member;");
            Utility.ShouldNotChanged("$true | should ! be 0");
            Utility.ShouldNotChanged("$true | should not be 0");
            Utility.ShouldNotChanged("git checkout -- $BaseDir");
            Utility.ShouldNotChanged("if (Test-Path $log){ Remove-Item $log <# Or Rename or Move, etc.. #> }");
            Utility.ShouldNotChanged("[Environment]::GetFolderPath($_)");
            Utility.ShouldNotChanged("[KeyboardSend.KeyboardSend]::KeyDown('LWin')");


        }

        [TestMethod]
        public void PowerShellTokenSequence()
        {
            Utility.ShouldNotChanged("[] # cast/index");
            Utility.ShouldNotChanged("-and -or -xor -not ! # logical");
            Utility.ShouldNotChanged("$test.Member #logical");
            Utility.ShouldNotChanged("'<#comment#>#logical");
            Utility.ShouldNotChanged("'test' #logical");
            Utility.ShouldNotChanged("1 #logical");
            Utility.ShouldNotChanged("Test #logical");
            Utility.ShouldNotChanged("$val #logical");
            Utility.ShouldNotChanged("-and #logical");
        }

        [TestMethod]
        public void FunctionStatementIndent()
        {
            var content = @"
  function Test{
      }
";
            var expected = @"
function Test{
}
";

            Utility.ShouldMatch(content, expected);
        }

        [TestMethod]
        public void TokenSequence_ShouldNotBeChanged()
        {
            Utility.ShouldNotChanged("[ ]"); //if space removed tokenizer return "[]" token.
        }




        [TestMethod]
        public void EscapedSpace()
        {
            Utility.ShouldNotChanged(@"cd c:\program` files"); //if space removed tokenizer return "[]" token.
        }




    }
}
