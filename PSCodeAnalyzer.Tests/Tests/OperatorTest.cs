using System;
using System.IO;
using System.Management.Instrumentation;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PSCodeAnalyzer.Tests
{

    [TestClass]
    public class OperatorFormatTest
    {
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void Init()
        {
            //Execution time is included in first test case?
            EditorImports.Initialize();
        }


        [TestMethod]
        public void UnaryOperators()
        {
            Utility.ShouldNotChanged("++$i");
            Utility.ShouldNotChanged("$i--");
            Utility.ShouldNotChanged("++$script:test");
            Utility.ShouldNotChanged("if ($ddnlastname -eq $ddncurrent){ $script:ddntimecount++ }");

            //Join operator
            {

                Utility.ShouldNotChanged("$a = -join (10, 20, 30)");
                Utility.ShouldNotChanged("-join (123, $false, 19.34e17)");
                Utility.ShouldNotChanged("-join 12345");
                Utility.ShouldNotChanged("-join $null");
            }

            //Split operator
            {
                Utility.ShouldNotChanged("-split \"  red`tblue`ngreen  \"");
                Utility.ShouldNotChanged("-split ('yes no', 'up down')");
                Utility.ShouldNotChanged("-split '     '");
            }

            //Cast
            {
                Utility.ShouldNotChanged("[bool] -10");
                Utility.ShouldNotChanged("[int] -10.70D");
                Utility.ShouldNotChanged("[int] 10.7");
                Utility.ShouldNotChanged("[char[]] 'Hello'");
                Utility.ShouldNotChanged("[long] '+2.3e+3'");
            }



        }



        [TestMethod]
        public void UnaryOperators_Special()
        {
            Utility.ShouldNotChanged("a + ++$b");
            Utility.ShouldNotChanged("a + --$b");

        }




        [TestMethod]
        public void BinaryOperators_Special()
        {
            {
                const string original = "1 - 1";
                const string expected = "1 - 1";
                Utility.ShouldMatch(original, expected);
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
            Utility.ShouldNotChanged("$true -and $true");
            Utility.ShouldNotChanged("$true -band $true");
            Utility.ShouldNotChanged("$true -bor $true");
            Utility.ShouldNotChanged("$true -bxor $true");
            Utility.ShouldNotChanged("$true -band $true");
            Utility.ShouldNotChanged("$true -or $true");
            Utility.ShouldNotChanged("$true -xor $true");

            Utility.ShouldNotChanged("($true) -and ($true)");
            Utility.ShouldNotChanged("($true) -or ($true)");

            //Unary operators
            Utility.ShouldNotChanged("-bnot $true");
            Utility.ShouldNotChanged("-bnot($true)");
            Utility.ShouldNotChanged("-not $true");
            Utility.ShouldNotChanged("-not($true)");

            Utility.ShouldNotChanged("-not [string]::IsNullOrEmpty('')");
            Utility.ShouldNotChanged("-bnot [string]::IsNullOrEmpty('')");
            Utility.ShouldNotChanged("-not {[string]::IsNullOrEmpty('')}.Invoke()");

        }


        [TestMethod]
        public void RedirectOperators()
        {
            //FileRedirection operators
            {
                Utility.ShouldNotChanged("'test' > out.log");
                Utility.ShouldNotChanged("'test' >> out.log");
                Utility.ShouldNotChanged("'test' 2> out.log");
                Utility.ShouldNotChanged("'test' 2>> out.log");
                Utility.ShouldNotChanged("'test' 3> out.log");
                Utility.ShouldNotChanged("'test' 3>> out.log");
                Utility.ShouldNotChanged("'test' 4> out.log");
                Utility.ShouldNotChanged("'test' 4>> out.log");
                Utility.ShouldNotChanged("'test' 5> out.log");
                Utility.ShouldNotChanged("'test' 5>> out.log");
                Utility.ShouldNotChanged("'test' 6> out.log");
                Utility.ShouldNotChanged("'test' 6>> out.log");
                Utility.ShouldNotChanged("'test' *> out.log");
                Utility.ShouldNotChanged("'test' *>> out.log");

            }
            // merging-redirection-operator
            {

                Utility.ShouldNotChanged("'test' *>&1 out.log");
                Utility.ShouldNotChanged("'test' 2>&1 out.log");
                Utility.ShouldNotChanged("'test' 3>&1 out.log");
                Utility.ShouldNotChanged("'test' 4>&1 out.log");
                Utility.ShouldNotChanged("'test' 5>&1 out.log");
                Utility.ShouldNotChanged("'test' 6>&1 out.log");

                //TODO:Reserved Redirect Operators?
                //Utility.ShouldNotChanged("'test' *>&2 out.log"); //TODO:Can't tokenize appropriately?
                Utility.ShouldNotChanged("'test' 1>&2 out.log");
                Utility.ShouldNotChanged("'test' 3>&2 out.log");
                Utility.ShouldNotChanged("'test' 4>&2 out.log");
                Utility.ShouldNotChanged("'test' 5>&2 out.log");
                Utility.ShouldNotChanged("'test' 6>&2 out.log");
                Utility.ShouldNotChanged("'test' < out.log");  //Reserved operator
            }
            //Examples
            {
                Utility.ShouldNotChanged("$i > output1.txt");
                Utility.ShouldNotChanged("++$i >> output1.txt");
                Utility.ShouldNotChanged("type file1.txt 2> error1.txt");
                Utility.ShouldNotChanged("type file2.txt 2>> error1.txt");
                Utility.ShouldNotChanged("dir –Verbose 4> verbose1.txt");
                Utility.ShouldNotChanged("dir –Verbose –Debug –WarningAction Continue *> output2.txt");
            }
        }

        [TestMethod]
        public void ComparisonOperator()
        {
            Utility.ShouldNotChanged("$true -as $true");
            Utility.ShouldNotChanged("$true -ccontains $true");
            Utility.ShouldNotChanged("$true -ceq $true");
            Utility.ShouldNotChanged("$true -cge $true");
            Utility.ShouldNotChanged("$true -cgt $true");
            Utility.ShouldNotChanged("$true -cle $true");
            Utility.ShouldNotChanged("$true -clik $true");
            Utility.ShouldNotChanged("$true -clt $true");
            Utility.ShouldNotChanged("$true -cmatch $true");
            Utility.ShouldNotChanged("$true -cne $true");
            Utility.ShouldNotChanged("$true -cnotcontains $true");
            Utility.ShouldNotChanged("$true -cnotlike $true");
            Utility.ShouldNotChanged("$true -cnotmatch $true");
            Utility.ShouldNotChanged("$true -contains $true");
            Utility.ShouldNotChanged("$true -creplace $true");
            Utility.ShouldNotChanged("$true -csplit $true");
            Utility.ShouldNotChanged("$true -eq $true");
            Utility.ShouldNotChanged("$true -ge $true");
            Utility.ShouldNotChanged("$true -gt $true");
            Utility.ShouldNotChanged("$true -icontains $true");
            Utility.ShouldNotChanged("$true -ieq $true");
            Utility.ShouldNotChanged("$true -ige $true");
            Utility.ShouldNotChanged("$true -igt $true");
            Utility.ShouldNotChanged("$true -ile $true");
            Utility.ShouldNotChanged("$true -ilike $true");
            Utility.ShouldNotChanged("$true -ilt $true");
            Utility.ShouldNotChanged("$true -imatch $true");
            Utility.ShouldNotChanged("$true -in $true");
            Utility.ShouldNotChanged("$true -ine $true");
            Utility.ShouldNotChanged("$true -inotcontains $true");
            Utility.ShouldNotChanged("$true -inotlike $true");
            Utility.ShouldNotChanged("$true -inotmatch $true");
            Utility.ShouldNotChanged("$true -ireplace $true");
            Utility.ShouldNotChanged("$true -is $true");
            Utility.ShouldNotChanged("$true -isnot $true");
            Utility.ShouldNotChanged("$true -isplit $true");
            Utility.ShouldNotChanged("$true -join $true");
            Utility.ShouldNotChanged("$true -le $true");
            Utility.ShouldNotChanged("$true -like $true");
            Utility.ShouldNotChanged("$true -lt $true");
            Utility.ShouldNotChanged("$true -match $true");
            Utility.ShouldNotChanged("$true -ne $true");
            Utility.ShouldNotChanged("$true -notcontains $true");
            Utility.ShouldNotChanged("$true -notin $true");
            Utility.ShouldNotChanged("$true -notlike $true");
            Utility.ShouldNotChanged("$true -notmatch $true");
            Utility.ShouldNotChanged("$true -replace $true");
            Utility.ShouldNotChanged("$true -shl $true");
            Utility.ShouldNotChanged("$true -shr $true");
            Utility.ShouldNotChanged("$true -split $true");
        }

        [TestMethod]
        public void FormatOperator()
        {
            //Format Operator
            Utility.ShouldNotChanged("'{0}' -f 'text'");
            Utility.ShouldNotChanged("'{2} <= {0} + {1}' -f $i, $j, ($i + $j)");
            Utility.ShouldNotChanged("'>{0,3}<' -f 5");
            Utility.ShouldNotChanged("'>{0,-3}<' -f 5");
            Utility.ShouldNotChanged("'>{0,3:000}<' -f 5");
            Utility.ShouldNotChanged("'>{0,5:0.00}<' -f 5.0");
            Utility.ShouldNotChanged("'>{0:C}<' -f 1234567.888");
            Utility.ShouldNotChanged("'>{0:C}<' -f -1234.56");
            Utility.ShouldNotChanged("'>{0,-12:p}<' -f -0.252");
            Utility.ShouldNotChanged("$format = '>{0:x8}<'; $format -f 123455");

        }

        [TestMethod]
        public void ArrayRangeOperater()
        {
            Utility.ShouldNotChanged("$array[1]..$array[10];");
        }

        [TestMethod]
        public void OtherOperator()
        {
            //Binary comma operator
            {
                Utility.ShouldNotChanged("2, 4, 6");
                Utility.ShouldNotChanged("(2, 4), 6");
                Utility.ShouldNotChanged("(2, 4, 6), 12, (2..4)");
                Utility.ShouldNotChanged("2, 4, 6");
            }

            //RangeOperator
            {
                Utility.ShouldNotChanged("1..10");
                Utility.ShouldNotChanged("-500..-495");
                Utility.ShouldNotChanged("16..16");
                Utility.ShouldNotChanged("$x = 1.5");
                Utility.ShouldNotChanged("$x..5.40D");
                Utility.ShouldNotChanged("$true..3");
                Utility.ShouldNotChanged("-2..$null");
                Utility.ShouldNotChanged("'0xf'..'0xa'");
            }
            //Format operator
            {

                Utility.ShouldNotChanged("$a + 1");
                Utility.ShouldNotChanged("$a - 1");
                Utility.ShouldNotChanged("!$false");
                Utility.ShouldNotChanged("-not $false");
                Utility.ShouldNotChanged("-not($false)");
                Utility.ShouldNotChanged("-bnot $false");
                Utility.ShouldNotChanged("++$i");
                Utility.ShouldNotChanged("$i++");
                Utility.ShouldNotChanged("$i--");

            }
        }

    }
}
