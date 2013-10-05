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

namespace PSCodeAnalyzer
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

        public override Result Execute(ScriptContext ctx)
        {
            if (ctx.IsEndOfLine)
                return FormatCodeRuleResult.NoIndent;

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
                            return FormatCodeRuleResult.ForceNoIndent; //can't contain spaces.
                        default:
                            return FormatCodeRuleResult.Continue;
                    }

                case TokenKind.Label:
                    return FormatCodeRuleResult.ForceIndent;

                case TokenKind.ColonColon:
                    return FormatCodeRuleResult.ForceNoIndent;

                case TokenKind.Dot:
                    //For dot-souce or member-access/invocation-expression expression
                    return ctx.HasTrailingSpaceAfterToken(ctx.CurrentToken)
                                ? FormatCodeRuleResult.ForceIndent
                                : FormatCodeRuleResult.ForceNoIndent;

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
                    return FormatCodeRuleResult.ForceIndent;

                case TokenKind.MinusMinus:
                    if (ctx.NextToken.Kind == TokenKind.Parameter)
                    {
                        //MinusMinus operator for CommandParameter
                        return FormatCodeRuleResult.ForceIndent;
                    }
                    return FormatCodeRuleResult.Continue;

                case TokenKind.Unknown:
                    return ctx.HasTrailingSpaceAfterToken(ctx.NextToken)
                        ? FormatCodeRuleResult.ForceIndent
                        : FormatCodeRuleResult.ForceNoIndent;
                default:
                    return FormatCodeRuleResult.Continue;
            }
        }

    }
}
