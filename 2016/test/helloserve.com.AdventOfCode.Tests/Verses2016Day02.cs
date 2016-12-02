using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day02
    {
        private AdventOfCode.Verses2016Day02 verses = new AdventOfCode.Verses2016Day02();

        [Fact]
        public void Part1_U_2()
        {
            Assert.True(verses.Part1("U") == 3);
        }
    }
}
