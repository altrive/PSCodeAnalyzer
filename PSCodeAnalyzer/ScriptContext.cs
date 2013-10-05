using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PSCodeAnalyzer.Visitors;

namespace PSCodeAnalyzer
{
    public class ScriptContext //: IScriptContext
    {
        public Token[] Tokens { get; private set; }
        public ParseError[] Errors { get; private set; }

        public ScriptBlockAst Ast { get; private set; }
        public FormatCodeOptions Options { get; private set; }

        public Token CurrentToken { get; private set; }
        public Token NextToken { get; private set; }

        public bool IsStartOfLine { get; private set; }
        public bool IsEndOfLine { get; private set; }

        public TokenIndentMode NextTokenIndentMode = TokenIndentMode.None;

        public string Text { get; set; }

        private int Index { get; set; }

        private int LineNumber { get; set; }
        private int IndentLevel { get; set; }

        public enum TokenIndentMode
        {
            None,
            ForceIndent,
            Indent,
            SuppressIndent,
        }

        private ScriptContext()
        {
        }

        public ScriptContext(string text)
        {
            Contract.Assert(text != null);

            Token[] tokens = null;
            ParseError[] errors = null;
            ScriptBlockAst ast = null;
            try
            {
                ast = Parser.ParseInput(text, out tokens, out errors);
            }
            catch
            {
                throw; //TODO:Error Handling
            }
            Contract.Assert(tokens != null);
            Contract.Assert(errors != null);
            Contract.Assert(ast != null);

            this.Text = text;
            this.Tokens = tokens;
            this.Errors = errors;
            this.Ast = ast;
            ResetState();
        }

        //Parse PowerShell code text

        public static ScriptContext Parse(string text)
        {
            return new ScriptContext(text);
        }

        internal void ResetState()
        {
            CurrentToken = null;
            NextToken = null;
            LineNumber = 0;
            Index = -1; //use zero-based index
            this.NextToken = PeekToken(1);

            IsStartOfLine = true;
            IsEndOfLine = false;
            this.Options = FormatCodeOptions.Current;
        }

        public Token Next()
        {
            this.NextTokenIndentMode = TokenIndentMode.None;
            this.IsStartOfLine = (CurrentToken == null || CurrentToken.Kind == TokenKind.NewLine);

            ++Index;

            this.CurrentToken = this.NextToken;
            this.NextToken = PeekToken(1);

            this.IsEndOfLine = (CurrentToken.Kind == TokenKind.NewLine ||
                                CurrentToken.Kind == TokenKind.EndOfInput ||
                                NextToken.Kind == TokenKind.NewLine ||
                                NextToken.Kind == TokenKind.EndOfInput);

            //Set indent level
            switch (CurrentToken.GetPSTokenType())
            {
                case PSTokenType.GroupStart:
                    {
                        ++IndentLevel;
                        break;
                    }
                case PSTokenType.GroupEnd:
                    {
                        if (IndentLevel != 0)
                        {
                            --IndentLevel;
                        }
                        break;
                    }
            }

            return this.CurrentToken;
        }

        //return curren indent level
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetIndentLevel()
        {
            return (this.IsStartOfLine && CurrentToken.GetPSTokenType() == PSTokenType.GroupStart)
                ? this.IndentLevel - 1
                : this.IndentLevel;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Token PeekToken(int i)
        {
            var index = this.Index + i;
            if (index < 0)
            {
                return null;
            }

            //Need to return EndOfInput token if over index
            index = Math.Min(index, Tokens.Length - 1);

            return Tokens[index];
        }

        #region helper functions(state is not changed)
        public bool HasTrailingSpaceAfterToken(Token token)
        {
            int index = token.Extent.EndOffset;

            if (index >= Text.Length)
                return false;
            return this.Text[index] == ' ';
        }

        public bool IsParameterBlockContext()
        {
            var visitor = new FindAstByExtentVisitor<ParamBlockAst>(CurrentToken);
            Ast.Visit(visitor);
            return visitor.Result !=null;
        }
        #endregion
    }
}
