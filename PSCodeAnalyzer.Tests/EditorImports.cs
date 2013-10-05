using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Utilities;

namespace PSCodeAnalyzer.Tests
{
    class EditorImports
    {
        private static EditorImports _value;
        [Import]
        private ITextBufferFactoryService _textBufferFactoryService = null;

        [Import]
        private ITextEditorFactoryService _textEditorFactoryService = null;

        [Import]
        private IContentTypeRegistryService _contentTypeRegistryService = null;

        [Import]
        private ITextBufferUndoManagerProvider _undoManagerProvider = null;

        [Import]
        private ICodeAnalyzerFactory _codeAnalyzerFactory = null;

        [Import]
        private ICodeFormatterFactory _codeFormatterFactory = null;


        internal static ITextEditorFactoryService TextEditorFactoryService
        {
            get { return Current._textEditorFactoryService; }
        }

        internal static ITextBufferFactoryService TextBufferFactoryService
        {
            get { return Current._textBufferFactoryService; }
        }
        internal static IContentTypeRegistryService ContentTypeRegistryService
        {
            get { return Current._contentTypeRegistryService; }
        }
        internal static ITextBufferUndoManagerProvider UndoManagerProvider
        {
            get { return Current._undoManagerProvider; }
        }

        internal static ICodeAnalyzerFactory CodeAnalyzerFactory
        {
            get { return Current._codeAnalyzerFactory; }
        }

        internal static ICodeFormatterFactory CodeFormatterFactory
        {
            get { return Current._codeFormatterFactory; }
        }



        private static EditorImports Current
        {
            get
            {
                if (_value != null)
                    return _value;

                _value = new EditorImports();
                _value.Compose();
                return _value;
            }
        }

        public static void Initialize()
        {
            var dummy = Current;
        }

        private void Compose()
        {
            //Load assemblies
            /*
            //GetReferencedAssemblies don't return all assemblies, if it is not used at all.
            var referencedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            foreach (var assemblyName in referencedAssemblies)
            {
                Assembly.Load(assemblyName);
            }
            */
#if VisualStudio
            var assemblyNames = new[]
            {
                "envdte, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "Microsoft.VisualStudio.Editor.Implementation, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL",
                "Microsoft.VisualStudio.CoreUtility, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL",
                "Microsoft.VisualStudio.Text.Data, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL",
                "Microsoft.VisualStudio.Text.Logic, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL",
                "Microsoft.VisualStudio.Text.UI, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL",
                "Microsoft.VisualStudio.Text.UI.Wpf, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL",
                "Microsoft.VisualStudio.Shell.12.0, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL",
                "Microsoft.VisualStudio.Shell.Design, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL",
                "Microsoft.VisualStudio.Shell.Interop, Version=7.1.40304.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "Microsoft.VisualStudio.Shell.Interop.8.0, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "Microsoft.VisualStudio.Shell.Interop.9.0, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "Microsoft.VisualStudio.Shell.Interop.10.0, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "Microsoft.VisualStudio.Shell.Interop.12.0, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "Microsoft.VisualStudio.Shell.Immutable.10.0, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "Microsoft.VisualStudio.OLE.Interop, Version=7.1.40304.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "Microsoft.VisualStudio.Platform.VSEditor, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL",
                "Microsoft.VisualStudio.Platform.VSEditor.Interop, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL",
                "Microsoft.VisualStudio.ComponentModelHost, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL",
            };
            foreach (var name in assemblyNames)
            {
                Assembly.Load(name);
            }

            var interop = typeof(Microsoft.VisualStudio.Platform.VSEditor.Interop.IVxTextBuffer).Assembly;
            AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
            {
                if (StringComparer.OrdinalIgnoreCase.Equals(e.Name, interop.FullName))
                {
                    return interop;
                }

                return null;
            };

#endif

            var catalog = new AggregateCatalog(new ComposablePartCatalog[]
                {
                    new AssemblyCatalog(Assembly.GetExecutingAssembly()),
                    new AssemblyCatalog(typeof (ICodeAnalyzerFactory).Assembly),
                    new AssemblyCatalog(typeof (ITextBufferFactoryService).Assembly),
                });

            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(p => p.FullName.StartsWith("Microsoft.VisualStudio"))
                .Where(p => !p.FullName.StartsWith("Microsoft.VisualStudio.Test"));
            foreach (var assembly in assemblies)
            {
                catalog.Catalogs.Add(new AssemblyCatalog(assembly));
            }

            var container = new CompositionContainer(catalog);
            {
                try
                {
                    container.ComposeParts(this);
                    //PSCodeAnalyzer.EditorImports.Current = container.GetExportedValue<PSCodeAnalyzer.EditorImports>();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

        }
    }
}
