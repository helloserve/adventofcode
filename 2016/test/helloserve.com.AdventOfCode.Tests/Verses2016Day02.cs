using helloserve.com.AdventOfCode.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day02 : TestClass
    {
        private AdventOfCode.Verses2016Day02 verses = new AdventOfCode.Verses2016Day02();

        [Fact]
        public void Part1_U_2()
        {
            Assert.True(verses.Part1("U") == "2");
        }

        [Fact]
        public void Part1_D_8()
        {
            Assert.True(verses.Part1("D") == "8");
        }

        [Fact]
        public void Part1_L_4()
        {
            Assert.True(verses.Part1("L") == "4");
        }

        [Fact]
        public void Part1_R_6()
        {
            Assert.True(verses.Part1("R") == "6");
        }

        [Fact]
        public void Part1_RR_6()
        {
            Assert.True(verses.Part1("RR") == "6");
        }

        [Fact]
        public void Part1_LL_6()
        {
            Assert.True(verses.Part1("LL") == "4");
        }

        [Fact]
        public void Part1_UU_6()
        {
            Assert.True(verses.Part1("UU") == "2");
        }

        [Fact]
        public void Part1_DD_6()
        {
            Assert.True(verses.Part1("DD") == "8");
        }

        [Fact]
        public void Part1_Ex1()
        {
            string input = "ULL\r\nRRDDD\r\nLURDL\r\nUUUUD";
            Assert.True(verses.Part1(input) == "1985");
        }

        [Fact]
        public void Part1_Part1()
        {
            Assert.True(verses.Part1(ReadTextSource("2.txt")) == "65556");
        }

        [Fact]
        public void Part2_Ex1()
        {
            string input = "ULL\r\nRRDDD\r\nLURDL\r\nUUUUD";
            Assert.True(verses.Part2(input) == "5DB3");
        }

        [Fact]
        public void Part2_Part2()
        {
            Assert.True(verses.Part2(ReadTextSource("2.txt")) == "CB779");
        }
    }
}
