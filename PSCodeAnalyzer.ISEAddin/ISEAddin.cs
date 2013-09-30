using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.PowerShell.Host.ISE;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using PSCodeAnalyzer.Utilities;

namespace PSCodeAnalyzer
{
    public class ISEAddin
    {
        //public static ObjectModelRoot IseRoot { get; private set; }

        public static void Initialize(ObjectModelRoot root)
        {
            //IseRoot = root;

            var menus = (ISEMenuItemCollection)root.CurrentPowerShellTab.AddOnsMenu.Submenus;

            //Add MenuItem(FormatDocument)
            {
                const string name = "Format Document";
                var gesture = new MultiKeyGesture(new[]{
                            new KeyGesture(Key.K, ModifierKeys.Control),
                            new KeyGesture(Key.D, ModifierKeys.Control),
                        }, "Ctrl+K, Ctrl+D");
                var scriptBlock = ScriptBlock.Create("Format-CurrentDocument -Range Document");

                var item = menus.SingleOrDefault(p => p.DisplayName == name);
                if (item != null)
                {
                    menus.Remove(item);
                }
                menus.Add(name, scriptBlock, gesture);
            }
            //typeof(PowerShellTab).GetProperty("StatusText").SetValue(root.CurrentPowerShellTab, "TestTest");

            //TODO:Support RangeFormatter
            //Add MenuItem(FormatDocument)
            {
                const string name = "Format Selection";
                var gesture = new MultiKeyGesture(new[]{
                    new KeyGesture(Key.K, ModifierKeys.Control),
                    new KeyGesture(Key.F, ModifierKeys.Control),
                }, "Ctrl+K, Ctrl+F");
                var scriptBlock = ScriptBlock.Create("Format-CurrentDocument -Range Selection");

                var item = menus.SingleOrDefault(p => p.DisplayName == name);
                if (item != null)
                {
                    menus.Remove(item);
                }
                menus.Add(name, scriptBlock, gesture);
            }
        }

        public enum FormatRange
        {
            Document,
            Selection,
        }

        public static void FormatCurrentDocument(ObjectModelRoot psIse, FormatRange range)
        {
            //IseRoot is not sync? ISERoot.CurrentFile may be null when multiple PowerShell tab opened.
            var currentFile = psIse.CurrentFile;

            if (currentFile == null)
                return;

            //TODO:Reflection Performance
            var viewHost = (IWpfTextViewHost)typeof(ISEEditor).GetProperty("EditorViewHost", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(currentFile.Editor);
            var textView = (ITextView)viewHost.TextView;
            Contract.Assert(textView != null);

            var analyzer = new CodeAnalyzer(textView, FormatCodeOptions.Current);

            try
            {
                Thread.Sleep(100);//HACK: To avoid ISE crashed by ArgumentOutOfRangeException.
                analyzer.FormatText();
                Thread.Sleep(100);//HACK: To avoid ISE crashed by ArgumentOutOfRangeException.
            }
            catch (Exception ex)
            {
                LastException = ex;
                throw;
                //TODO:Support ErrorMessage
                //Console.WriteLine(ex.Message); //Output to ISE ConsoleWindow
                //return;
            }
        }

        public static Exception LastException { get; set; }


    }
}
