using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;

namespace PSCodeAnalyzer.CodeFormatter
{



    public class StringBuilderEx
    {
        private readonly StringBuilder _sb;
        public StringBuilderEx(StringBuilder sb)
        {
            _sb = sb;
        }

        public void WriteIndent(string indent)
        {
            _sb.Append(indent);
        }

        public void WriteSpace()
        {
            _sb.Append(' ');
        }

        public void WriteText(string text)
        {
            _sb.Append(text);
        }

        public void WriteNewLine(string newLineChars)
        {
            _sb.Append(newLineChars);
        }

        public int GetCurrentOffset()
        {
            return _sb.Length;
        }

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}
