using helloserve.com.AdventOfCode.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day20Tests : TestClass
    {
        [Fact]
        public void Part1_Ex()
        {
            Verses2016Day20 verses = new Verses2016Day20();
            Assert.True(verses.Part1("5-8\r\n0-2\r\n4-7") == 3);
        }

        [Fact]
        public void Part1_Part1()
        {
            Verses2016Day20 verses = new Verses2016Day20();
            Assert.True(verses.Part1(ReadTextSource("20.txt")) == 32259706);
        }

        [Fact]
        public void Part2_Ex()
        {
            Verses2016Day20 verses = new Verses2016Day20();
            Assert.True(verses.Part2("5-8\r\n0-2\r\n4-7", 0, 9) == 2);
            Assert.True(verses.Part2("5-8", 0, 20) == 17);
        }

        [Fact]
        public void Part2_Combine()
        {
            IpRange range = new IpRange("100-200");
            Assert.True(range.TryCombine(new IpRange("90-101")));
            Assert.True(range.Low == 90 && range.High == 200);
            Assert.True(range.TryCombine(new IpRange("190-500")));
            Assert.True(range.Low == 90 && range.High == 500);
            Assert.True(range.TryCombine(new IpRange("150-350")));
            Assert.True(range.Low == 90 && range.High == 500);
            Assert.True(range.TryCombine(new IpRange("50-550")));
            Assert.True(range.Low == 50 && range.High == 550);
            Assert.False(range.TryCombine(new IpRange("10-49")));
        }

        [Fact]
        public void Part2_Part2()
        {
            Verses2016Day20 verses = new Verses2016Day20();
            Assert.True(verses.Part2(ReadTextSource("20.txt"), 0, 4294967295) == 113);
        }
    }
}
