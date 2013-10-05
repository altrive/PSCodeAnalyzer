using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Text.Editor;

namespace PSCodeAnalyzer
{
    public interface ICodeFormatterFactory
    {
        CodeFormatter Create(ITextBuffer textBuffer);
    }

    [Export(typeof(ICodeFormatterFactory))]
    public class CodeFormatterFactory : ICodeFormatterFactory
    {

        //[Import]
        //private IEditorOptionsFactoryService _editorOptionsProvider { get; set; }

        //[Import]
        //private IEditorOperationsFactoryService _editorOperationsFactoryService { get; set; }
        
        //[Import]
        //private ITextBufferUndoManagerProvider _textBufferUndoManagerProvider = null;

        public CodeFormatter Create(ITextBuffer textBuffer)
        {
            return new CodeFormatter(FormatCodeOptions.Default, textBuffer);
        }
    }
}
