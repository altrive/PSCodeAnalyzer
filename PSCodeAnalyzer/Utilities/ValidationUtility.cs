using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer
{
    public static class ValidationUtility
    {
        public static void Validate(ScriptContext before, ScriptContext after)
        {
            //TODO:Handle NewLine token
            bool isSequenceMatch = before.Tokens.SequenceEqual(after.Tokens,
                token => new
                {
                    token.Kind,
                    token.TokenFlags,
                    token.Text
                });

            if (isSequenceMatch)
                return;

            //Token Sequence is not matched. throw exception.
            var diffToken = before.Tokens.Zip(after.Tokens, (first, second) => new { First = first, Second = second })
                .First(p => !p.First.IsSameToken(p.Second));


            var sb = new StringBuilder();
            sb.AppendLine("Format code operation failed! Please report following error context information");
            sb.AppendLine("---------------------------------------");
            sb.AppendLine("Line: Before -> After");
            sb.AppendLine(before.Text.GetLineText(diffToken.First.Extent.StartLineNumber));
            sb.AppendLine(after.Text.GetLineText(diffToken.Second.Extent.StartLineNumber));
            sb.AppendLine("---------------------------------------");

            //Write token informations
            var diffTokenLineNumber = diffToken.First.Extent.StartLineNumber;
            foreach (var token in before.Tokens)
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
