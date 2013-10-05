using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer
{
    public static class RulePriority
    {
        public const int PreprocessRule = 1000;

        public const int BeforeCoreRule = 2000;     
        public const int CoreRule = 3000;          
        public const int GroupTokenRule = 4000;  
        public const int CurrentTokenRule = 5000;      
        public const int NextTokenRule = 60000;

        public const int Finally = int.MaxValue - 1;
    }
}
