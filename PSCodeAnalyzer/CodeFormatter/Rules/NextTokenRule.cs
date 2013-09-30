using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation.Language;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer.CodeFormatter.Rules
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

        public override bool Execute(IScriptContext ctx)
        {
            if (ctx.IsEndOfLine)
                return ctx.SetNoIndentNextToken();

            var nextToken = ctx.NextToken;
            switch (nextToken.Kind)
            {
                case TokenKind.Comma:
                    return ctx.Options.InsertSpaceBeforeCommaDelimiter
                         ? ctx.SetIndentNextToken()
                         : ctx.SetNoIndentNextToken();
                case TokenKind.DotDot:
                    return ctx.Options.InsertSpaceBeforeAndAfterRangeOperators
                               ? ctx.SetIndentNextToken()
                               : ctx.SetNoIndentNextToken();
                case TokenKind.Semi:
                    return ctx.Options.InsertSpaceBeforeStatementSeparator
                              ? ctx.SetIndentNextToken()
                              : ctx.SetNoIndentNextToken();
                case TokenKind.Pipe:
                    return ctx.Options.InsertSpaceBeforeAndAfterPipeline
                              ? ctx.SetIndentNextToken()
                              : ctx.SetNoIndentNextToken();

                case TokenKind.RCurly:
                    return ctx.Options.InsertSpaceAfterOpeningAndBeforeClosingNonEmptyScriptBlockParenthesis
                               ? ctx.SetIndentNextToken()
                               : ctx.SetNoIndentNextToken();
                case TokenKind.RParen:
                case TokenKind.RBracket:
                    return ctx.SetNoIndentNextToken();

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

                case TokenKind.Generic:
                case TokenKind.Identifier:
                    //No space needed if have flags MemberName/AttributeName/TypeName
                    return ctx.NextToken.HasFlag(TokenFlags.MemberName | TokenFlags.AttributeName | TokenFlags.TypeName) 
                        ? ctx.SetNoIndentNextToken() 
                        : ctx.SetIndentNextToken();

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
                    return ctx.SetIndentNextToken();

                case TokenKind.In:
                case TokenKind.Redirection:
                case TokenKind.RedirectInStd:
                case TokenKind.Parameter:
                    return ctx.SetIndentNextToken();
                /*
            case TokenKind.Join:
            case TokenKind.Csplit:
            case TokenKind.Isplit:
                ctx.SetIndentNextToken(force: true);
                return true;
             */
                case TokenKind.Comment:
                    switch (ctx.PeekToken(2).Kind)
                    {
                        case TokenKind.NewLine:
                        case TokenKind.EndOfInput:
                            return ctx.SetIndentNextToken();
                        default:
                            return ctx.SetIndentNextToken(); //CommandMode parser require space before comment token
                    }

                case TokenKind.Unknown:
                    return ctx.HasTrailingSpaceAfterToken(ctx.NextToken)
                        ? ctx.SetIndentNextToken(force: true)
                        : ctx.SetNoIndentNextToken(force: true);

                case TokenKind.MinusMinus:
                    if (ctx.HasTrailingSpaceAfterToken(ctx.CurrentToken))
                        return ctx.SetIndentNextToken();

                    goto default;

                default:
                    if (ctx.NextToken.HasFlag(TokenFlags.Keyword))
                    {
                        return ctx.SetIndentNextToken();
                    }

                    if (ctx.NextToken.HasFlag(TokenFlags.BinaryOperator))
                    {
                        return ctx.Options.InsertSpaceBeforeAndAfterBinaryOperators
                                    ? ctx.SetIndentNextToken()
                                    : ctx.SetNoIndentNextToken();
                    }

                    if (ctx.NextToken.HasFlag(TokenFlags.UnaryOperator))
                    {
                        return ctx.SetNoIndentNextToken();
                    }

                    break;
            }
            return false;
        }


    }
}
