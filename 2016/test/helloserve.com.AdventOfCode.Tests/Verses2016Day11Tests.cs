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
            verses = new Verses2016Day11();
            Assert.True(verses.Part1("The first floor contains a hydrogen-compatible microchip.\r\nThe second floor contains a strontium generator.\r\nThe third floor contains nothing.\r\nThe fourth floor contains nothing.") == null);
        }

        [Fact]
        public void Part1_Ex()
        {
            verses = new Verses2016Day11();
            string input = "The first floor contains a hydrogen-compatible microchip and a lithium-compatible microchip.\r\nThe second floor contains a hydrogen generator.\r\nThe third floor contains a lithium generator.\r\nThe fourth floor contains nothing relevant.";
            Assert.True(verses.Part1(input) == 11);
        }

        [Fact]
        public void Part1_Part1()
        {
            verses = new Verses2016Day11();
            Assert.True(verses.Part1(ReadTextSource("11.txt")) == 31);
        }

        [Fact]
        public void Part2_Part1()
        {
            verses = new Verses2016Day11();
            string input = ReadTextSource("11.txt");
            input += "\r\nThe first floor contains a elerium generator, a elerium-compatible microchip, a dilithium generator, and a dilithium-compatible microchip.";
            Assert.True(verses.Part1(input) == 55);
        }
    }
}
