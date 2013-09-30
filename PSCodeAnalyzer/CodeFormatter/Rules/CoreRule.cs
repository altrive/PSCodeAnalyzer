using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Management.Automation.Runspaces;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer.CodeFormatter.Rules
{
    [Export(typeof(IRule))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [ExportMetadata("Order", RulePriority.CoreRule)]
    class CoreRule : Rule
    {
        public override RuleAction Action
        {
            get { return RuleAction.InsertSpace; }
        }

        // private readonly TokenFlags UnaryFlag = TokenFlags.UnaryOperator

        public override bool Execute(IScriptContext ctx)
        {
            if (ctx.IsEndOfLine)
                return ctx.SetNoIndentNextToken();

            var token = ctx.CurrentToken;
            switch (token.Kind)
            {
                case TokenKind.RParen:
                case TokenKind.RCurly:
                case TokenKind.RBracket:
                    var nextToken = ctx.NextToken;
                    switch (nextToken.Kind)
                    {
                        case TokenKind.Dot:
                        case TokenKind.ColonColon:
                            return ctx.SetNoIndentNextToken(force: true); //can't contain spaces.
                        default:
                            return false;
                    }

                case TokenKind.Label:
                    return ctx.SetIndentNextToken(force: true);

                case TokenKind.ColonColon:
                    return ctx.SetNoIndentNextToken(force: true);

                case TokenKind.Dot:
                    //For dot-souce or member-access/invocation-expression expression
                    return ctx.HasTrailingSpaceAfterToken(ctx.CurrentToken)
                                ? ctx.SetIndentNextToken(force: true)
                                : ctx.SetNoIndentNextToken(force: true);

                //Keywords that require space after token
                case TokenKind.Break:
                case TokenKind.Catch:
                case TokenKind.Continue:
                case TokenKind.Data:
                case TokenKind.Exit:
                case TokenKind.Filter:
                case TokenKind.From:  //ReservedKeyword   
                case TokenKind.Function:
                case TokenKind.In:
                case TokenKind.Trap:
                case TokenKind.Return:
                case TokenKind.Throw:
                case TokenKind.Configuration: //PSv4 Keyword
                case TokenKind.DynamicKeyword: //PSv4 Keyword
                case TokenKind.Class: //ReservedKeyword
                case TokenKind.Define: //ReservedKeyword
                case TokenKind.Using: //ReservedKeyword
                case TokenKind.Var:   //ReservedKeyword
                case TokenKind.Workflow:
                //Redirection Operator
                case TokenKind.Redirection:
                case TokenKind.RedirectInStd:
                    return ctx.SetIndentNextToken(force: true);

                case TokenKind.MinusMinus:
                    if (ctx.NextToken.Kind == TokenKind.Parameter)
                    {
                        //MinusMinus operator for CommandParameter
                        return ctx.SetIndentNextToken(force: true);
                    }
                    return false;


                case TokenKind.Unknown:
                    return ctx.HasTrailingSpaceAfterToken(ctx.NextToken)
                        ? ctx.SetIndentNextToken(force: true)
                        : ctx.SetNoIndentNextToken(force: true);
                default:
                    return false;
            }
        }

    }
}
