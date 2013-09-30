using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer.CodeFormatter.Rules
{
    [Export(typeof(IRule))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [ExportMetadata("Order", RulePriority.PreprocessRule)]
    class PreProcessRule : Rule
    {
        public override RuleAction Action
        {
            get { return RuleAction.InsertSpace; }
        }

        public override bool Execute(IScriptContext ctx)
        {
            if (ctx.IsEndOfLine)
                return false;

            switch (ctx.CurrentToken.Kind)
            {
                case TokenKind.LBracket:
                    if (ctx.NextToken.Text == "]" && ctx.HasTrailingSpaceAfterToken(ctx.CurrentToken))
                        return ctx.SetIndentNextToken();
                    break;
            }

            switch (ctx.NextToken.Kind)
            {
                case TokenKind.Comment:
                    if (ctx.HasTrailingSpaceAfterToken(ctx.CurrentToken))
                        return ctx.SetIndentNextToken();
                    break;
            }


            return false;
        }

    }
}
