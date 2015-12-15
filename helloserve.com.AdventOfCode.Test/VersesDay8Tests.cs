using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Test
{
    [TestClass]
    public class VersesDay8Tests : VersesTests
    {
        [TestMethod]
        public void TestDay8_Part1_Example1()
        {
            string input = "\"\"";
            int result = Verses.Day8_Part1(input);
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void TestDay8_Part1_Example2()
        {
            string input = "\"abc\"";
            int result = Verses.Day8_Part1(input);
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void TestDay8_Part1_Example3()
        {
            string input = "\"aaa\\\"aaa\"";
            int result = Verses.Day8_Part1(input);
            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void TestDay8_Part1_Example4()
        {
            string input = "\"\\x27\"";
            int result = Verses.Day8_Part1(input);
            Assert.IsTrue(result == 5);
        }

        [TestMethod]
        public void TestDay8_Part1_Slashes()
        {
            string input = "\"" + "\\\\\\x27" + "\"";
            int result = Verses.Day8_Part1(input);
            Assert.IsTrue(result == 6);
        }

        [TestMethod]
        public void TestDay8_Part1_Everything_Invalid()
        {
            bool error = false;
            string input = "\"" + "\\\\\"\\x27" + "\"";
            try
            {
                int result = Verses.Day8_Part1(input);
            }
            catch(InvalidOperationException ex)
            {
                error = true;                
            }

            Assert.IsTrue(error);
        }

        [TestMethod]
        public void TestDay8_Part1_Everything_Valid()
        {
            string input = "\"" + "\\\\\\\"\\x27" + "\"";
            int result = Verses.Day8_Part1(input);
            Assert.IsTrue(result == 7);
        }

        [TestMethod]
        public void TestDay8_Part1_InputLine2()
        {
            string input = "\"" + "v\\xfb\\\"lgs\\\"kvjfywmut\\x9cr" + "\"";
            int result = Verses.Day8_Part1(input);
            Assert.IsTrue(result == 10);
        }

        [TestMethod]
        public void TestDay8_Part1_AllExamples()
        {
            string input = FromFile("day8_exampleAll.txt");
            int result = Verses.Day8_Part1(input);
            Assert.IsTrue(result == 12);
        }

        [TestMethod]
        public void TestDay8_Part1()
        {
            string input = FromFile("day8.txt");
            int result = Verses.Day8_Part1(input);
            Assert.IsTrue(result == 1342);
        }

        [TestMethod]
        public void TestDay8_Part2_Example1()
        {
            string input = "";
            int result = Verses.Day8_Part2(input);
            Assert.IsTrue(result == 4);
        }

        [TestMethod]
        public void TestDay8_Part2_Example2()
        {
            string input = "\"abc\"";
            int result = Verses.Day8_Part2(input);
            Assert.IsTrue(result == 4);
        }

        [TestMethod]
        public void TestDay8_Part2_Example3()
        {
            string input = "\"aaa\\\"aaa\"";
            int result = Verses.Day8_Part2(input);
            Assert.IsTrue(result == 6);
        }

        [TestMethod]
        public void TestDay8_Part2_Example4()
        {
            string input = "\"\\x27\"";
            int result = Verses.Day8_Part2(input);
            Assert.IsTrue(result == 5);
        }

        [TestMethod]
        public void TestDay8_Part2_Slashes()
        {
            string input = "\"" + "\\\\\\x27" + "\"";
            int result = Verses.Day8_Part2(input);
            Assert.IsTrue(result == 7);
        }

        [TestMethod]
        public void TestDay8_Part2_AllExamples()
        {
            string input = FromFile("day8_exampleAll.txt");
            int result = Verses.Day8_Part2(input);
            Assert.IsTrue(result == 19);
        }

        [TestMethod]
        public void TestDay8_Part2()
        {
            string input = FromFile("day8.txt");
            int result = Verses.Day8_Part2(input);
            Assert.IsTrue(result == 2074);
        }
    }
}
