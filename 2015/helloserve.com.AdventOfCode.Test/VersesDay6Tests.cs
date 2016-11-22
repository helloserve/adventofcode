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
    public class VersesDay6Tests : VersesTests
    {
        [TestMethod]
        public void TestDay6_Part1_Example1()
        {
            string input = "turn on 0,0 through 999,999";
            int result = Verses.Day6_Part1(input);
            Assert.IsTrue(result == 1000000);
        }

        [TestMethod]
        public void TestDay6_Part1_Example2()
        {
            string input = "toggle 0,0 through 999,0";
            int result = Verses.Day6_Part1(input);
            Assert.IsTrue(result == 1000);
        }

        [TestMethod]
        public void TestDay6_Part1()
        {
            string input = FromFile("day6.txt");
            int result = Verses.Day6_Part1(input);
            Assert.IsTrue(result == 569999);
        }

        [TestMethod]
        public void TestDay6_Part2()
        {
            string input = FromFile("day6.txt");
            int result = Verses.Day6_Part2(input);
            Assert.IsTrue(result == 17836115);
        }

    }
}
