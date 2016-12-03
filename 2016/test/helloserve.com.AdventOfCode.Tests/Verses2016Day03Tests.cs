using helloserve.com.AdventOfCode.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day03Tests : TestClass
    {
        public Verses2016Day03 verses = new Verses2016Day03();

        [Fact]
        public void Part1_Equilateral_1()
        {
            Assert.True(verses.Part1("1 1 1") == 1);
        }

        [Fact]
        public void Part1_Isosceles_1()
        {
            Assert.True(verses.Part1("2 2 1") == 1);
        }

        [Fact]
        public void Part1_Ex1()
        {
            Assert.True(verses.Part1("5 10 25") == 0);
        }

        [Fact]
        public void Part1_EquilateralIsoscelesEx1_2()
        {
            Assert.True(verses.Part1("1 1 1\r\n2 2 1\r\n5 10 25") == 2);
        }

        [Fact]
        public void Part1_Part1()
        {
            Assert.True(verses.Part1(ReadTextSource("3.txt")) == 869);
        }

        [Fact]
        public void Part2_InvalidInput()
        {
            Assert.True(verses.Part2("1 1 1") == 0);
            Assert.True(verses.Part2("1 1 1\r\n1 1 1") == 0);            
        }

        [Fact]
        public void Part2_3Lines2()
        {
            Assert.True(verses.Part2("1 2 1\r\n1 2 2\r\n1 2 3") == 2);
        }

        [Fact]
        public void Part2_Part2()
        {
            Assert.True(verses.Part2(ReadTextSource("3.txt")) == 1544);
        }
    }
}
