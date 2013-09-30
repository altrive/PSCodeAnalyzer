using PSCodeAnalyzer.CodeFormatter;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer
{
    public class FormatCodeRules
    {
        public FormatCodeRules()
        {

        }

        internal RuleAction Process(ScriptContext ctx)
        {
            // var enabledRuleNames = GetEnabledRuleNames();

            //Remove disable rules and reorder based on priority.
            //.Where(p=>enabledRuleNames.Contains(p.Metadata.Name))
            var rules = Context.Current.Rules.OrderBy(p => p.Metadata.Order);

            foreach (var lazy in rules)
            {
                var rule = lazy.Value;
                if (rule.Execute(ctx))
                {
                    if (rule.Action == RuleAction.InsertSpace)
                    {
                        //Console.WriteLine("{0,-10}: Rule : {1} ", ctx.CurrentToken.Text, rule.ToString());
                        if (ctx.IndentMode == ScriptContext.TokenIndentMode.Indent || ctx.IndentMode == ScriptContext.TokenIndentMode.ForceIndent)
                            return RuleAction.InsertSpace;
                        return RuleAction.None;

                    }

                    break;
                }
            }
            return RuleAction.None;
        }
    }
}
