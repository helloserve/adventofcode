using helloserve.com.AdventOfCode.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day22Tests : TestClass
    {
        [Fact]
        public void Part1_SetupNode()
        {
            ServerNode node = new ServerNode(0, 0, 94, 73);
            Assert.True(node.X == 0);
            Assert.True(node.Y == 0);
            Assert.True(node.Size == 94);
            Assert.True(node.Used == 73);
            Assert.True(node.Available == 21);
            Assert.True(node.UsePC == 77);

            node = new ServerNode(0, 1, 87, 64);
            Assert.True(node.X == 0);
            Assert.True(node.Y == 1);
            Assert.True(node.Size == 87);
            Assert.True(node.Used == 64);
            Assert.True(node.Available == 23);
            Assert.True(node.UsePC == 73);
        }

        [Fact]
        public void Part1_Part1()
        {
            Verses2016Day22 verses = new Verses2016Day22();
            Assert.True(verses.Part1(ReadTextSource("22.txt")) == 934);
        }

        [Fact]
        public void Part2_Part2()
        {
            Verses2016Day22 verses = new Verses2016Day22();
            Assert.True(verses.Part2(ReadTextSource("22.txt")) == 7);
        }
    }
}
