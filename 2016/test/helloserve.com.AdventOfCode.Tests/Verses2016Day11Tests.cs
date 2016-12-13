using helloserve.com.AdventOfCode.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day11Tests : TestClass
    {
        private Verses2016Day11 verses;

        [Fact]
        public void Part1_Simple()
        {
            verses = new Verses2016Day11();
            Assert.True(verses.Part1("The first floor contains a hydrogen-compatible microchip.\r\nThe second floor contains nothing.\r\nThe third floor contains nothing.\r\nThe fourth floor contains nothing.") == 3);
            //verses = new Verses2016Day11();
            //Assert.Throws<InvalidOperationException>(() => verses.Part1("The first floor contains a hydrogen-compatible microchip.\r\nThe second floor contains a strontium generator.\r\nThe third floor contains nothing.\r\nThe fourth floor contains nothing."));
        }
    }
}
