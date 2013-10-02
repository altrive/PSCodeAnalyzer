using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Text.Utilities;
using Microsoft.VisualStudio.Utilities;

namespace PSCodeAnalyzer.Tests
{
    class EditorImports
    {
        private static EditorImports _value;
        [Import]
        private ITextBufferFactoryService _textBufferFactoryService;

        [Import]
        private ITextEditorFactoryService _textEditorFactoryService;

        [Import]
        private IContentTypeRegistryService _contentTypeRegistryService;

        [Import]
        private ITextBufferUndoManagerProvider _textBufferUndoManagerProvider;

        [Import]
        private ICodeAnalyzerFactory _codeAnalyzerFactory;


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


        internal static ICodeAnalyzerFactory CodeAnalyzerFactory
        {
            get { return Current._codeAnalyzerFactory; }
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

            var catalog = new AggregateCatalog(new ComposablePartCatalog[]
                {
                    new AssemblyCatalog(Assembly.GetExecutingAssembly()),
                    new AssemblyCatalog(typeof (ICodeAnalyzerFactory).Assembly),
                    new AssemblyCatalog(typeof (ITextEditorFactoryService).Assembly)
                });

            var container = new CompositionContainer(catalog);
            {
                try
                {
                    container.ComposeParts(this);
                    PSCodeAnalyzer.EditorImports.Current = container.GetExportedValue<PSCodeAnalyzer.EditorImports>();
                    //Need to create private field instance before access
                    //var dummy = _editorOptionsFactoryService.GlobalOptions;
                }
                catch (CompositionException compositionException)
                {
                    throw;
                }
            }

        }
    }
}
