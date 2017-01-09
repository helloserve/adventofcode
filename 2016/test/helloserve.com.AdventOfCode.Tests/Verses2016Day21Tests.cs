using helloserve.com.AdventOfCode.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day21Tests : TestClass
    {
        [Fact]
        public void Part1_Steps()
        {
            Verses2016Day21 verses = new Verses2016Day21();
            Assert.True(verses.SwapPos("ab", 0, 1) == "ba");
            Assert.True(verses.SwapLet("hello", 'l', 'o') == "heool");
            Assert.True(verses.RotateLeft("abcd", 1) == "bcda");
            Assert.True(verses.RotateLeft("abcd", 2) == "cdab");
            Assert.True(verses.RotateRight("abcd", 1) == "dabc");
            Assert.True(verses.RotateRight("abcd", 2) == "cdab");
            Assert.True(verses.RotatePos("abcdefghijk", 'd') == "hijkabcdefg");
            Assert.True(verses.RotatePos("abcdefghijk", 'e') == "fghijkabcde");
            Assert.True(verses.Reverse("abcdefg", 1, 5) == "afedcbg");
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
            input = verses.Reverse(input, 0, 4);
            Assert.True(input == "abcde");
            input = verses.RotateLeft(input, 1);
            Assert.True(input == "bcdea");
            input = verses.Move(input, 1, 4);
            Assert.True(input == "bdeac");
            input = verses.Move(input, 3, 0);
            Assert.True(input == "abdec");
            input = verses.RotatePos(input, 'b');
            Assert.True(input == "ecabd");
            input = verses.RotatePos(input, 'd');
            Assert.True(input == "decab");

            input = "abcde";
            StringBuilder blr = new StringBuilder();
            blr.AppendLine("swap position 4 with position 0");
            blr.AppendLine("swap letter d with letter b");
            blr.AppendLine("reverse positions 0 through 4");
            blr.AppendLine("rotate left 1 step");
            blr.AppendLine("move position 1 to position 4");
            blr.AppendLine("move position 3 to position 0");
            blr.AppendLine("rotate based on position of letter b");
            blr.AppendLine("rotate based on position of letter d");
            input = verses.Part1(blr.ToString(), input);
            Assert.True(input == "decab");
        }

        [Fact]
        public void Part1_Part1()
        {
            Verses2016Day21 verses = new Verses2016Day21();
            Assert.True(verses.Part1(ReadTextSource("21.txt"), "abcdefgh") == "gbhcefad");
        }

        [Fact]
        public void Part2_Ex()
        {
            Verses2016Day21 verses = new Verses2016Day21();
            string input = "decab";
            input = verses.RotatePosReverse(input, 'd');
            Assert.True(input == "ecabd");
            input = verses.RotatePosReverse(input, 'b');
            Assert.True(input == "abdec");
            input = verses.Move(input, 0, 3);
            Assert.True(input == "bdeac");
            input = verses.Move(input, 4, 1);
            Assert.True(input == "bcdea");
            input = verses.RotateRight(input, 1);
            Assert.True(input == "abcde");
            input = verses.Reverse(input, 0, 4);
            Assert.True(input == "edcba");
            input = verses.SwapLet(input, 'b', 'd');
            Assert.True(input == "ebcda");
            input = verses.SwapPos(input, 4, 0);
            Assert.True(input == "abcde");

            input = "decab";
            StringBuilder blr = new StringBuilder();
            blr.AppendLine("swap position 4 with position 0");
            blr.AppendLine("swap letter d with letter b");
            blr.AppendLine("reverse positions 0 through 4");
            blr.AppendLine("rotate left 1 step");
            blr.AppendLine("move position 1 to position 4");
            blr.AppendLine("move position 3 to position 0");
            blr.AppendLine("rotate based on position of letter b");
            blr.AppendLine("rotate based on position of letter d");
            input = verses.Part2(blr.ToString(), input);
            Assert.True(input == "abcde");
        }

        [Fact]
        public void Part2_Part2()
        {
            Verses2016Day21 verses = new Verses2016Day21();
            Assert.True(verses.Part2(ReadTextSource("21.txt"), "fbgdceah") == "gahedfcb");
        }
    }
}
