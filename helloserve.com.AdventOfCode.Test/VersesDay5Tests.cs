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
    public class VersesDay5Tests : VersesTests
    {
        [TestMethod]
        public void TestDay5_Part1_Example1()
        {
            string input = "ugknbfddgicrmopn";
            int result = Verses.Day5_Part1(input);
            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void TestDay5_Part1()
        {
            string input = FromFile("day5.txt");
            int result = Verses.Day5_Part1(input);
            Assert.IsTrue(result == 255);
        }

        [TestMethod]
        public void TestDay5_Part2_Example1()
        {
            string input = "qjhvhtzxzqqjkmpb";
            int result = Verses.Day5_Part2(input);
            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void TestDay5_Part2_Example2()
        {
            string input = "xxyxx";
            int result = Verses.Day5_Part2(input);
            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void TestDay5_Part2_Example3()
        {
            string input = "uurcxstgmygtbstg";
            int result = Verses.Day5_Part2(input);
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void TestDay5_Part2_Example4()
        {
            string input = "ieodomkazucvgmuy";
            int result = Verses.Day5_Part2(input);
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void TestDay5_Part2_Example5()
        {
            string input = "aaaa";
            int result = Verses.Day5_Part2(input);
            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void TestDay5_Part2()
        {
            string input = FromFile("day5.txt");
            int result = Verses.Day5_Part2(input);
            Assert.IsTrue(result == 55);
        }

    }
}
