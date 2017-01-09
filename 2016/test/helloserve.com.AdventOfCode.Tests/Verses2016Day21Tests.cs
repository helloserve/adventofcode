using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day21Tests
    {
        [Fact]
        public void Part1_Steps()
        {
            Verses2016Day21 verses = new Verses2016Day21();
            Assert.True(verses.SwapPos("ab", 0, 1) == "ba");
            Assert.True(verses.SwapLet("hello", 'l', 'o') == "heool");
            Assert.True(verses.RotateLeft("abcd") == "bcda");
            Assert.True(verses.RotateRight("abcd", 1) == "dabc");
            Assert.True(verses.RotateRight("abcd", 2) == "cdab");
            Assert.True(verses.RotatePos("abcdefghijk", 'd') == "hijkabcdefg");
            Assert.True(verses.RotatePos("abcdefghijk", 'e') == "fghijkabcde");
            Assert.True(verses.Reverse("abcdefg", 'b', 'f') == "afedcbg");
            Assert.True(verses.Move("abcdefg", 1, 4) == "acdebfg");
        }

        [Fact]
        public void Part1_Ex()
        {
            Verses2016Day21 verses = new Verses2016Day21();
            string input = "abcde";
            input = verses.SwapPos(input, 4, 0);
            Assert.True(input == "ebcda");
            input = verses.SwapLet(input, 'd', 'b');
            Assert.True(input == "edcba");
        }
    }
}
