using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day19Tests
    {
        [Fact]
        public void Part1_Ex()
        {
            Verses2016Day19 verses = new Verses2016Day19();
            Assert.True(verses.Part1(5) == 3);
            Assert.True(verses.Part1(6) == 5);
            Assert.True(verses.Part1(3) == 3);
        }

        [Fact]
        public void Part1_Part1()
        {
            Verses2016Day19 verses = new Verses2016Day19();
            Assert.True(verses.Part1(3005290) == 1816277);
        }
    }
}
