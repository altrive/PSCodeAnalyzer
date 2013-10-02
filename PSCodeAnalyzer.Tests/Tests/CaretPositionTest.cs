using System;
using System.Management.Automation.Language;
using System.Net.Mime;
using Microsoft.SqlServer.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.Text;

namespace PSCodeAnalyzer.Tests
{
    [TestClass]
    public class CaretPositionTest
    {
        [TestMethod]
        public void Caret_EndOfText()
        {
            var content = "aaa                 ";
            var expected = "aaa";
            Utility.ShouldMatch(content, expected);
        }

        [TestMethod]
        public void CaretPosition()
        {

            const string content = "$i   =    0     #This is a comment"; //add space before line comment


            var contentType = EditorImports.ContentTypeRegistryService.GetContentType("code");
            var buffer = EditorImports.TextBufferFactoryService.CreateTextBuffer(content, contentType);
            var textView = EditorImports.TextEditorFactoryService.CreateTextView(buffer);

            var formatter = EditorImports.CodeAnalyzerFactory.Create(textView);

            {
                var caretPos = content.IndexOf("=");

                textView.Caret.MoveTo(new SnapshotPoint(textView.TextSnapshot, caretPos));

                formatter.FormatText();

                int i = textView.Caret.Position.BufferPosition.Position;

                buffer.CurrentSnapshot[i].Is('=');
            }
            /*
            {
                var caretPos = new ScriptPosition("", 1, content.IndexOf("is") + 1, content);
                var result = formatter.FormatText();

                result[formatter.CaretOffSet].Is('i');
            }*/
        }
        /*
        [TestMethod]
        public void CaretPosition_MultiLine()
        {
            const string content = @"
function Test
{
    param(
        [string] $p1
    )
Write-Host 'abc'
}
";


            var contentType = EditorImports.ContentTypeRegistryService.GetContentType("code");
            var buffer = EditorImports.TextBufferFactoryService.CreateTextBuffer(content, contentType);


            var formatter = new CodeAnalyzer(buffer, new FormatCodeOptions());

            {
                var keyword = "H";
                var caretPos = new ScriptPosition("", 7, content.GetLineText(7).IndexOf(keyword)+1, content);
                var result = formatter.FormatText(caretPos);

                result.Substring(formatter.CaretOffSet, keyword.Length).Is(keyword);
            }
            {
                var keyword = "p1";
                var caretPos = new ScriptPosition("", 5, content.GetLineText(5).IndexOf(keyword) + 1, content);
                var result = formatter.FormatText(caretPos);

                result.Substring(formatter.CaretOffSet, keyword.Length).Is(keyword);
            }


        }*/
    }
}
