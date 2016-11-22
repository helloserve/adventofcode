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
    public class VersesDay4Tests : VersesTests
    {
        [TestMethod]
        public void TestDay4_Part1_Example1()
        {
            string input = "abcdef";
            int result = Verses.Day4(input);
            Assert.IsTrue(result == 609043);
        }

        [TestMethod]
        public void TestDay4_Part1_Example2()
        {
            string input = "pqrstuv";
            int result = Verses.Day4(input);
            Assert.IsTrue(result == 1048970);
        }

        [TestMethod]
        public void TestDay4_Part1()
        {
            string input = "iwrupvqb";
            int result = Verses.Day4(input);
            Assert.IsTrue(result == 346386);
        }

        [TestMethod]
        public void TestDay4_Part2()
        {
            string input = "iwrupvqb";
            int result = Verses.Day4(input, zeroCount: 6);
            Assert.IsTrue(result == 9958218);
        }

    }
}
