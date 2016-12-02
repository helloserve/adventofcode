using helloserve.com.AdventOfCode.Tests.Base;
using System;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day01 : TestClass
    {
        AdventOfCode.Verses2016Day01 verses = new AdventOfCode.Verses2016Day01();
        
        [Fact]
        public void Part1_L0Zero() 
        {
            Assert.True(verses.Part1("L0") == 0);
        }

        [Fact]
        public void Part1_L1_1()
        {
            Assert.True(verses.Part1("L1") == 1);
        }

        [Fact]
        public void Part1_L1R1_2()
        {
            Assert.True(verses.Part1("L1, R1") == 2);
        }

        [Fact]
        public void Part1_L5L0L5_Zero()
        {
            Assert.True(verses.Part1("L5, L0, L5") == 0);
        }

        [Fact]
        public void Part1_R5R0R5_Zero()
        {
            Assert.True(verses.Part1("R5, R0, R5") == 0);
        }
        
        [Fact]
        public void Part1_StepsNW()
        {
            Assert.True(verses.Part1("L1, R1, L1, R1, L1") == 5);
        }

        [Fact]
        public void Part1_Ex1()
        {
            Assert.True(verses.Part1("R2, L3") == 5);
        }

        [Fact]
        public void Part1_Ex2()
        {
            Assert.True(verses.Part1("R2, R2, R2") == 2);
        }

        [Fact]
        public void Part1_Ex3()
        {
            Assert.True(verses.Part1("R5, L5, R5, R3") == 12);
        }

        [Fact]
        public void Part1_Part1()
        {
            Assert.True(verses.Part1(ReadTextSource("1.txt")) == 278);
        }

        [Fact]
        public void Part2_Ex1()
        {
            Assert.True(verses.Part2("R8, R4, R4, R8") == 4);
        }

        [Fact]
        public void Part2_Part2()
        {
            Assert.True(verses.Part2(ReadTextSource("1.txt")) == 161);
        }
    }
}
