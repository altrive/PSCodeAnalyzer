using System;
using System.IO;
using System.Management.Instrumentation;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PSCodeAnalyzer.Tests
{


    [TestClass]
    public class SimpleTest
    {
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void Init()
        {
            //Execution time is included in first test case?
            Context.Initialize();
            EditorImports.Initialize();
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void EmptyText()
        {
            Utility.ShouldNotChanged("");
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void Function()
        {
            Utility.ShouldNotChanged("function Test{ Write-Host $p $p2 }");
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void FunctionWithParam1()
        {
            Utility.ShouldNotChanged("function Test([int] $p){ Write-Host $p }");
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void FunctionWithParam2()
        {
            Utility.ShouldNotChanged("function Test{[Parameter(Mandatory)] param ([int] $a) Write-Host $p }");
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void MultiStatement()
        {
            const string original = "[string]$text='abc'; Write-Host $a;sleep 1;";
            const string expected = "[string] $text = 'abc'; Write-Host $a; sleep 1;";
            Utility.ShouldMatch(original, expected);
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void SpecialVariableName_Dot()
        {
            const string original = "${.NET} = 'Microsoft .NET Framework'";
            const string expected = "${.NET} = 'Microsoft .NET Framework'";
            Utility.ShouldMatch(original, expected);
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void SpecialVariableName_WhiteSpace()
        {
            const string original = "${   } = 'Triple space'";
            const string expected = "${   } = 'Triple space'";
            Utility.ShouldMatch(original, expected);
        }


        [TestCategory("Basic")]
        [TestMethod]
        public void ExtraWhitespaceAndTab()
        {
            const string original = "$date  =  Get-Date \t  -Format  \t 'yyyy/MM/dd'\t";
            const string expected = "$date = Get-Date -Format 'yyyy/MM/dd'";
            Utility.ShouldMatch(original, expected);
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void CommandParamter()
        {
            const string original = "Get-Help -Name help -ErrorAction Continue -Full -Verbose:$False";
            const string expected = "Get-Help -Name help -ErrorAction Continue -Full -Verbose:$False";
            Utility.ShouldMatch(original, expected);
        }

        [TestCategory("Basic")]
        public void CommandParamter_Number_NoParameterName()
        {
            const string original = "Test-Command 1 2 3";
            const string expected = "Test-Command 1 2 3";
            Utility.ShouldMatch(original, expected);
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void CommandParamter_String_NoParameterName()
        {
            const string original = "Test-Command '1' '2'";
            const string expected = "Test-Command '1' '2'";
            Utility.ShouldMatch(original, expected);
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void CommandParamter_Variable_NoParameterName()
        {
            const string original = "Test-Command $v1 $v2";
            const string expected = "Test-Command $v1 $v2";
            Utility.ShouldMatch(original, expected);
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void CommandParamter_Expression_NoParameterName()
        {
            const string original = "Test-Command (1) (2) (3)";
            const string expected = "Test-Command (1) (2) (3)";
            Utility.ShouldMatch(original, expected);
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void CommandParamter_Expression_NoParameterNameArray()
        {
            const string original = "Test-Command (1) 1";
            const string expected = "Test-Command (1) 1";
            Utility.ShouldMatch(original, expected);
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void CommandParamter_Array_NoNameSpecified()
        {
            const string original = "Test-Command @(1,2,3) @(1,2,3)";
            const string expected = "Test-Command @(1, 2, 3) @(1, 2, 3)";
            Utility.ShouldMatch(original, expected);
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void CommandParamter_Hashtable_NoNameSpecified()
        {
            const string original = "Test-Command @{1,2,3} @{1,2,3}";
            const string expected = "Test-Command @{ 1, 2, 3 } @{ 1, 2, 3 }";
            Utility.ShouldMatch(original, expected);
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void ParamBlock()
        {
            Utility.ShouldNotChanged("param ([Mandatory=$true)");
            Utility.ShouldNotChanged("param ([Mandatory, Position=1)");
            Utility.ShouldNotChanged("param ([Mandatory=$true, Position=1)");
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void InsertSpaceAfterBlock()
        {
            Utility.ShouldNotChanged("[int] $i = $array[1];");
        }


        [TestCategory("Basic")]
        [TestMethod]
        public void Variable()
        {
            Utility.ShouldNotChanged("$totalCost");
            Utility.ShouldNotChanged("$Maximum_Count_26");
            Utility.ShouldNotChanged("$végösszeg");
            Utility.ShouldNotChanged("$итог");
            Utility.ShouldNotChanged("$総計");
            Utility.ShouldNotChanged("${Maximum_Count_26}");
            Utility.ShouldNotChanged("${Name with`twhite space and `{punctuation`}}");
            Utility.ShouldNotChanged(@"${E:\File.txt}");
            Utility.ShouldNotChanged("$values = 5, 3");
            Utility.ShouldNotChanged("$hash = @{ exponent = 3; base = 5 }");
            Utility.ShouldNotChanged("Get-Power @values");
            Utility.ShouldNotChanged("Get-Power @hash");
            Utility.ShouldNotChanged("$Function:F");
            Utility.ShouldNotChanged("$Alias:A");
            Utility.ShouldNotChanged("$Variable:Count");
            Utility.ShouldNotChanged("$Env:Path");
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void MultiplierSuffix()
        {
            //Multiplier suffix
            Utility.ShouldNotChanged("1KB");
            Utility.ShouldNotChanged("1MB");
            Utility.ShouldNotChanged("1GB");
            Utility.ShouldNotChanged("1TB");
            Utility.ShouldNotChanged("1PB");
        }

        [TestCategory("Basic")]
        [TestMethod]
        public void TypeSuffix()
        {
            //Multiplier suffix
            Utility.ShouldNotChanged("$v = 1L");
            Utility.ShouldNotChanged("$v = 1.0f");
        }
    }
}
