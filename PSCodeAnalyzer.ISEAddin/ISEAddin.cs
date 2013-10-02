using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
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
        //public static ObjectModelRoot IseRoot { get; private set; }

        //[Import]
        private static ICodeAnalyzerFactory codeAnalyzerFactory;

        public static void Initialize(ObjectModelRoot root)
        {
            //IseRoot = root;

            RegisterMenus(root);

            InitializeMEFComponents();
        }

        private static void RegisterMenus(ObjectModelRoot root)
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
                codeAnalyzerFactory = container.GetExportedValue<ICodeAnalyzerFactory>();
                EditorImports.Current = container.GetExportedValue<EditorImports>();
            }
            catch (CompositionException compositionException)
            {
                throw;
            }
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

            if (textView == null)
                return;

            var analyzer = codeAnalyzerFactory.Create(textView);

            try
            {
                //Need to execute whole operation in UI thread? to avoid ISE crashed by ArgumentOutOfRangeException
                Application.Current.Dispatcher.Invoke(() =>
                {
                    analyzer.FormatText();  //TODO:If format operation take too long times. UI thread may freezed.
                });
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
