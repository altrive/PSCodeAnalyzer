using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Microsoft.PowerShell.Host.ISE;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Microsoft.VisualStudio.Text.Operations;
using PSCodeAnalyzer.Utilities;

namespace PSCodeAnalyzer
{
    public class ISEAddin
    {
        internal static ObjectModelRoot IseRoot { get; set; }

        public static Exception LastException { get; set; }//For deegugging variable (Use [PSCodeAnalyzer.ISEAddin].LastException)

        private static ICodeAnalyzerFactory _codeAnalyzerFactory;
        private static ICodeFormatterFactory _codeFormatterFactory;
        private static ITextBufferUndoManagerProvider _undoManagerProvider;

        public static void Initialize(ObjectModelRoot root)
        {
            IseRoot = root;

            InitializeMenus(root);
            InitializeMEFComponents();
        }

        public enum FormatRange
        {
            Document,
            Selection,
        }

        public static void FormatCurrentDocument(ObjectModelRoot psIse, FormatRange range)
        {
            //Cached IseRoot is not sync? ISERoot.CurrentFile may be null when multiple PowerShell tab opened.
            var currentFile = psIse.CurrentFile;

            if (currentFile == null)
                return;

            //TODO:Reflection Performance
            var viewHost = (IWpfTextViewHost)typeof(ISEEditor).GetProperty("EditorViewHost", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(currentFile.Editor);
            var textView = (ITextView)viewHost.TextView;

            if (textView == null || textView.TextBuffer == null)
                return;

            var analyzer = _codeAnalyzerFactory.Create(textView);
            var formatter = _codeFormatterFactory.Create(textView.TextBuffer);

            var analyzedResult = analyzer.Analyze();
            var formatResult = formatter.FormatCode(analyzedResult);

            try
            {
                //Need to execute operation in UI thread? to avoid ISE crashed by ArgumentOutOfRangeException
                Application.Current.Dispatcher.Invoke(() =>
                {
                    //If refresh needed. retry operation in UI thread
                    if (textView.TextSnapshot.Version != analyzedResult.TextSnapshot.Version)
                    {
                        formatResult = formatter.FormatCode(analyzer.Analyze());
                    }
                    formatResult.Commit(_undoManagerProvider);
                });
            }
            catch (Exception ex)
            {
                LastException = ex;
                throw;
                //TODO:Support ErrorMessage
                //Console.WriteLine(ex.Message); //Output to ISE ConsoleWindow
            }
        }

        private static void InitializeMenus(ObjectModelRoot root)
        {
            var menus = (ISEMenuItemCollection)root.CurrentPowerShellTab.AddOnsMenu.Submenus;

            //Add MenuItem(FormatDocument)
            {
                const string name = "Format Document";
                var gesture = new MultiKeyGesture(new[]
                {
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
                var gesture = new MultiKeyGesture(new[]
                {
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

        private static void InitializeMEFComponents()
        {
            //Import VS components using MEF
            var catalog = new AggregateCatalog(new ComposablePartCatalog[]
            {
                new AssemblyCatalog(Assembly.GetExecutingAssembly()),
                new AssemblyCatalog(typeof (ICodeAnalyzerFactory).Assembly),
                new AssemblyCatalog(typeof (ITextBufferUndoManagerProvider).Assembly)
            });

            //Create the CompositionContainer with the parts in the catalog
            var container = new CompositionContainer(catalog);
            try
            {
                _codeAnalyzerFactory = container.GetExportedValue<ICodeAnalyzerFactory>();
                _codeFormatterFactory = container.GetExportedValue<ICodeFormatterFactory>();
                _undoManagerProvider = container.GetExportedValue<ITextBufferUndoManagerProvider>();
            }
            catch (CompositionException)
            {
                throw;
            }
        }


    }
}
