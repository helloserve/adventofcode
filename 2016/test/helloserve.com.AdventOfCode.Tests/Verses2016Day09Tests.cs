using helloserve.com.AdventOfCode.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day09Tests : TestClass
    {
        private Verses2016Day09 verses = new Verses2016Day09();

        [Fact]
        public void Part1_Decompress()
        {
            Assert.True(verses.Decompress("A") == "A");
            Assert.True(verses.Decompress("(1x2)A") == "AA");
            Assert.True(verses.Decompress("(1x2)ABC") == "AABC");
            Assert.True(verses.Decompress("A(1x2)BC") == "ABBC");
            Assert.True(verses.Decompress("AB(1x2)C") == "ABCC");
            Assert.True(verses.Decompress("A(5x2)BCDEFGH") == "ABCDEFBCDEFGH");
            Assert.True(verses.Decompress("A(10x2)B(4x4)FGHIJK") == "AB(4x4)FGHIB(4x4)FGHIJK");

            Assert.True(verses.Decompress("ADVENT") == "ADVENT");
            Assert.True(verses.Decompress("A(1x5)BC") == "ABBBBBC");
            Assert.True(verses.Decompress("(3x3)XYZ") == "XYZXYZXYZ");
            Assert.True(verses.Decompress("A(2x2)BCD(2x2)EFG") == "ABCBCDEFEFG");
            Assert.True(verses.Decompress("(6x1)(1x3)A") == "(1x3)A");
            Assert.True(verses.Decompress("X(8x2)(3x3)ABCY") == "X(3x3)ABC(3x3)ABCY");
        }

        [Fact]
        public void Part1_Ex()
        {
            Assert.True(verses.Part1("ADVENT") == 6);
            Assert.True(verses.Part1("A(1x5)BC") == 7);
            Assert.True(verses.Part1("(3x3)XYZ") == 9);
            Assert.True(verses.Part1("A(2x2)BCD(2x2)EFG") == 11);
            Assert.True(verses.Part1("(6x1)(1x3)A") == 6);
            Assert.True(verses.Part1("X(8x2)(3x3)ABCY") == 18);
        }

        [Fact]
        public void Part1_Part1()
        {
            Assert.True(verses.Part1(ReadTextSource("9.txt")) == 152851);
        }

        [Fact]
        public void Part2_Ex()
        {
            Assert.True(verses.Part2("ADVENT") == 6);
            Assert.True(verses.Part2("A(1x5)BC") == 7);
            Assert.True(verses.Part2("(3x3)XYZ") == 9);
            Assert.True(verses.Part2("A(2x2)BCD(2x2)EFG") == 11);
            Assert.True(verses.Part2("(6x1)(1x3)A") == 3);
            Assert.True(verses.Part2("X(8x2)(3x3)ABCY") == 20);
        }


        [Fact]
        public void Part2_Part2()
        {
            Assert.True(verses.Part2(ReadTextSource("9.txt")) == 11797310782);
        }
    }
}
