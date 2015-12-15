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
    public class VersesDay2Tests : VersesTests
    {
        [TestMethod]
        public void TestDay2_Part1()
        {
            string input = FromFile("day2.txt");
            int result = Verses.Day2_Part1(input);
            Assert.IsTrue(result == 1588178);
        }

        [TestMethod]
        public void TestDay2_Part2_Example1()
        {
            string input = "2x3x4";
            int result = Verses.Day2_Part2(input);
            Assert.IsTrue(result == 34);
        }

        [TestMethod]
        public void TestDay2_Part2()
        {
            string input = FromFile("day2.txt");
            int result = Verses.Day2_Part2(input);
            Assert.IsTrue(result == 3783758);
        }
    }
}
