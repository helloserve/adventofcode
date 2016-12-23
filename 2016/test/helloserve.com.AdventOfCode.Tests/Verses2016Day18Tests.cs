using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day18Tests
    {
        [Fact]
        public void Part1_SimpleEx()
        {
            Verses2016Day18 verses = new Verses2016Day18();
            Assert.True(verses.Part1(".....", 2) == 10);
            Assert.True(verses.Part1("^...^", 2) == 6);
            Assert.True(verses.Part1("..^^.", 3) == 6);
            Assert.True(verses.Part1(".^^.^.^^^^", 10) == 38);
        }

        [Fact]
        public void Part1_Part1()
        {
            Verses2016Day18 verses = new Verses2016Day18();
            Assert.True(verses.Part1(".^^..^...^..^^.^^^.^^^.^^^^^^.^.^^^^.^^.^^^^^^.^...^......^...^^^..^^^.....^^^^^^^^^....^^...^^^^..^", 40) == 2005);
        }

        [Fact]
        public void Part2_Part2()
        {
            Verses2016Day18 verses = new Verses2016Day18();
            Assert.True(verses.Part1(".^^..^...^..^^.^^^.^^^.^^^^^^.^.^^^^.^^.^^^^^^.^...^......^...^^^..^^^.....^^^^^^^^^....^^...^^^^..^", 400000) == 2005);
        }
    }
}
