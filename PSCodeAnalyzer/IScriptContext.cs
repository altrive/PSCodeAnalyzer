using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PSCodeAnalyzer.Visitors;

namespace PSCodeAnalyzer
{
    public interface IScriptContext
    {
        int GetIndentLevel();

        Token CurrentToken { get; }
        Token NextToken { get; }

        Token PeekToken(int i);

        bool IsStartOfLine { get; }
        bool IsEndOfLine { get; }

        bool HasTrailingSpaceAfterToken(Token token);

        bool SetIndentNextToken(bool force = false);

        bool SetNoIndentNextToken(bool force = false);

        FormatCodeOptions Options { get; }

        bool IsParameterBlockContext();
    }

    public class ScriptContext : IScriptContext
    {
        public string Text { get; private set; }

        public int Index { get; private set; }

        public int LineNumber { get; private set; }
        public int IndentLevel { get; private set; }
        public Token[] Tokens { get; private set; }
        public ParseError[] Errors { get; private set; }

        public ScriptBlockAst Ast { get; private set; }


        public Token CurrentToken { get; private set; }
        public Token NextToken { get; private set; }

        public bool IsStartOfLine { get; private set; }
        public bool IsEndOfLine { get; private set; }

        public FormatCodeOptions Options
        {
            get;
            private set;
        }

        public enum TokenIndentMode
        {
            None,
            ForceIndent,
            Indent,
            SuppressIndent,
        }

        public TokenIndentMode IndentMode = TokenIndentMode.None;

        private ScriptContext()
        {
            ResetState();
        }

        internal void ResetState()
        {
            //TODO: implement
            CurrentToken = null;
            NextToken = null;
            LineNumber = 0;
            Index = -1; //zero-based index

            IsStartOfLine = true;
            IsEndOfLine = false;
            this.Options = new FormatCodeOptions();
        }

        public static ScriptContext Parse(string text)
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

            return new ScriptContext()
            {
                Text = text,
                Tokens = tokens,
                Errors = errors,
                Ast = ast,
            };
        }


        public Token Next()
        {
            this.IndentMode = TokenIndentMode.None;
            this.IsStartOfLine = (CurrentToken == null || CurrentToken.Kind == TokenKind.NewLine);

            ++Index;

            this.CurrentToken = PeekToken(0);
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


        public int GetIndentLevel()
        {
            return IndentLevel;
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

        public string GetIndentForCurrentLine()
        {
            Contract.Assert(this.IsStartOfLine);

            var lineIndentLevel = IndentLevel;

            //Need to adjust indent level for token GroupEnd(ClosingBrace)              
            if (CurrentToken.GetPSTokenType() == PSTokenType.GroupStart)
            {
                --lineIndentLevel;
            }

            //Return indent
            var sb = new StringBuilder();
            for (var i = 0; i < lineIndentLevel; ++i)
            {
                //TODO:Option
                sb.Append(this.Options.IndentString);
                //_sb.Append(_option.IndentChar);
            }
            return sb.ToString();
        }

        public bool HasTrailingSpaceAfterToken(Token token)
        {
            int index = token.Extent.EndOffset;

            if (index >= Text.Length)
                return false;
            return this.Text[index] == ' ';
        }

        public bool SetIndentNextToken(bool force)
        {
            if (force)
            {
                //Contract.Assert(IndentMode != TokenIndentMode.SuppressIndent);
            }

            this.IndentMode = force
                    ? TokenIndentMode.ForceIndent
                    : TokenIndentMode.Indent;
            return true;
        }

        public bool SetNoIndentNextToken(bool force)
        {
            //Contract.Assert(IndentMode != TokenIndentMode.ForceIndent);
            if (force || this.IndentMode != TokenIndentMode.ForceIndent)
            {
                this.IndentMode = TokenIndentMode.SuppressIndent;
            }
            return true;
        }

        public bool IsParameterBlockContext()
        {
            var visitor = new FindAstVisitor<ParamBlockAst>(CurrentToken);
            Ast.Visit(visitor);
            return visitor.Result;
        }


        internal void Validate(string formattedText)
        {
            var formattedContext = Parse(formattedText);
            //TODO:Handle NewLine token
            bool isSequenceMatch = this.Tokens.SequenceEqual(formattedContext.Tokens,
                                               token => new
                                                    {
                                                        token.Kind,
                                                        token.TokenFlags,
                                                        token.Text
                                                    });

            if (isSequenceMatch)
                return;

            //Token Sequence is not matched. throw exception.
            var diffToken = this.Tokens.Zip(formattedContext.Tokens, (first, second) => new { First = first, Second = second })
                .First(p => !p.First.IsSameToken(p.Second));


            var sb = new StringBuilder();
            sb.AppendLine("Format code operation failed! Please report following error context information");
            sb.AppendLine("---------------------------------------");
            sb.AppendLine("Line: Before -> After");
            sb.AppendLine(this.Text.GetLineText(diffToken.First.Extent.StartLineNumber));
            sb.AppendLine(formattedContext.Text.GetLineText(diffToken.Second.Extent.StartLineNumber));
            sb.AppendLine("---------------------------------------");

            //Write token informations
            var diffTokenLineNumber = diffToken.First.Extent.StartLineNumber;
            foreach (var token in Tokens)
            {
                if (token.Extent.StartLineNumber < diffTokenLineNumber - 1)
                    continue; //skip
                if (diffTokenLineNumber < token.Extent.StartLineNumber)
                    break; //stop

                //Console.WriteLine(token.ToDebugString());
            }

            throw new Exception(sb.ToString());
        }

    }
}
