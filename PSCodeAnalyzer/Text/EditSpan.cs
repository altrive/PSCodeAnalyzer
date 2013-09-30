using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;

namespace PSCodeAnalyzer
{
    internal class TextEdit //: ITextEdit
    {
        public enum EditType
        {
            None,
            Insert,
            Delete,
            Replace
        }

        public EditType Type
        {
            get
            {
                if (String.IsNullOrEmpty(Text))
                {
                    return EditType.Delete;
                }

                return Span.Length == 0
                    ? EditType.Insert
                    : EditType.Replace;
            }
        }

        public bool IsEmpty
        {
            get { return this.Span.Length == 0 && this.Text.Length == 0; }
        }



        public SnapshotSpan Span { get; private set; }

        public string Text { get; private set; }

        public TextEdit(SnapshotSpan span, string text)
        {
            this.Span = span;
            this.Text = text;
        }

        public TextEdit(ITextSnapshot snapshot, int position, int length, string text)
        {
            this.Span = new SnapshotSpan(snapshot, position, length);
            this.Text = text;
        }

        public static TextEdit CreateInsert(SnapshotPoint snapshotPoint, string text)
        {
            return new TextEdit(snapshotPoint.Snapshot, snapshotPoint.Position, 0, text);
        }

        public static TextEdit CreateDelete(SnapshotPoint snapshotPoint, int count)
        {
            return new TextEdit(snapshotPoint.Snapshot, snapshotPoint.Position, count, String.Empty);
        }

        public static TextEdit CreateEmpty(ITextSnapshot snapshot)
        {
            return new TextEdit(snapshot, 0, 0, String.Empty);
        }
    }
}
