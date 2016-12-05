using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day05Tests
    {
        private Verses2016Day05 verses = new Verses2016Day05();

        [Fact]
        public void Part1_Ex1()
        {
            Assert.True(verses.Part1("abc") == "18f47a30");
        }

        [Fact]
        public void Part1_Part1()
        {
            Assert.True(verses.Part1("reyedfim") == "f97c354d");
        }
    }
}
