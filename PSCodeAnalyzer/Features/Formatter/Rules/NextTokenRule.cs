using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation.Language;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer
{
    [Export(typeof(IRule))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [ExportMetadata("Order", RulePriority.NextTokenRule)]
    class NextTokenRule : Rule
    {
        public override RuleAction Action
        {
            get { return RuleAction.InsertSpace; }
        }

        public override Result Execute(ScriptContext ctx)
        {
            if (ctx.IsEndOfLine)
                return FormatCodeRuleResult.NoIndent;

            var nextToken = ctx.NextToken;
            switch (nextToken.Kind)
            {
                case TokenKind.Comma:
                    return ctx.Options.InsertSpaceBeforeCommaDelimiter
                              ? FormatCodeRuleResult.Indent
                              : FormatCodeRuleResult.NoIndent;
                case TokenKind.DotDot:
                    return ctx.Options.InsertSpaceBeforeAndAfterRangeOperators
                              ? FormatCodeRuleResult.Indent
                              : FormatCodeRuleResult.NoIndent;
                case TokenKind.Semi:
                    return ctx.Options.InsertSpaceBeforeStatementSeparator
                              ? FormatCodeRuleResult.Indent
                              : FormatCodeRuleResult.NoIndent;
                case TokenKind.Pipe:
                    return ctx.Options.InsertSpaceBeforeAndAfterPipeline
                              ? FormatCodeRuleResult.Indent
                              : FormatCodeRuleResult.NoIndent;

                case TokenKind.RCurly:
                    return ctx.Options.InsertSpaceAfterOpeningAndBeforeClosingNonEmptyScriptBlockParenthesis
                              ? FormatCodeRuleResult.Indent
                              : FormatCodeRuleResult.NoIndent;
                case TokenKind.RParen:
                case TokenKind.RBracket:
                    return FormatCodeRuleResult.NoIndent;

                case TokenKind.Equals:
                case TokenKind.PlusEquals:
                case TokenKind.MinusEquals:
                case TokenKind.MultiplyEquals:
                case TokenKind.DivideEquals:
                case TokenKind.RemainderEquals:
                    if (ctx.IsParameterBlockContext())
                        return FormatCodeRuleResult.NoIndent; //TODO:Option

                    return ctx.Options.InsertSpaceBeforeAndAfterAssignmentOperators
                                ? FormatCodeRuleResult.Indent
                                : FormatCodeRuleResult.NoIndent;

                case TokenKind.Generic:
                case TokenKind.Identifier:
                    //No space needed if have flags MemberName/AttributeName/TypeName
                    return ctx.NextToken.HasFlag(TokenFlags.MemberName | TokenFlags.AttributeName | TokenFlags.TypeName)
                        ? FormatCodeRuleResult.NoIndent
                        : FormatCodeRuleResult.Indent;

                case TokenKind.Variable:
                case TokenKind.SplattedVariable:
                case TokenKind.Number:
                case TokenKind.Label:
                case TokenKind.LineContinuation:
                case TokenKind.StringExpandable:
                case TokenKind.StringLiteral:
                case TokenKind.HereStringExpandable:
                case TokenKind.HereStringLiteral:
                case TokenKind.DollarParen:
                case TokenKind.AtParen:
                case TokenKind.AtCurly:
                    return FormatCodeRuleResult.Indent;

                case TokenKind.In:
                case TokenKind.Redirection:
                case TokenKind.RedirectInStd:
                case TokenKind.Parameter:
                    return FormatCodeRuleResult.Indent;

                //Handled by PreProcessRule
                case TokenKind.Comment:
                    switch (ctx.PeekToken(2).Kind)
                    {
                        case TokenKind.NewLine:
                        case TokenKind.EndOfInput:
                            return FormatCodeRuleResult.Indent;
                        default:
                            //CommandMode parser require space before comment token
                            return ctx.HasTrailingSpaceAfterToken(ctx.NextToken)
                                ? FormatCodeRuleResult.Indent
                                : FormatCodeRuleResult.NoIndent;
                    }

                case TokenKind.Unknown:
                    return ctx.HasTrailingSpaceAfterToken(ctx.NextToken)
                        ? FormatCodeRuleResult.ForceIndent
                        : FormatCodeRuleResult.ForceNoIndent;

                case TokenKind.MinusMinus:
                    if (ctx.HasTrailingSpaceAfterToken(ctx.CurrentToken))
                        return FormatCodeRuleResult.Indent;

                    goto default;

                default:
                    if (ctx.NextToken.HasFlag(TokenFlags.Keyword))
                    {
                        return FormatCodeRuleResult.Indent;
                    }

                    if (ctx.NextToken.HasFlag(TokenFlags.BinaryOperator))
                    {
                        return ctx.Options.InsertSpaceBeforeAndAfterBinaryOperators
                                    ? FormatCodeRuleResult.Indent
                                    : FormatCodeRuleResult.NoIndent;
                    }

                    if (ctx.NextToken.HasFlag(TokenFlags.UnaryOperator))
                    {
                        return FormatCodeRuleResult.NoIndent;
                    }

                    break;
            }
            return FormatCodeRuleResult.Continue;
        }


    }
}
