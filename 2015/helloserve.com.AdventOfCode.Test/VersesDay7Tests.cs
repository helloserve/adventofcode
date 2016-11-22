using helloserve.com.AdventOfCode.Test.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Test
{
    [TestClass]
    public class VersesDay7Tests : VersesTests
    {
        [TestMethod]
        public void TestDay7_Part1_Example1()
        {
            string input = "123 -> x";
            int result = Verses.Day7_Part1(input, "x");
            Assert.IsTrue(result == 123);
        }

        [TestMethod]
        public void TestDay7_Part1_Example3()
        {
            StringBuilder blr = new StringBuilder();
            blr.AppendLine("123 -> x");
            blr.AppendLine("456 -> y");
            blr.AppendLine("x AND y -> d");
            blr.AppendLine("x OR y -> e");
            blr.AppendLine("x LSHIFT 2 -> f");
            blr.AppendLine("y RSHIFT 2 -> g");
            blr.AppendLine("NOT x -> h");
            blr.AppendLine("NOT y -> i");
            string input = blr.ToString();
            int result = Verses.Day7_Part1(input, "e");
            Assert.IsTrue(result == 507);

            result = Verses.Day7_Part1(input, "e");
            Assert.IsTrue(result == 507);

            result = Verses.Day7_Part1(input, "f");
            Assert.IsTrue(result == 492);

            result = Verses.Day7_Part1(input, "g");
            Assert.IsTrue(result == 114);

            result = Verses.Day7_Part1(input, "h");
            Assert.IsTrue(result == -124);

            result = Verses.Day7_Part1(input, "i");
            Assert.IsTrue(result == -457);
        }

        [TestMethod]
        public void TestDay7_Part1()
        {
            string input = FromFile("day7.txt");
            int result = Verses.Day7_Part1(input, "a");
            Assert.IsTrue(result == 16076);
        }

        [TestMethod]
        public void TestDay7_Part2_OverrideWireb()
        {
            string input = FromFile("day7.txt");
            input += "\r\n16076 -> b";
            int result = Verses.Day7_Part1(input, "b");
            Assert.IsTrue(result == 16076);
        }

        [TestMethod]
        public void TestDay7_Part2()
        {
            string input = FromFile("day7.txt");
            input += "\r\n16076 -> b";
            int result = Verses.Day7_Part1(input, "a");
            Assert.IsTrue(result == 2797);
        }
    }
}
