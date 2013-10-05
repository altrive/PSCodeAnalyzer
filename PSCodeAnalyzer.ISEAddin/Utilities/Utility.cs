using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.PowerShell.Host.ISE;

namespace PSCodeAnalyzer
{
    public static class Utility
    {
        public static void ShowMessageToStatusBar(string message)
        {
            typeof(PowerShellTab).GetProperty("StatusText").SetValue(ISEAddin.IseRoot.CurrentPowerShellTab, message);
        }
    }
}
