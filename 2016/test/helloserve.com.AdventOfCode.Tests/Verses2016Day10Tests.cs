using helloserve.com.AdventOfCode.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day10Tests : TestClass
    {
        private Verses2016Day10 verses;

        [Fact]
        public void Part1_Simple()
        {
            verses = new Verses2016Day10();
            Assert.True(verses.Part1("value 1 goes to bot 1", 1, 2) == -1);
            verses = new Verses2016Day10();
            Assert.True(verses.Part1("value 1 goes to bot 1\r\nvalue 2 goes to bot 1", 1, 2) == 1);
            verses = new Verses2016Day10();
            Assert.True(verses.Part1("value 1 goes to bot 1\r\nvalue 2 goes to bot 1\r\nbot 1 gives low to bot 2 and high to bot 2", 1, 2) == 1);
            verses = new Verses2016Day10();
            Assert.True(verses.Part1("value 1 goes to bot 1\r\nvalue 2 goes to bot 2\r\nvalue 3 goes to bot 1\r\nbot 1 gives low to bot 3 and high to bot 2\r\nbot 2 gives low to bot 3 and high to bot 1", 1, 2) == 3);
        }

        [Fact]
        public void Part1_Ex()
        {
            verses = new Verses2016Day10();
            string input = "value 5 goes to bot 2\r\nbot 2 gives low to bot 1 and high to bot 0\r\nvalue 3 goes to bot 1\r\nbot 1 gives low to output 1 and high to bot 0\r\nbot 0 gives low to output 2 and high to output 0\r\nvalue 2 goes to bot 2";
            Assert.True(verses.Part1(input, 5, 2) == 2);
        }

        [Fact]
        public void Part1_Part1()
        {
            verses = new Verses2016Day10();
            Assert.True(verses.Part1(ReadTextSource("10.txt"), 61, 17) == 47);
        }

        [Fact]
        public void Part2_Part2()
        {
            verses = new Verses2016Day10();
            Assert.True(verses.Part2(ReadTextSource("10.txt"), -1, -1) == 2666);
        }
    }
}
