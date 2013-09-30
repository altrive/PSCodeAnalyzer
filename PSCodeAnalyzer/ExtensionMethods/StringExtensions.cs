using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer
{
    public static class StringExtensions
    {
        public static string GetLineText(this string text, int lineNumber)
        {
            using (var reader = new StringReader(text))
            {
                int i = 1;

                while (i <= lineNumber)
                {
                    var lineText = reader.ReadLine();

                    if (i == lineNumber)
                        return lineText;

                    if (lineText == null)
                        break; //EndOfStream

                    ++i;
                }
            }
            return null;
        }



    }
}
