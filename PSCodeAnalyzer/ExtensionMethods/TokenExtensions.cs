using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Text;

namespace PSCodeAnalyzer
{
    public static class TokenExtensions
    {
        public static PSTokenType GetPSTokenType(this Token token)
        {
            return PSToken.GetPSTokenType(token);
        }

        public static bool HasFlag(this Token token, TokenFlags flag)
        {
            return (token.TokenFlags & flag) > 0;
        }


        public static bool IsSameToken(this Token actual, Token expected)
        {

            if (actual.Kind != expected.Kind)
            {
                return false;
            }
            if (actual.TokenFlags != expected.TokenFlags)
                return false;
            if (actual.Text != expected.Text)
                return false;

            return true;
        }

        public static string ToDebugString(this Token token)
        {
            //Replace NewLine Char
            var text = token.Text.Replace("\r\n", @"\r\n").Replace("\n", @"\n");
            return String.Format("{0,-20} : {1,-30} : {2,-20} : {3}", token.Kind, token.TokenFlags,
                PSToken.GetPSTokenType(token), text);
        }
    }

   
}