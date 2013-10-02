using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PSCodeAnalyzer.Tests
{

    [TestClass]
    public class ThirdPartyCodeFileTest
    {
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void Init()
        {
            //Execution time is included in first test case?
            EditorImports.Initialize();
        }


        [TestMethod]
        public void ThirdParty_WindowsDSCDemo()
        {
            var downloadUrl = "http://blogs.msdn.com/b/powershell/archive/2013/07/29/powershell-sessions-slides-and-demos-from-teched-2013.aspx";
            TestFiles("WindowsDSC_Demo", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_Corefig()
        {
            var downloadUrl = "http://corefig.codeplex.com";
            TestFiles("Corefig", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_Carbon()
        {
            var downloadUrl = "http://get-carbon.org/";
            TestFiles("Carbon", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_CleanCode()
        {
            var downloadUrl = "";
            TestFiles("CleanCode", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_ConvertWindowsImage()
        {
            var downloadUrl = "";
            TestFiles("Convert-WindowsImage", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_PowerShellUtil()
        {
            var downloadUrl = "";
            TestFiles("PowerShellUtil", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_AltrivePowerShell()
        {
            var downloadUrl = "";
            TestFiles("Altrive.PowerShell", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_PowerShellDeploymentToolkit()
        {
            var downloadUrl = "";
            TestFiles("PowerShell-Deployment-Toolkit", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_ISESessionTools()
        {
            var downloadUrl = "";
            TestFiles("ISESessionTools", downloadUrl);
        }


        [TestMethod]
        public void ThirdParty_Pester()
        {
            var downloadUrl = "";
            TestFiles("Pester", downloadUrl);
        }


        [TestMethod]
        public void ThirdParty_PSate()
        {
            var downloadUrl = "";
            TestFiles("PSate", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_PsGet()
        {
            var downloadUrl = "";
            TestFiles("PsGet", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_PShould()
        {
            var downloadUrl = "";
            TestFiles("PShould", downloadUrl);
        }


        [TestMethod]
        public void ThirdParty_PSMock()
        {
            var downloadUrl = "";
            TestFiles("PSMock", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_PSWindowsUpdate()
        {
            var downloadUrl = "";
            TestFiles("PSWindowsUpdate", downloadUrl);
        }


        [TestMethod]
        public void ThirdParty_ScriptCop()
        {
            var downloadUrl = "";
            TestFiles("ScriptCop", downloadUrl);
        }


        [TestMethod]
        public void ThirdParty_ShowUI()
        {
            var downloadUrl = "";
            TestFiles("ScriptCop", downloadUrl);
        }


        [TestMethod]
        public void ThirdParty_SnippetManager2()
        {
            var downloadUrl = "";
            TestFiles("SnippetManager2", downloadUrl);
        }


        [TestMethod]
        public void ThirdParty_TabExpansionPlusPlus()
        {
            var downloadUrl = "";
            TestFiles("TabExpansion++", downloadUrl);
        }


        [TestMethod]
        public void ThirdParty_WindowsKeyBinding()
        {
            var downloadUrl = "";
            TestFiles("WindowsKeyBinding", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_WMIExplorer()
        {
            var downloadUrl = "";
            TestFiles("WMIExplorer", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_jQuery()
        {
            var downloadUrl = "";
            TestFiles("jQuery", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_AutomatedLab()
        {
            var downloadUrl = "";
            TestFiles("AutomatedLab", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_PowerShellCookbook()
        {
            var downloadUrl = "";
            TestFiles("PowerShellCookbook", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_Other()
        {
            var downloadUrl = "";
            TestFiles("Other", downloadUrl);
        }

        [TestMethod]
        public void ThirdParty_NonPowerShellCode()
        {
            var downloadUrl = "";
            TestFiles("NonPowerShellCode", downloadUrl);
        }


        private const string BasePath = @"..\..\Scripts\ThirdParty";

        private void TestFiles(string directoryName, string downloadUrl)
        {
            var diffLaunchBatPath = Utility.TestFiles(BasePath, directoryName, downloadUrl);

            //Append Result Diff bat file
            TestContext.AddResultFile(diffLaunchBatPath);
        }


    }
}
