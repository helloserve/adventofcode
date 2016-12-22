using helloserve.com.AdventOfCode.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day15Tests : TestClass
    {
        [Fact]
        public void Part1_1Disk()
        {
            Verses2016Day15 verses = new Verses2016Day15();
            Assert.True(verses.Part1("Disc #1 has 2 positions; at time=0, it is at position 1.") == 0);
            Assert.True(verses.Part1("Disc #1 has 5 positions; at time=0, it is at position 1.") == 3);
        }

        [Fact]
        public void Part1_Ex()
        {
            Verses2016Day15 verses = new Verses2016Day15();
            Assert.True(verses.Part1("Disc #1 has 5 positions; at time=0, it is at position 4.\r\nDisc #2 has 2 positions; at time=0, it is at position 1.") == 5);
        }

        [Fact]
        public void Part1_Part1()
        {
            Verses2016Day15 verses = new Verses2016Day15();
            Assert.True(verses.Part1(ReadTextSource("15.txt")) == 148737);
        }
    }
}
