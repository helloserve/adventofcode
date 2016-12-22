using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day16Tests
    {
        [Fact]
        public void Part1_Expand()
        {
            Verses2016Day16 verses = new Verses2016Day16();
            Assert.True(verses.Expand("1", 3) == "100");
            Assert.True(verses.Expand("0", 3) == "001");
            Assert.True(verses.Expand("11111", 11) == "11111000000");
            Assert.True(verses.Expand("111100001010", 25) == "1111000010100101011110000");
        } 
        
        [Fact]
        public void Part1_Checksum()
        {
            Verses2016Day16 verses = new Verses2016Day16();
            Assert.True(verses.Checksum("1100") == "1");
            Assert.True(verses.Checksum("1010") == "1");
            Assert.True(verses.Checksum("110010110100") == "100");
        }

        [Fact]
        public void Part1_Ex()
        {
            Verses2016Day16 verses = new Verses2016Day16();
            Assert.True(verses.Part1("10000", 20) == "01100");
        }

        [Fact]
        public void Part1_Part1()
        { 
            Verses2016Day16 verses = new Verses2016Day16();
            Assert.True(verses.Part1("11100010111110100", 272) == "10100011010101011");
        }

        [Fact]
        public void Part2_Part2()
        {
            Verses2016Day16 verses = new Verses2016Day16();
            Assert.True(verses.Part1("11100010111110100", 35651584) == "01010001101011001");
        }
    }
}
