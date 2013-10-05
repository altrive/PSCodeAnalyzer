using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer
{
    [Export]
    public class FormatCodeRules
    {
        [ImportMany(typeof(IRule), RequiredCreationPolicy = CreationPolicy.Shared)]
        public IEnumerable<Lazy<IRule, IRuleMetadata>> _rules { get; set; }

        /*
        public static IEnumerable<Lazy<IRule, IRuleMetadata>> DefaultRules
        {
            get
            {
                return Default._rules.OrderBy(p => p.Metadata.Order);
            }
        }
        */

        private static FormatCodeRules _value { get; set; }

        public static FormatCodeRules Default
        {
            get
            {
                if (_value == null)
                {
                    _value = new FormatCodeRules();
                    _value.Compose();
                }
                return _value;
            }
        }

        private void Compose()
        {
            //TODO:Use DirectoryCatalog to support extra rules
            var container = new CompositionContainer(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            try
            {
                container.ComposeParts(this);
            }
            catch (CompositionException)
            {
                throw;
            }
        }

        public RuleAction ApplyRule(ScriptContext ctx)
        {
            //TODO: Apply Format Options
            var rules = _rules.OrderBy(p => p.Metadata.Order).Select(p=>p.Value).ToArray();
            foreach (var rule in rules)
            {
                var result = (FormatCodeRuleResult)rule.Execute(ctx);
                if (result == FormatCodeRuleResult.Continue)
                    continue;

                //Console.WriteLine("{0,-10}: Rule : {1} ", ctx.CurrentToken.Text, rule.ToString());

                if (result == FormatCodeRuleResult.ForceIndent || result == FormatCodeRuleResult.Indent)
                    return RuleAction.InsertSpace;

                return RuleAction.None;
            }
            return RuleAction.None;
        }

    }
}
