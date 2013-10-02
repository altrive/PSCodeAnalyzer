using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PSCodeAnalyzer.Tests
{
    [TestClass]
    public class CommentFormatTest
    {
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void Init()
        {
            //Execution time is included in first test case?
            EditorImports.Initialize();
        }


        [TestMethod]
        public void ScopedVariable()
        {
            {
                const string original = "Test-Path env:VS110COMNTOOLS";
                Utility.ShouldNotChanged(original);
            }
        }


        [TestMethod]
        public void LineComment()
        {
            {
                const string original = "#This is a comment";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "$i = 0 #This is a comment"; //add space before line comment
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "$i = 0 #    This is a comment    "; //line comment spaces should be preserved
                Utility.ShouldNotChanged(original);
            }
        }

        [TestMethod]
        public void BlockComment()
        {
            {
                const string original = "<# This is a comment #>";
                const string expected = "<# This is a comment #>";
                Utility.ShouldMatch(original, expected);
            }
            {
                const string original = "$i = 0     <# This is a comment #>   ";
                const string expected = "$i = 0 <# This is a comment #>";
                Utility.ShouldMatch(original, expected);
            }
            {
                const string original = "Get-Help     <# This is a comment #>   ";
                const string expected = "Get-Help <# This is a comment #>";
                Utility.ShouldMatch(original, expected);
            }
            {
                const string original = "$i <# This is a comment #>++ - ++$i";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "$i <# This is a comment #> - <# This is a comment #>++$i"; //BinaryOperatorRule should be applied
                Utility.ShouldNotChanged(original);
            }
        }


        [TestMethod]
        public void RequiresComment()
        {
            Utility.ShouldNotChanged("#Requires –Modules PSWorkflow");
            Utility.ShouldNotChanged("#Requires –Version 3.0");
            Utility.ShouldNotChanged("#Requires –ShellId MyLocalShell");
            Utility.ShouldNotChanged("#Requires -Modules PSWorkflow, @{ModuleName='PSScheduledJob';ModuleVersion=1.0.0.0}");
            Utility.ShouldNotChanged("#Requires –PSSnapin DiskSnapin -Version 1.2");
            Utility.ShouldNotChanged("#Requires -RunAsAdministrator ");
        }
    }
}
