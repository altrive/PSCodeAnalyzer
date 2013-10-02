using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Management.Automation;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Management.Automation.Language;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using PSCodeAnalyzer.CodeFormatter;
using Microsoft.VisualStudio.Text.Operations;

namespace PSCodeAnalyzer
{

    [Export]
    public class CodeAnalyzer
    {
        private readonly ITextView _textView;

        //private readonly string _text;
        private readonly FormatCodeOptions _option;
        private ScriptContext _context;

        public Token[] Tokens { get { return _context.Tokens; } }
        public ParseError[] Errors { get { return _context.Errors; } }


        internal CodeAnalyzer(ITextView textView, FormatCodeOptions option)
        {
            Contract.Assert(textView != null);
            this._textView = textView;
            this._option = option;
        }

        private bool isAnalyzeCompleted = false;
        public void Analyze()
        {
            var text = _textView.TextSnapshot.GetText();
            this._context = ScriptContext.Parse(text);

            isAnalyzeCompleted = true;
        }

        public void FormatText()
        {
            if (!isAnalyzeCompleted)
                Analyze();

            _context.ResetState();

            var textBuffer = _textView.TextBuffer;

            var formatter = new CodeFormatter.CodeFormatter(_option);

            formatter.FormatCode(textBuffer, _context);
        }
    }
}
