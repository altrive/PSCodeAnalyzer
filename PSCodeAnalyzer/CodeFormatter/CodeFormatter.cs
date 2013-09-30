using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Management.Automation.Language;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Differencing;
using Microsoft.VisualStudio.Text.Editor;

namespace PSCodeAnalyzer.CodeFormatter
{
    public class CodeFormatter
    {
        private FormatCodeOptions _options;

        public CodeFormatter(FormatCodeOptions options)
        {
            this._options = options;
        }

        internal void FormatCode(ITextView textView, ITextBuffer textBuffer, ScriptContext context)
        {
            var editList = new List<TextEdit>();

            var rules = new FormatCodeRules();

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
                    var indent = context.GetIndentForCurrentLine();
                    var lineStartOffSet = textBuffer.CurrentSnapshot.GetLineFromPosition(token.Extent.StartOffset).Start;
                    var indentSpan = new SnapshotSpan(textBuffer.CurrentSnapshot, Span.FromBounds(lineStartOffSet, token.Extent.StartOffset));
                    var spaceEdit = new TextEdit(indentSpan, indent);
                    if (!spaceEdit.IsEmpty)
                    {
                        editList.Add(spaceEdit);
                    }
                }

                //Add/Remove space after token
                var action = rules.Process(context);
                var nextToken = context.NextToken;
                var startIndex = token.Extent.EndOffset;
                var endIndex = Math.Min(nextToken.Extent.StartOffset, textBuffer.CurrentSnapshot.Length);
                var nextTokenSpan = new SnapshotSpan(textBuffer.CurrentSnapshot, Span.FromBounds(startIndex, endIndex));

                if (action == RuleAction.InsertSpace)
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

            using (var transaction = Context.TextBufferUndoManagerProvider.GetTextBufferUndoManager(textBuffer).TextBufferUndoHistory.CreateTransaction("Format Document"))
            {
                this.ApplyEdits(textBuffer, editList, textView);
                context.Validate(textBuffer.CurrentSnapshot.GetText());
                transaction.Complete();
            }
        }


        private void ApplyEdits(ITextBuffer buffer, IEnumerable<TextEdit> edits, ITextView textView)
        {
            using (var edit = buffer.CreateEdit())
            {
                Contract.Assert(buffer == edit.Snapshot.TextBuffer);
                foreach (var textEdit in edits)
                {
                    Contract.Assert(textEdit.IsEmpty != true);
                    Contract.Assert(textEdit.Span.End <= buffer.CurrentSnapshot.Length);

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
                    /*
                    System.Windows.Application.Current.Dispatcher.BeginInvoke(
                        new Action(() => textView.Caret.ContainingTextViewLine.
                    );
                    */
                }
            }
        }

    }
}
