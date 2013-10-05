using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer
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

        public override Result Execute(ScriptContext ctx)
        {
            if (ctx.IsEndOfLine)
                return FormatCodeRuleResult.NoIndent;

            switch (ctx.CurrentToken.Kind)
            {
                case TokenKind.LBracket:
                    if (ctx.NextToken.Text == "]" && ctx.HasTrailingSpaceAfterToken(ctx.CurrentToken))
                        return FormatCodeRuleResult.Indent;
                    break;
            }

            switch (ctx.NextToken.Kind)
            {
                //CommandMode parser require space before comment token
                case TokenKind.Comment:
                    if (ctx.HasTrailingSpaceAfterToken(ctx.CurrentToken))
                        return FormatCodeRuleResult.Indent;
                    break;
            }

            return FormatCodeRuleResult.Continue;
        }

    }
}
