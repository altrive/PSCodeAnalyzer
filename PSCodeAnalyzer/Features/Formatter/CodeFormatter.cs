using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Differencing;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using PSCodeAnalyzer;

namespace PSCodeAnalyzer
{
    public class CodeFormatter
    {
        private readonly FormatCodeOptions _options;
        private readonly ITextBuffer _textBuffer;

        private ScriptContext _context = null;

        public CodeFormatter(FormatCodeOptions options, ITextBuffer textBuffer)
        {
            _options = options;
            _textBuffer = textBuffer;
        }

        public Result FormatCode(CodeAnalyzer.Result analyzedResut)
        {
            var editList = new List<TextEdit>();

            var textSnapshot = analyzedResut.TextSnapshot;
            var context = _context = analyzedResut.Context;

            while (true)
            {
                var token = context.Next();

                if (token.Kind == TokenKind.EndOfInput)
                    break;

                if (token.Kind == TokenKind.NewLine)
                {
                    continue;
                }

                //Add indent at start of line
                if (context.IsStartOfLine)
                {
                    var indentLevel = context.GetIndentLevel();
                    var lineStartOffSet = textSnapshot.GetLineFromPosition(token.Extent.StartOffset).Start;
                    var indentSpan = new SnapshotSpan(textSnapshot, Span.FromBounds(lineStartOffSet, token.Extent.StartOffset));
                    var spaceEdit = new TextEdit(indentSpan, GetIndentText(indentLevel));
                    if (!spaceEdit.IsEmpty)
                    {
                        editList.Add(spaceEdit);
                    }
                }

                //Add/Remove space after token
                var ruleAction = FormatCodeRules.Default.ApplyRule(context);
                var nextToken = context.NextToken;
                var startIndex = token.Extent.EndOffset;
                var endIndex = Math.Min(nextToken.Extent.StartOffset, textSnapshot.Length);
                var nextTokenSpan = new SnapshotSpan(textSnapshot, Span.FromBounds(startIndex, endIndex));

                if (ruleAction == RuleAction.InsertSpace)
                {
                    //Insert space between token
                    var spaceEdit = new TextEdit(nextTokenSpan, " ");
                    editList.Add(spaceEdit);
                }
                else
                {
                    //Remove extra spaces
                    if (nextTokenSpan.IsEmpty)
                        continue;
                    var spaceEdit = new TextEdit(nextTokenSpan, "");
                    editList.Add(spaceEdit);
                }
            }

            return new Result
            {
                Context = _context,
                EditList = editList.ToArray(),
                TextBuffer = _textBuffer,
                TextSnapshot = textSnapshot,
            };
        }

        public string GetIndentText(int level)
        {
            if (level == 0)
                return String.Empty;

            //Return indent string
            var sb = new StringBuilder();
            for (var i = 0; i < level; ++i)
            {
                //TODO:Option
                sb.Append(_options.IndentString);
            }
            return sb.ToString();
        }


        public class Result
        {
            public ITextBuffer TextBuffer { get; internal set; }
            public ITextSnapshot TextSnapshot { get; internal set; }


            public IEnumerable<TextEdit> EditList { get; internal set; }
            public ScriptContext Context { get; internal set; }


            public bool Commit(ITextBufferUndoManagerProvider undoManagerProvider)
            {
                const string transactionName = "Format Document";
                if (!TextBuffer.CheckEditAccess())
                    return false;

                using (var transaction = undoManagerProvider.GetTextBufferUndoManager(TextBuffer).TextBufferUndoHistory.CreateTransaction(transactionName))
                {
                    ApplyEdits();
                    ValidationUtility.Validate(this.Context, ScriptContext.Parse(TextBuffer.CurrentSnapshot.GetText()));
                    transaction.Complete();
                }
                return true;
            }

            private void ApplyEdits()
            {
                using (var edit = TextBuffer.CreateEdit())
                {
                    Contract.Assert(TextBuffer == edit.Snapshot.TextBuffer);
                    foreach (var textEdit in EditList)
                    {
                        Contract.Assert(textEdit.IsEmpty != true);
                        Contract.Assert(textEdit.Span.End <= TextBuffer.CurrentSnapshot.Length);

                        switch (textEdit.Type)
                        {
                            case TextEdit.EditType.Insert:
                                edit.Insert(textEdit.Span.Start, textEdit.Text);
                                break;
                            case TextEdit.EditType.Delete:
                                edit.Delete(textEdit.Span);
                                break;
                            case TextEdit.EditType.Replace:
                                edit.Replace(textEdit.Span, textEdit.Text);
                                break;
                        }
                    }

                    if (edit.HasEffectiveChanges && !edit.HasFailedChanges)
                    {
                        edit.Apply();
                    }
                }
            }
        }

    }
}
