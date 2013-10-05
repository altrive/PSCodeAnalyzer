using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Management.Automation.Language;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer
{
    [Export(typeof(IRule))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [ExportMetadata("Order", RulePriority.CurrentTokenRule)]
    class CurrentTokenRule : Rule
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
                case TokenKind.Comma:
                    return ctx.Options.InsertSpaceAfterCommaDelimiter
                        ? FormatCodeRuleResult.Indent
                        : FormatCodeRuleResult.NoIndent;

                case TokenKind.Semi:
                    return ctx.Options.InsertSpaceAfterStatementSeparator
                        ? FormatCodeRuleResult.Indent
                        : FormatCodeRuleResult.NoIndent;

                case TokenKind.DotDot:
                    return ctx.Options.InsertSpaceBeforeAndAfterRangeOperators
                        ? FormatCodeRuleResult.Indent
                        : FormatCodeRuleResult.NoIndent;

                //Assignment Operators
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

                case TokenKind.Pipe:
                    return ctx.Options.InsertSpaceBeforeAndAfterPipeline
                        ? FormatCodeRuleResult.Indent
                        : FormatCodeRuleResult.NoIndent;

                //Keywords that is not require space after token
                case TokenKind.Begin:
                case TokenKind.Do:
                case TokenKind.Dynamicparam:
                case TokenKind.Else:
                case TokenKind.ElseIf:
                case TokenKind.End:
                case TokenKind.Finally:
                case TokenKind.For:
                case TokenKind.Foreach:
                case TokenKind.If:
                case TokenKind.InlineScript:
                case TokenKind.Parallel:
                case TokenKind.Param:
                case TokenKind.Process:
                case TokenKind.Sequence:
                case TokenKind.Switch:
                case TokenKind.Try:
                case TokenKind.Until:
                case TokenKind.While:
                    return ctx.Options.InsertSpaceAfterKeywordsInControlFlowStatements
                     ? FormatCodeRuleResult.Indent
                        : FormatCodeRuleResult.NoIndent;

                //Unary Operators
                case TokenKind.Not:
                case TokenKind.Bnot:
                    //TODO:Option
                    switch (ctx.NextToken.Kind)
                    {
                        case TokenKind.LParen:
                            return FormatCodeRuleResult.NoIndent;
                        default:
                            return FormatCodeRuleResult.Indent;
                    }

                case TokenKind.Parameter:
                    var token = (ParameterToken)ctx.CurrentToken;
                    return token.UsedColon
                        ? FormatCodeRuleResult.NoIndent
                        : FormatCodeRuleResult.Indent;
                case TokenKind.MinusMinus:
                    if (ctx.HasTrailingSpaceAfterToken(ctx.CurrentToken))
                        return FormatCodeRuleResult.Indent;
                    goto default;
                case TokenKind.Identifier:
                case TokenKind.Generic:

                    if (ctx.CurrentToken.HasFlag(TokenFlags.CommandName))
                    {
                        switch (ctx.NextToken.Kind)
                        {
                            case TokenKind.Semi:
                                return FormatCodeRuleResult.Continue;
                            default:
                                return FormatCodeRuleResult.Indent;
                        }

                    }

                    if (ctx.CurrentToken.HasFlag(TokenFlags.MemberName))
                    {
                        switch (ctx.NextToken.Kind)
                        {
                            case TokenKind.LParen:
                            case TokenKind.LCurly:
                                if (ctx.HasTrailingSpaceAfterToken(ctx.CurrentToken))
                                    return FormatCodeRuleResult.Indent;
                                break;
                        }
                    }
                    goto default;
                default:
                    if (ctx.CurrentToken.HasFlag(TokenFlags.BinaryOperator))
                    {
                        return ctx.Options.InsertSpaceBeforeAndAfterBinaryOperators
                                    ? FormatCodeRuleResult.Indent
                                    : FormatCodeRuleResult.NoIndent;
                    }

                    if (ctx.CurrentToken.HasFlag(TokenFlags.UnaryOperator))
                    {
                        switch (ctx.NextToken.Kind)
                        {
                            case TokenKind.Identifier:
                                //"!" need space before identifier(otherwise Tokenize result changed.)
                                return FormatCodeRuleResult.ForceIndent;
                            default:
                                //TODO:Option
                                if (!ctx.NextToken.HasFlag(TokenFlags.BinaryOperator))
                                    return FormatCodeRuleResult.NoIndent;
                                return FormatCodeRuleResult.Continue;
                        }
                    }
                    break;
            }

            return FormatCodeRuleResult.Continue;
        }
    }
}
