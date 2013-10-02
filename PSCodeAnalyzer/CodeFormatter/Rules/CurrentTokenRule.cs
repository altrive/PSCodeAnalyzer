using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Management.Automation.Language;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer.CodeFormatter.Rules
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

        public override bool Execute(IScriptContext ctx)
        {
            if (ctx.IsEndOfLine)
                return ctx.SetNoIndentNextToken();

            switch (ctx.CurrentToken.Kind)
            {
                case TokenKind.Comma:
                    return ctx.Options.InsertSpaceAfterCommaDelimiter
                        ? ctx.SetIndentNextToken()
                        : ctx.SetNoIndentNextToken();

                case TokenKind.Semi:
                    return ctx.Options.InsertSpaceAfterStatementSeparator
                        ? ctx.SetIndentNextToken()
                        : ctx.SetNoIndentNextToken();

                case TokenKind.DotDot:
                    return ctx.Options.InsertSpaceBeforeAndAfterRangeOperators
                        ? ctx.SetIndentNextToken()
                        : ctx.SetNoIndentNextToken();

                //Assignment Operators
                case TokenKind.Equals:
                case TokenKind.PlusEquals:
                case TokenKind.MinusEquals:
                case TokenKind.MultiplyEquals:
                case TokenKind.DivideEquals:
                case TokenKind.RemainderEquals:
                    if (ctx.IsParameterBlockContext())
                        return ctx.SetNoIndentNextToken(); //TODO:Option
                    return ctx.Options.InsertSpaceBeforeAndAfterAssignmentOperators
                                ? ctx.SetIndentNextToken()
                                : ctx.SetNoIndentNextToken();

                case TokenKind.Pipe:
                    return ctx.Options.InsertSpaceBeforeAndAfterPipeline
                        ? ctx.SetIndentNextToken()
                        : ctx.SetNoIndentNextToken();

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
                     ? ctx.SetIndentNextToken()
                     : ctx.SetNoIndentNextToken();

                //Unary Operators
                case TokenKind.Not:
                case TokenKind.Bnot:
                    //TODO:Option
                    switch (ctx.NextToken.Kind)
                    {
                        case TokenKind.LParen:
                            return ctx.SetNoIndentNextToken();
                        default:
                            return ctx.SetIndentNextToken();
                    }

                case TokenKind.Parameter:
                    var token = (ParameterToken)ctx.CurrentToken;
                    if (token.UsedColon)
                        return ctx.SetNoIndentNextToken();
                    return ctx.SetIndentNextToken();
                case TokenKind.MinusMinus:
                    if (ctx.HasTrailingSpaceAfterToken(ctx.CurrentToken))
                        return ctx.SetIndentNextToken();
                    goto default;
                case TokenKind.Identifier:
                case TokenKind.Generic:

                    if (ctx.CurrentToken.HasFlag(TokenFlags.CommandName))
                    {
                        switch (ctx.NextToken.Kind)
                        {
                            case TokenKind.Semi:
                                return false;
                            default:
                                return ctx.SetIndentNextToken();
                        }

                    }

                    if (ctx.CurrentToken.HasFlag(TokenFlags.MemberName))
                    {
                        switch (ctx.NextToken.Kind)
                        {
                            case TokenKind.LParen:
                            case TokenKind.LCurly:
                                if (ctx.HasTrailingSpaceAfterToken(ctx.CurrentToken))
                                    return ctx.SetIndentNextToken();
                                break;
                        }
                    }
                    goto default;
                default:
                    if (ctx.CurrentToken.HasFlag(TokenFlags.BinaryOperator))
                    {
                        return ctx.Options.InsertSpaceBeforeAndAfterBinaryOperators
                                    ? ctx.SetIndentNextToken()
                                    : ctx.SetNoIndentNextToken();
                    }

                    if (ctx.CurrentToken.HasFlag(TokenFlags.UnaryOperator))
                    {
                        //if (ctx.CurrentToken.Text == "!" && ctx.HasTrailingSpaceAfterToken(ctx.CurrentToken))
                        {
                            switch (ctx.NextToken.Kind)
                            {
                                case TokenKind.Identifier:
                                    //"!" need space before identifier(otherwise Tokenize result changed.)
                                    return ctx.SetIndentNextToken();
                                default:
                                    //TODO:Option
                                    if (!ctx.NextToken.HasFlag(TokenFlags.BinaryOperator))
                                        return ctx.SetNoIndentNextToken();
                                    break;
                            }
                        }
                    }
                    break;
            }



            return false;
        }
    }
}
