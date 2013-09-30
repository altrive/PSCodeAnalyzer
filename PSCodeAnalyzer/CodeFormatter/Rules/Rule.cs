using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Management.Automation.Language;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer.CodeFormatter
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

        bool Execute(IScriptContext ctx);
    }

    public interface IRuleMetadata
    {
        [DefaultValue("Name")]
        string Name { get; }

        [DefaultValue(Int32.MaxValue -1)]
        int Order { get; }
    }

    public abstract class Rule : IRule
    {
        public abstract RuleAction Action { get; }


        public abstract bool Execute(IScriptContext ctx);
    }
}
