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
    public class VersesDay1Tests : VersesTests
    {
        [TestMethod]
        public void TestDay1_Part1()
        {
            string input = FromFile("day1.txt");
            int result = Verses.Day1_Part1(input);
            Assert.IsTrue(result == 138);
        }

        [TestMethod]
        public void TestDay1_Part2()
        {
            string input = FromFile("day1.txt");
            int result = Verses.Day1_Part2(input);
            Assert.IsTrue(result == 1771);
        }
    }
}
