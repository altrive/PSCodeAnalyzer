using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer
{
    public class FormatCodeOptions
    {
        public string IndentString
        {
            get { return "    "; }
        }

        private static FormatCodeOptions _current;

        public static FormatCodeOptions Current
        {
            get
            {
                if (_current == null)
                    _current = Default;
                return _current;
            }

        }

        public static FormatCodeOptions Default
        {
            get { return new FormatCodeOptions(); }
        }

        /*
        #region General
        public bool AutoFormatOnSemicolon = true;
        public bool AutoFormatOnRCurly = true;
        public bool AutoFormatOnPaste = true;
        #endregion

        #region Indent
        public bool IndentBlockContent = true;
        public bool IndentOnBraces = false;
        #endregion
        */

        public string NewLineCharacter = "\r\n";
        public bool ConvertTabsToSpaces = true;

        public bool InsertSpaceBeforeCommaDelimiter = false;
        public bool InsertSpaceAfterCommaDelimiter = true;
        public bool InsertSpaceAfterSemicolonInForStatements = true;
        public bool InsertSpaceBeforeAndAfterBinaryOperators = true;
        public bool InsertSpaceAfterKeywordsInControlFlowStatements = true;
        public bool InsertSpaceAfterFunctionKeywordForAnonymousFunctions;
        public bool InsertSpaceAfterOpeningAndBeforeClosingNonEmptyScriptBlockParenthesis = true;
        public bool PlaceOpenBraceOnNewLineForFunctions;
        public bool PlaceOpenBraceOnNewLineForControlBlocks;
        public bool InsertSpaceBeforeAndAfterAssignmentOperators = true;

        public bool InsertSpaceBeforeAndAfterRangeOperators = false;
        public bool InsertSpaceBeforeAndAfterPipeline = true;
        public bool InsertSpaceBeforeStatementSeparator = false;
        public bool InsertSpaceAfterStatementSeparator = true;

        public bool InsertSpaceAfterCastOperator = true;

        public bool InsertSpaceAfterVariableType = true;


    }
}
