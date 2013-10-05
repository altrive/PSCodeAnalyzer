using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Language;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer
{
    static class ScriptExtentExtensions
    {
        internal static bool IsBefore(this IScriptExtent extent, IScriptExtent target)
        {
            if (extent.EndLineNumber < target.StartLineNumber)
                return true;
            if (extent.EndLineNumber == target.StartLineNumber)
                return extent.EndColumnNumber <= target.StartColumnNumber;

            return false;
        }

        internal static bool IsAfter(this IScriptExtent extent, IScriptExtent target)
        {
            if (target.EndLineNumber < extent.StartLineNumber)
                return true;
            if (extent.StartLineNumber == target.EndLineNumber)
                return target.EndColumnNumber <= extent.StartColumnNumber;
            return false;
        }

        internal static bool IsContained(this IScriptExtent extent, IScriptExtent target)
        {
            if (extent.StartLineNumber < target.StartLineNumber)
                return false;

            if (target.EndLineNumber < extent.EndLineNumber)
                return false;

            if (extent.StartColumnNumber < target.StartColumnNumber)
                return false;


            return extent.EndColumnNumber <= target.EndColumnNumber;
        }

        internal static bool IsAfter(this IScriptExtent extent, int line, int column)
        {
            if (line < extent.StartLineNumber)
                return true;
            if (line == extent.StartLineNumber)
                return column < extent.StartColumnNumber;

            return false;
        }
    }
}
