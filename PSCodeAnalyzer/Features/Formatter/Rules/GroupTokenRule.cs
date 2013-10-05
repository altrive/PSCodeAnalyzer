using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Management.Automation.Language;
using System.Text;
using System.Threading.Tasks;
using Microsoft.PowerShell.Commands;

namespace PSCodeAnalyzer
{
    [Export(typeof(IRule))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [ExportMetadata("Order", RulePriority.GroupTokenRule)]
    class GroupTokenRule : Rule
    {
        public override RuleAction Action
        {
            get { return RuleAction.InsertSpace; }
        }

        public override Result Execute(ScriptContext ctx)
        {
            if (ctx.IsEndOfLine)
                return FormatCodeRuleResult.NoIndent;

            switch (ctx.CurrentToken.Kind)
            {
                case TokenKind.LCurly:
                case TokenKind.AtCurly:
                    switch (ctx.NextToken.Kind)
                    {
                        case TokenKind.LParen:
                        case TokenKind.LBracket:
                        case TokenKind.LCurly:
                        case TokenKind.RCurly: //Empty GroupBlock
                            return FormatCodeRuleResult.NoIndent;
                        default:
                            return ctx.Options.InsertSpaceAfterOpeningAndBeforeClosingNonEmptyScriptBlockParenthesis
                                ? FormatCodeRuleResult.Indent
                                : FormatCodeRuleResult.NoIndent;
                    }

                case TokenKind.LParen:
                case TokenKind.AtParen:
                case TokenKind.DollarParen:
                    return FormatCodeRuleResult.NoIndent;

                case TokenKind.RParen:
                case TokenKind.RCurly:
                    switch (ctx.NextToken.Kind)
                    {
                        case TokenKind.Semi:
                        case TokenKind.Comma:
                        //case TokenKind.LParen: //insert space between (exp) (exp)
                        case TokenKind.LCurly:
                        case TokenKind.RParen:
                        case TokenKind.RCurly:
                        case TokenKind.LBracket:
                        case TokenKind.RBracket:
                            return FormatCodeRuleResult.NoIndent;
                        default:
                            //TODO:Option
                            return FormatCodeRuleResult.Indent;
                    }
                case TokenKind.LBracket:
                    return FormatCodeRuleResult.NoIndent;

                case TokenKind.RBracket:
                    switch (ctx.NextToken.Kind)
                    {
                        case TokenKind.Semi:
                        case TokenKind.Comma:
                        case TokenKind.LBracket:
                        case TokenKind.LCurly:
                        case TokenKind.LParen:
                        case TokenKind.RCurly:
                        case TokenKind.RParen:
                        case TokenKind.RBracket:
                        case TokenKind.DotDot:
                            //case TokenKind.Dot: //Handled by CoreRule
                            //case TokenKind.ColonColon://Handled by CoreRule
                            return FormatCodeRuleResult.NoIndent; //TODO:Option 

                        case TokenKind.Variable:
                            return ctx.Options.InsertSpaceAfterVariableType
                               ? FormatCodeRuleResult.Indent
                               : FormatCodeRuleResult.NoIndent;
                        default:
                            if (ctx.NextToken.HasFlag(TokenFlags.Keyword))
                            {
                                return FormatCodeRuleResult.Indent;
                            }

                            //Cast operatore?
                            return ctx.Options.InsertSpaceAfterCastOperator
                                ? FormatCodeRuleResult.Indent
                                : FormatCodeRuleResult.NoIndent;
                    }
            }

            //Need to apply before CurrentTokenRule
            var nextToken = ctx.NextToken;
            switch (nextToken.Kind)
            {
                case TokenKind.RCurly:
                    return ctx.Options.InsertSpaceAfterOpeningAndBeforeClosingNonEmptyScriptBlockParenthesis
                                ? FormatCodeRuleResult.Indent
                                : FormatCodeRuleResult.NoIndent;
                case TokenKind.RParen:
                case TokenKind.RBracket:
                    return FormatCodeRuleResult.NoIndent;
            }

            return FormatCodeRuleResult.Continue;
        }
    }
}
