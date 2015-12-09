using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace helloserve.com.AdventOfCode.Test
{
    [TestClass]
    public class VersesTests
    {
        private string FromFile(string filename)
        {
            return File.ReadAllText(Path.Combine(@".\Input", filename));
        }

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

        [TestMethod]
        public void TestDay7_Part1_Example1()
        {
            string input = "123 -> x";
            int result = Verses.Day7_Part1(input, "x");
            Assert.IsTrue(result == 123);
        }
    }
}

