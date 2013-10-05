using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Management.Automation.Language;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer
{
    public enum HandlingPolicy
    {
        Skipped,
        Stop,
    }
    public enum RuleAction
    {
        None,
        Skip,
        Break,
        InsertSpace,
        InsertNewLine,
        RemoveNewLine,
        RewriteToken,
    }

    public interface IRule
    {
        RuleAction Action { get; }
        bool CanHandle(ScriptContext ctx);
        Rule.Result Execute(ScriptContext ctx);
    }

    public interface IRuleMetadata
    {
        [DefaultValue("Name")]
        string Name { get; }

        [DefaultValue(Int32.MaxValue - 1)]
        int Order { get; }
    }

    public abstract class Rule : IRule
    {
        public abstract RuleAction Action { get; }

        public virtual bool CanHandle(ScriptContext ctx)
        {
            return true;
        }

        public abstract Result Execute(ScriptContext ctx);

        public abstract class Result
        {
            public bool IsHandled { get; protected set; }
        }
    }



    public class FormatCodeRuleResult : Rule.Result
    {
        private FormatCodeRuleResult()
        {
            IsHandled = true;
        }

        static FormatCodeRuleResult()
        {
            Indent = new FormatCodeRuleResult();
            NoIndent = new FormatCodeRuleResult();
            ForceIndent = new FormatCodeRuleResult();
            ForceNoIndent = new FormatCodeRuleResult();
            Continue = new FormatCodeRuleResult();
        }

        public static FormatCodeRuleResult Indent { get; private set; }

        public static FormatCodeRuleResult NoIndent { get; private set; }


        public static FormatCodeRuleResult ForceIndent { get; private set; }

        public static FormatCodeRuleResult ForceNoIndent { get; private set; }

        public static FormatCodeRuleResult Continue { get; private set; }
    }
}
