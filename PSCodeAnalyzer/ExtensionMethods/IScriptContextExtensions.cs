using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Text;

namespace PSCodeAnalyzer
{

    public static class IScriptContextExtensions
    {/*
        public static bool SetIndent(this IScriptContext ctx, Token token)
        {
            bool isCurrent = (ctx.CurrentToken == token);
            bool insertSpaceAfterToken;

            switch (token.Kind)
            {
                case TokenKind.Dot:
                case TokenKind.ColonColon:
                    insertSpaceAfterToken = false;
                    break;
                case TokenKind.Comma:
                    insertSpaceAfterToken = isCurrent
                        ? ctx.Options.InsertSpaceAfterCommaDelimiter
                        : ctx.Options.InsertSpaceBeforeCommaDelimiter;
                    break;
                case TokenKind.Semi:
                    insertSpaceAfterToken = isCurrent
                       ? ctx.Options.InsertSpaceAfterCommaDelimiter
                       : ctx.Options.InsertSpaceBeforeCommaDelimiter;
                    break;

                case TokenKind.DotDot:
                    insertSpaceAfterToken = ctx.Options.InsertSpaceBeforeAndAfterRangeOperators;
                    break;


                case TokenKind.Pipe:
                    insertSpaceAfterToken = ctx.Options.InsertSpaceBeforeAndAfterPipeline;
                    break;
                //Keywords that is not require space after token
                case TokenKind.Begin:
                case TokenKind.Data:
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
                case TokenKind.Switch:
                case TokenKind.Trap:
                case TokenKind.Try:
                case TokenKind.Until:
                case TokenKind.While:
                    //TODO:Option
                    insertSpaceAfterToken = false;
                    break;

                case TokenKind.RParen:
                case TokenKind.RCurly:
                case TokenKind.RBracket:
                    insertSpaceAfterToken = false;
                    break;

                case TokenKind.Generic:
                case TokenKind.Identifier:
                    {
                        //No space needed if have flags MemberName/AttributeName/TypeName
                        if (ctx.NextToken.HasFlag(TokenFlags.MemberName | TokenFlags.AttributeName | TokenFlags.TypeName))
                        {
                            insertSpaceAfterToken = false;
                            break;
                        }

                        insertSpaceAfterToken = true;
                        break;

                    }
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
                    insertSpaceAfterToken = true;
                    break;
                case TokenKind.In:
                case TokenKind.Redirection:
                case TokenKind.RedirectInStd:
                case TokenKind.Parameter:
                    insertSpaceAfterToken = true;
                    break;
                case TokenKind.Comment:
                    switch (ctx.PeekToken(2).Kind)
                    {
                        case TokenKind.NewLine:
                        case TokenKind.EndOfInput:
                            insertSpaceAfterToken = true;
                            break;
                        default:
                            insertSpaceAfterToken = false;
                            break;
                    }
                    break;
                case TokenKind.Unknown:
                    insertSpaceAfterToken = ctx.HasTrailingSpaceAfterToken(token);
                    break;
                default:
                    if (!isCurrent)
                    {
                        if (ctx.NextToken.HasFlag(TokenFlags.Keyword))
                        {
                            insertSpaceAfterToken = true;
                            break;
                        }
                        if (ctx.NextToken.HasFlag(TokenFlags.BinaryOperator))
                        {
                            insertSpaceAfterToken = ctx.Options.InsertSpaceBeforeAndAfterBinaryOperators;
                            break;
                        }

                        if (ctx.NextToken.HasFlag(TokenFlags.UnaryOperator))
                        {
                            insertSpaceAfterToken = false;
                        }
                    }
                    insertSpaceAfterToken = false;
                    break;
            }

            return insertSpaceAfterToken
                       ? ctx.SetIndentNextToken()
                       : ctx.SetNoIndentNextToken();
        }
*/
    }
}