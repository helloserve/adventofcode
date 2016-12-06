using helloserve.com.AdventOfCode.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day06Tests : TestClass
    {
        private Verses2016Day06 verses = new Verses2016Day06();

        [Fact]
        public void Part1_SingleRow_SingleRow()
        {
            Assert.True(verses.Part1("test") == "test");
        }

        [Fact]
        public void Part1_DoubleRow_Result()
        {
            Assert.True(verses.Part1("test\r\ntest") == "test");
        }

        [Fact]
        public void Part1_TripleRow_Result()
        {
            Assert.True(verses.Part1("what\r\ntest\r\ntest") == "test");
        }

        [Fact]
        public void Part1_Ex1()
        {
            string input = "eedadn\r\ndrvtee\r\neandsr\r\nraavrd\r\natevrs\r\ntsrnev\r\nsdttsa\r\nrasrtv\r\nnssdts\rt\nntnada\r\nsvetve\r\ntesnvt\r\nvntsnd\r\nvrdear\r\ndvrsen\r\nenarar";

            Assert.True(verses.Part1(input) == "easter");
        }

        [Fact]
        public void Part1_Part1()
        {
            Assert.True(verses.Part1(ReadTextSource("6.txt")) == "tsreykjj");
        }

        [Fact]
        public void Part2_TripleRow_Result()
        {
            Assert.True(verses.Part2("what\r\ntest\r\ntest") == "what");
        }

        [Fact]
        public void Part2_Ex1()
        {
            string input = "eedadn\r\ndrvtee\r\neandsr\r\nraavrd\r\natevrs\r\ntsrnev\r\nsdttsa\r\nrasrtv\r\nnssdts\rt\nntnada\r\nsvetve\r\ntesnvt\r\nvntsnd\r\nvrdear\r\ndvrsen\r\nenarar";
            Assert.True(verses.Part2(input) == "advent");
        }


        [Fact]
        public void Part2_Part2()
        {
            Assert.True(verses.Part2(ReadTextSource("6.txt")) == "hnfbujie");
        }
    }
}
