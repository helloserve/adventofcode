using helloserve.com.AdventOfCode.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day08Tests : TestClass
    {
        private Verses2016Day08 verses = new Verses2016Day08();

        [Fact]
        public void Part1_AllOff()
        {
            Assert.True(verses.Part1(string.Empty) == 0);
        }

        [Fact]
        public void Part1_Rect()
        {
            Assert.True(verses.Part1("rect 1x1") == 1);
            Assert.True(verses.Part1("rect 3x2") == 6);
            Assert.True(verses.Part1("rect 50x6") == 300);
            Assert.True(verses.Part1("rect 51x7") == 300);
        }

        [Fact]
        public void Part1_Rotate()
        {
            Assert.True(verses.Part1("rect 3x2\r\nrotate column x=1 by 1") == 6);
            Assert.True(verses.Part1("rect 3x2\r\nrotate column x=1 by 2\r\nrect 3x2") == 8);

            Assert.True(verses.Part1("rect 3x2\r\nrotate row y=1 by 1") == 6);
            Assert.True(verses.Part1("rect 3x2\r\nrotate row y=1 by 2\r\nrect 3x2") == 8);
        }

        [Fact]
        public void Part1_Part1()
        {
            Assert.True(verses.Part1(ReadTextSource("8.txt")) == 119);
        }
    }
}
