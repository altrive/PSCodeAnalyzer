using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.Text;

namespace PSCodeAnalyzer.Tests
{
    public static class Utility
    {
        public static IEnumerable<LineComparison> CompareText(string actual, string expected)
        {
            int i = 0; //1 based line index
            using (var sr1 = new StringReader(actual))
            using (var sr2 = new StringReader(expected))
            {
                while (true)
                {
                    ++i;
                    var actualLine = sr1.ReadLine();
                    var expectedLine = sr2.ReadLine();

                    if (actualLine == null && expectedLine == null)
                        break;

                    yield return new LineComparison(i, actualLine, expectedLine);
                }
            }
        }

        public class LineComparison
        {
            public LineComparison(int i, string actualLine, string expecteLine)
            {
                // TODO: Complete member initialization
                this.LineNumber = i;
                this.Actual = actualLine;
                this.Expected = expecteLine;
            }

            public int LineNumber { get; private set; }
            public string Actual { get; private set; }
            public string Expected { get; private set; }

            /*
            public bool AssertLine(bool convertTab = true, int tabSpace = 4)
            {
                if (convertTab)
                {
                    return Actual == Expected;
                }
            }
            */

            public string GetErrorMessage(Token[] tokens)
            {
                if (Actual == Expected)
                    return String.Empty;

                var sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendFormat("Line {0} Mismatch:", LineNumber);
                sb.AppendLine();
                sb.AppendLine("Expected -> Actual");
                sb.AppendLine(Expected);
                sb.AppendLine(Actual);

                /*
                Console.WriteLine("Expected -> Actual");
                Console.WriteLine("-----------------------------");
                Console.WriteLine(Expected);
                Console.WriteLine(Actual);      
                Console.WriteLine("-----------------------------");
                
                 */
                //Write token informations(from prev line)
                foreach (var token in tokens)
                {
                    if (token.Extent.StartLineNumber < LineNumber - 1)
                        continue; //skip
                    if (LineNumber < token.Extent.StartLineNumber)
                        break; //stop

                    Console.WriteLine(token.ToDebugString());
                }

                return sb.ToString();
            }
        }

        public static void ShouldNotChanged(string content)
        {
            ShouldMatch(content, content);
        }

        public static void ShouldMatch(string content, string expected)
        {
            var contentType = EditorImports.ContentTypeRegistryService.GetContentType("code");
            var buffer = EditorImports.TextBufferFactoryService.CreateTextBuffer(content, contentType);
            var textView = EditorImports.TextEditorFactoryService.CreateTextView(buffer);

            //Arrange
            var analyzer = EditorImports.CodeAnalyzerFactory.Create(textView);

            //Act
            analyzer.FormatText();

            //Assert
            foreach (var line in Utility.CompareText(buffer.CurrentSnapshot.GetText(), expected))
            {
                line.Actual.Is(line.Expected, line.GetErrorMessage(analyzer.Tokens));
            }
        }

        public static string TestFormat(string content)
        {
            var contentType = EditorImports.ContentTypeRegistryService.GetContentType("code");
            var buffer = EditorImports.TextBufferFactoryService.CreateTextBuffer(content, contentType);
            var textView = EditorImports.TextEditorFactoryService.CreateTextView(buffer);
            // var undoManagerProvider = EditorImports.TextBufferUndoManagerProvider;

            var analyzer = EditorImports.CodeAnalyzerFactory.Create(textView);
            analyzer.FormatText();

            return buffer.CurrentSnapshot.GetText();
        }


        public static string TestFiles(string basePath, string directoryName, string downloadUrl)
        {
            const string ResultPath = @"..\..\FormatResults";
            var targetDir = Path.Combine(basePath, directoryName);

            if (!Directory.Exists(targetDir))
            {
                var message = "Test target folder isn't found. Download files from '{0}' and place files to '{1}'";
                Assert.Inconclusive(message, downloadUrl, targetDir);
            }

            //Need filtering by Linq. EnumerateFiles may return files that match 8.3 short name.(like .ps1xml)
            var psFiles = Directory.EnumerateFiles(targetDir, "*.ps1", SearchOption.AllDirectories)
                                 .Where(p => Path.GetExtension(p) == ".ps1");

            var psmFiles = Directory.EnumerateFiles(targetDir, "*.psm1", SearchOption.AllDirectories)
                                 .Where(p => Path.GetExtension(p) == ".psm1");

            var files = psFiles.Concat(psmFiles).ToArray();


            if (!files.Any())
            {
                var message = "Test target folder isn't contain items: {0}";
                Assert.Inconclusive(message, targetDir);
            }

            var outputBaseUri = new Uri(Path.GetFullPath(Path.Combine(ResultPath, directoryName)));

            foreach (var filePath in files)
            {
                string formattedResult = null;
                try
                {
                    var sw = Stopwatch.StartNew();
                    var content = File.ReadAllText(filePath);
                    formattedResult = Utility.TestFormat(content);
                    Console.WriteLine("Elapsed {0}[ms] : {1}", sw.ElapsedMilliseconds, filePath);
                }
                catch
                {
                    Console.WriteLine("Format error when processing file: " + filePath);
                    throw;
                }

                //Get relative path
                var baseUri = new Uri(Path.GetFullPath(targetDir));
                var relativeFilePath = baseUri.MakeRelativeUri(new Uri(Path.GetFullPath(filePath)));


                //Format result is stored under "FormatResults" directory
                var outFilePath = Path.Combine(ResultPath, relativeFilePath.ToString());

                //Ensure target directory exist
                // ReSharper disable once PossibleNullReferenceException
                (new FileInfo(outFilePath)).Directory.Create();

                //Write Formatted text to file
                File.WriteAllText(outFilePath, formattedResult);
            }

            {
                //Output showDiff.bat to execute diff command
                var diffLaunchBatPath = Path.Combine(ResultPath, directoryName, "showDiff.bat");
                var diffExePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"WinMerge\WinMergeU.exe");

                var diffCommand = String.Format("\"{0}\" {1} \"{2}\" \"{3}\"", diffExePath,
                    "/f \"*.ps1 *.psm1\" /r /e /s /ul /ur /wl /wr /dl BeforeFormat /dr AfterFormat",
                    Path.GetFullPath(targetDir), outputBaseUri.LocalPath);
                // ReSharper disable once PossibleNullReferenceException
                (new FileInfo(diffLaunchBatPath)).Directory.Create();
                File.WriteAllText(diffLaunchBatPath, diffCommand);
                return diffLaunchBatPath;
            }

        }

    }
}
