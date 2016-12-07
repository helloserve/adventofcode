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
            Assert.True(ipParts.Length == 2);
            Assert.True(ipParts[0] == "aaaa_cccc");
            Assert.True(ipParts[1] == "_bbbb");
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
            Assert.False(verses.IsTls("aaab[qwer]baui"));
            Assert.True(verses.IsTls("nioxxoj[asdfgh]zxcvbn"));
            Assert.False(verses.IsTls("qawsedrf[azsxdcfv]qawsedf[azsxdcfv]qawsedrf"));
            Assert.True(verses.IsTls("ghgtergeg[fewfewgwg]gewgoxxog[frfedsds]fwgfgwggw"));
            Assert.False(verses.IsTls("ghgtergeg[fewfewgwg]gewgoxxog[oxxodsds]fwgfgwggw"));
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
            Assert.True(verses.Part1(ReadTextSource("7.txt")) == 110);
        }

        [Fact]
        public void Part2_ContainsAba()
        {
            Assert.True(verses.ContainsAba("eabaewf")[0] == "aba");
            Assert.True(verses.ContainsAba("exyxewf", new char[] { 'a', 'b' }).Length == 0);
            Assert.True(verses.ContainsAba("exyxewf", new char[] { 'x', 'y' })[0] == "xyx");
            Assert.True(verses.ContainsAba("exyxexwf")[0] == "xyx");
            Assert.True(verses.ContainsAba("exyxexwf")[1] == "xex");
            Assert.True(verses.ContainsAba("exyxexwf", new char[] { 'x', 'y' })[0] == "xyx");
            Assert.True(verses.ContainsAba("exyxexwf", new char[] { 'x', 'e' })[0] == "xex");

            Assert.True(verses.ContainsAba("ebabewf")[0] == "bab");
            Assert.True(verses.ContainsAba("eyxyewf", new char[] { 'a', 'b' }).Length == 0);
            Assert.True(verses.ContainsAba("eyxyewf", new char[] { 'y', 'x' })[0] == "yxy");
        }

        [Fact]
        public void Part2_IsSsl()
        {
            Assert.False(verses.IsSsl("a[b]"));
            Assert.False(verses.IsSsl("aaaa[b]c"));
            Assert.False(verses.IsSsl("aaaa[bbbb]cccc"));
            Assert.True(verses.IsSsl("aba[bab]qrst"));
            Assert.False(verses.IsSsl("abcd[bddb]xyx"));
            Assert.True(verses.IsSsl("aaaa[yxy]xyx"));
            Assert.False(verses.IsSsl("aaab[aaa]baui"));

            Assert.True(verses.IsSsl("aba[bab]xyz"));
            Assert.False(verses.IsSsl("xyx[xyx]xyx"));
            Assert.True(verses.IsSsl("aaa[kek]eke"));
            Assert.True(verses.IsSsl("zazbz[bzb]cdb"));
        }

        [Fact]
        public void Part2_Ex()
        {
            string input = "aba[bab]xyz\r\nxyx[xyx]xyx\r\naaa[kek]eke\r\nzazbz[bzb]cdb";
            Assert.True(verses.Part2(input) == 3);
        }

        [Fact]
        public void Part2_Part2()
        {
            Assert.True(verses.Part2(ReadTextSource("7.txt")) == 242);
        }
    }
}
