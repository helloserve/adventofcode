using helloserve.com.AdventOfCode.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day07Tests : TestClass
    {
        private Verses2016Day07 verses = new Verses2016Day07();

        [Fact]
        public void Part1_ParseIp()
        {
            string[] ipParts = verses.ParseIp("aaaa[bbbb]cccc");
            Assert.True(ipParts.Length == 3);
            Assert.True(ipParts[0] == "aaaa");
            Assert.True(ipParts[1] == "bbbb");
            Assert.True(ipParts[2] == "cccc");
        }

        [Fact]
        public void Part1_ContainsAbba()
        {
            Assert.False(verses.ContainsAbba("aaaa"));
            Assert.False(verses.ContainsAbba("ergt"));
            Assert.True(verses.ContainsAbba("oxxo"));
            Assert.False(verses.ContainsAbba("oxox"));
            Assert.False(verses.ContainsAbba("oxo"));
            Assert.True(verses.ContainsAbba("pooxxop"));
        }

        [Fact]
        public void Part1_IsTls()
        {
            Assert.False(verses.IsTls("a[b]"));
            Assert.False(verses.IsTls("aaaa[b]c"));
            Assert.False(verses.IsTls("aaaa[bbbb]cccc"));
            Assert.True(verses.IsTls("abba[mnop]qrst"));
            Assert.False(verses.IsTls("abcd[bddb]xyyx"));
            Assert.False(verses.IsTls("aaaa[qwer]tyui"));
            Assert.True(verses.IsTls("nioxxoj[asdfgh]zxcvbn"));
        }

        [Fact]
        public void Part1_Ex()
        {
            string input = "abba[mnop]qrst\r\nabcd[bddb]xyyx\r\naaaa[qwer]tyui\r\nioxxoj[asdfgh]zxcvbn";
            Assert.True(verses.Part1(input) == 2);
        }

        [Fact]
        public void Part1_Part1()
        {
            Assert.True(verses.Part1(ReadTextSource("7.txt")) == 2);
        }
    }
}
