using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Management.Automation.Language;
using System.Text;
using System.Threading.Tasks;
using Microsoft.PowerShell.Commands;

namespace PSCodeAnalyzer.CodeFormatter.Rules
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

        public override bool Execute(IScriptContext ctx)
        {
            if (ctx.IsEndOfLine)
            {
                return false;
            }


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
                            return ctx.SetNoIndentNextToken();
                        default:
                            return ctx.Options.InsertSpaceAfterOpeningAndBeforeClosingNonEmptyScriptBlockParenthesis
                                ? ctx.SetIndentNextToken()
                                : ctx.SetNoIndentNextToken();
                    }

                case TokenKind.LParen:
                case TokenKind.AtParen:
                case TokenKind.DollarParen:
                    return ctx.SetNoIndentNextToken();

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
                            return ctx.SetNoIndentNextToken();
                        default:
                            //TODO:Option
                            return ctx.SetIndentNextToken();
                    }
                case TokenKind.LBracket:
                    return ctx.SetNoIndentNextToken();

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
                            return ctx.SetNoIndentNextToken(); //TODO:Option 

                        case TokenKind.Variable:
                            return ctx.Options.InsertSpaceAfterVariableType
                               ? ctx.SetIndentNextToken()
                               : ctx.SetNoIndentNextToken();
                        default:
                            if (ctx.NextToken.HasFlag(TokenFlags.Keyword))
                            {
                                return ctx.SetIndentNextToken();
                            }

                            //Cast operatore?
                            return ctx.Options.InsertSpaceAfterCastOperator
                                ? ctx.SetIndentNextToken()
                                : ctx.SetNoIndentNextToken();
                    }
                default:
                    break;
            }

            //Need to apply before CurrentTokenRule
            var nextToken = ctx.NextToken;
            switch (nextToken.Kind)
            {
                case TokenKind.RCurly:
                    return ctx.Options.InsertSpaceAfterOpeningAndBeforeClosingNonEmptyScriptBlockParenthesis
                               ? ctx.SetIndentNextToken()
                               : ctx.SetNoIndentNextToken();
                case TokenKind.RParen:
                case TokenKind.RBracket:
                    return ctx.SetNoIndentNextToken();
            }

            return false;
        }
    }
}
