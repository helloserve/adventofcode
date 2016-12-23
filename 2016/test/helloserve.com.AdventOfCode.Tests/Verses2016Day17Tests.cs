using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day17Tests
    {
        [Fact]
        public void Part1_Ex()
        {
            Verses2016Day17 verses = new Verses2016Day17();
            Assert.True(verses.Part1("hijkl") == string.Empty);
            verses = new Verses2016Day17();
            Assert.True(verses.Part1("ihgpwlah") == "DDRRRD");
            verses = new Verses2016Day17();
            Assert.True(verses.Part1("kglvqrro") == "DDUDRLRRUDRD");
            verses = new Verses2016Day17();
            Assert.True(verses.Part1("ulqzkmiv") == "DRURDRUDDLLDLUURRDULRLDUUDDDRR");
        }

        [Fact]
        public void Part1_Part1()
        {
            Verses2016Day17 verses = new Verses2016Day17();
            Assert.True(verses.Part1("gdjjyniy") == "DUDDRLRRRD");
        }

        [Fact]
        public void Part2_Ex()
        {
            Verses2016Day17 verses = new Verses2016Day17();
            Assert.True(verses.Part2("ihgpwlah") == 370);
            verses = new Verses2016Day17();
            Assert.True(verses.Part2("kglvqrro") == 492);
            verses = new Verses2016Day17();
            Assert.True(verses.Part2("ulqzkmiv") == 830);
        }

        [Fact]
        public void Part2_Part2()
        {
            Verses2016Day17 verses = new Verses2016Day17();
            Assert.True(verses.Part2("gdjjyniy") == 578);
        }
    }
}
