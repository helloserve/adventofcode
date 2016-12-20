using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day13Tests
    {
        [Fact]
        public void Part1_BaseValue()
        {
            Verses2016Day13 verses = new Verses2016Day13();
            Assert.True(verses.BaseValue(0, 0, 1) == 1);
            Assert.True(verses.BaseValue(1, 1, 1) == 9);
        }

        [Fact]
        public void Part1_Binary()
        {
            Verses2016Day13 verses = new Verses2016Day13();
            Assert.True(verses.Binary(1) == "00000000000000000000000000000001");
            Assert.True(verses.Binary(9) == "00000000000000000000000000001001");
            Assert.True(verses.Binary(256) == "00000000000000000000000100000000");
            Assert.True(verses.Binary(257) == "00000000000000000000000100000001");
        }

        [Fact]
        public void Part1_OnBits()
        {
            Verses2016Day13 verses = new Verses2016Day13();
            Assert.True(verses.OnBits("100") == 1);
            Assert.True(verses.OnBits("101") == 2);
            Assert.True(verses.OnBits("111") == 3);
        }

        [Fact]
        public void Part1_IsWall()
        {
            Verses2016Day13 verses = new Verses2016Day13();
            Assert.False(verses.IsOpen(0, 0, 1));
            Assert.True(verses.IsOpen(0, 0, 3));
            Assert.True(verses.IsOpen(0, 0, 257));
            Assert.False(verses.IsOpen(0, 0, 259));
        }

        [Fact]
        public void Part1_Ex()
        {
            Verses2016Day13 verses = new Verses2016Day13();
            Assert.True(verses.Part1(1, 1, 10, 7, 4) == 11);
        }
    }
}
