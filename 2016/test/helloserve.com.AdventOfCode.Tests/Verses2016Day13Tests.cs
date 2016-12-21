using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day13Tests
    {
        [Fact]
        public void Part1_BaseValue()
        {
            Node node = new Node(0, 0, 1, 0);
            Assert.True(node.BaseValue() == 1);
            node = new Node(1, 1, 1, 0);
            Assert.True(node.BaseValue() == 9);
        }

        [Fact]
        public void Part1_Binary()
        {
            Node node = new Node();
            Assert.True(node.Binary(1) == "00000000000000000000000000000001");
            Assert.True(node.Binary(9) == "00000000000000000000000000001001");
            Assert.True(node.Binary(256) == "00000000000000000000000100000000");
            Assert.True(node.Binary(257) == "00000000000000000000000100000001");
        }

        [Fact]
        public void Part1_OnBits()
        {
            Node node = new Node();
            Assert.True(node.OnBits("100") == 1);
            Assert.True(node.OnBits("101") == 2);
            Assert.True(node.OnBits("111") == 3);
        }

        [Fact]
        public void Part1_IsWall()
        {
            Node node = new Node(0, 0, 1, 0);
            Assert.False(node.IsOpen);
            node = new Node(0, 0, 3, 0);
            Assert.True(node.IsOpen);
            node = new Node(0, 0, 257, 0);
            Assert.True(node.IsOpen);
            node = new Node(0, 0, 259, 0);
            Assert.False(node.IsOpen);
        }

        [Fact]
        public void Part1_Ex()
        {
            Verses2016Day13 verses = new Verses2016Day13();
            Assert.True(verses.Part1(1, 1, 10, 7, 4) == 11);
        }

        [Fact]
        public void Part1_Part1()
        {
            Verses2016Day13 verses = new Verses2016Day13();
            Assert.True(verses.Part1(1, 1, 1350, 31, 39) == 92);
        }

        [Fact]
        public void Part2_Part2()
        {
            Verses2016Day13 verses = new Verses2016Day13();
            Assert.True(verses.Part2(1, 1, 1350) == 124);
        }
    }
}
