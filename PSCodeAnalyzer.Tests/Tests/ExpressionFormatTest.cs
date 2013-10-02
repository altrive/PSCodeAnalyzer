using System;
using System.IO;
using System.Management.Instrumentation;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PSCodeAnalyzer.Tests
{

    [TestClass]
    public class ExpressionFormatTest
    {
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void Init()
        {
            //Execution time is included in first test case?
            EditorImports.Initialize();
        }


        [TestMethod]
        public void LogicalExpressions()
        {
            {
                const string original = "$true -and $true";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "$true -or false";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "$true -xor $true";
                Utility.ShouldNotChanged(original);
            }
        }

        [TestMethod]
        public void BitwiseExpressions()
        {
            {
                const string original = "$true -band $true";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "$true -bor $true";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "$true -bxor $true";
                Utility.ShouldNotChanged(original);
            }
        }




        [TestMethod]
        public void BinaryOperators_Special()
        {
            {
                const string original = "1 - 1";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "$true -eq  $true";
                const string expected = "$true -eq $true";
                Utility.ShouldMatch(original, expected);
            }
        }

        [TestMethod]
        public void AssignmentOperators()
        {
            {
                const string original = "$test=1";
                const string expected = "$test = 1";
                Utility.ShouldMatch(original, expected);
            }
            {
                const string original = "$test+=1";
                const string expected = "$test += 1";
                Utility.ShouldMatch(original, expected);
            }
            {
                const string original = "$test-=1";
                const string expected = "$test -= 1";
                Utility.ShouldMatch(original, expected);
            }
            {
                const string original = "$test*=1";
                const string expected = "$test *= 1";
                Utility.ShouldMatch(original, expected);
            }
            {
                const string original = "$test/=1";
                const string expected = "$test /= 1";
                Utility.ShouldMatch(original, expected);
            }
            {
                const string original = "$test%=1";
                const string expected = "$test %= 1";
                Utility.ShouldMatch(original, expected);
            }
        }

        [TestMethod]
        public void LogicalOperators()
        {
            {
                const string original = "$true -and $true";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "$true -or $true";
                Utility.ShouldNotChanged(original);
            }
        }

        [TestMethod]
        public void BitwiseOperators()
        {
            {
                const string original = "$true -band $true";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "$true -bor $true";
                Utility.ShouldNotChanged(original);
            }
        }


        [TestMethod]
        public void RedirectOperators()
        {
            {
                const string original = "'test' 2>&1 out.log";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "'test' >> out.log";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "'test' >> out.log";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "'test' > out.log";
                Utility.ShouldNotChanged(original);
            }
            {
                //const string original = "'test' << out.log";
                //Utility.ShouldNotChanged(original);
            }
            {
                const string original = "'test' < out.log";
                Utility.ShouldNotChanged(original);
            }
            {
                //const string original = "'test' >| out.log";
                //Utility.ShouldNotChanged(original);
            }
            {
                const string original = "'test' 2> out.log";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "'test' 2>> out.log";
                Utility.ShouldNotChanged(original);
            }
            {
                const string original = "'test' 1>> out.log";
                Utility.ShouldNotChanged(original);
            }
        }
        //RedirectionOperatorToken = '2>&1' | '>>' | '>' | '<<' | '<' | '>|' | '2>' | '2>>' | '1>>'



    }
}
