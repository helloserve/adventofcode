using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day10Tests
    {
        private Verses2016Day10 verses = new Verses2016Day10();

        [Fact]
        public void Part1_Simple()
        {
            Assert.True(verses.Part1("value 1 goes to bot 1\r\nvalue 2 goes to bot 1", 1, 2) == 1);
        }
    }
}
