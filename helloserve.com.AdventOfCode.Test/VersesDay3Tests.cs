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
    public class VersesDay3Tests : VersesTests
    {
        [TestMethod]
        public void TestDay3_Part1_Example1()
        {
            string input = ">";
            int result = Verses.Day3_Part1(input);
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void TestDay3_Part1_Example2()
        {
            string input = "^>v<";
            int result = Verses.Day3_Part1(input);
            Assert.IsTrue(result == 4);
        }

        [TestMethod]
        public void TestDay3_Part1_Example3()
        {
            string input = "^v^v^v^v^v";
            int result = Verses.Day3_Part1(input);
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void TestDay3_Part1()
        {
            string input = FromFile("day3.txt");
            int result = Verses.Day3_Part1(input);
            Assert.IsTrue(result == 2081);
        }

        [TestMethod]
        public void TestDay3_Part2_Example1()
        {
            string input = "^v";
            int result = Verses.Day3_Part2(input);
            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void TestDay3_Part2_Example2()
        {
            string input = "^>v<";
            int result = Verses.Day3_Part2(input);
            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void TestDay3_Part2()
        {
            string input = FromFile("day3.txt");
            int result = Verses.Day3_Part2(input);
            Assert.IsTrue(result == 2341);
        }

    }
}
