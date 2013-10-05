using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;

namespace PSCodeAnalyzer
{
    public interface ICodeAnalyzerFactory
    {
        CodeAnalyzer Create(ITextView textView);
    }

    [Export(typeof(ICodeAnalyzerFactory))]
    public class CodeAnalyzerFactory : ICodeAnalyzerFactory
    {
        //[ImportMany(typeof(IRule), RequiredCreationPolicy = CreationPolicy.Shared)]
        //private IEnumerable<Lazy<IRule, IRuleMetadata>> _rules = null;

        public CodeAnalyzer Create(ITextView textView)
        {
            return new CodeAnalyzer(textView);
        }
    }

}
