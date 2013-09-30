using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using PSCodeAnalyzer.CodeFormatter;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;

namespace PSCodeAnalyzer
{
    public class Context
    {
        [ImportMany(typeof(IRule), RequiredCreationPolicy = CreationPolicy.Shared)]
        public IEnumerable<Lazy<IRule, IRuleMetadata>> Rules;

        [Import]
        private ITextBufferUndoManagerProvider _textBufferUndoManagerProvider;

        internal static ITextBufferUndoManagerProvider TextBufferUndoManagerProvider
        {
            get { return Current._textBufferUndoManagerProvider; }
        }

        private static readonly Lazy<Context> Singleton = new Lazy<Context>(() => new Context(),
                                                                   LazyThreadSafetyMode.ExecutionAndPublication);


        public static Context Current
        {
            get
            {
                return Singleton.Value;
            }
        }

        private static CompositionContainer _container;

        private Context()
        {
            var catalog = new AggregateCatalog(new ComposablePartCatalog[]
                {
                    new AssemblyCatalog(Assembly.GetExecutingAssembly()),
                    new AssemblyCatalog(typeof (ITextEditorFactoryService).Assembly)
                });

            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog); //don't dispose container(for Lazy loading)
            try
            {
                _container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                throw;
            }
        }


        public static void Initialize()
        {
            //Load lazy objects for performance analysis.
            var rules = Context.Current.Rules.Select(p => p.Value).ToArray();
        }
    }
}
