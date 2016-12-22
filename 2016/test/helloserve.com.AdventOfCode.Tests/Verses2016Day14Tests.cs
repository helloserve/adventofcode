using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day14Tests
    {
        [Fact]
        public void Part1_Hash()
        {
            Verses2016Day14 verses = new Verses2016Day14();
            Assert.True(verses.Hash("abc18").Contains("cc38887a5"));
            Assert.True(verses.Hash("abc39").Contains("eee"));
        }

        [Fact]
        public void Part1_Contains3Chars()
        {
            Verses2016Day14 verses = new Verses2016Day14();
            Assert.True(verses.Contains3Chars("abcdddefg") == 'd');
            Assert.True(verses.Contains3Chars("abcddd") == 'd');
            Assert.True(verses.Contains3Chars("abcdefg") == null);
        }

        [Fact]
        public void Part1_Contains5Chars()
        {
            Verses2016Day14 verses = new Verses2016Day14();
            Assert.True(verses.Contains5Chars("abcdddddefg", 'd'));
            Assert.False(verses.Contains5Chars("abcdddddefg", 'e'));
            Assert.False(verses.Contains5Chars("abcdefg", 'd'));
        }

        [Fact]
        public void Part1_Ex()
        {
            Verses2016Day14 verses = new Verses2016Day14();
            int val = verses.Part1("abc", 1);
            Assert.True(val == 39);
            verses = new Verses2016Day14();
            val = verses.Part1("abc", 2);
            Assert.True(val == 92);
            verses = new Verses2016Day14();
            val = verses.Part1("abc", 64);
            Assert.True(val == 22728);
        }

        [Fact]
        public void Part1_Part1()
        {
            Verses2016Day14 verses = new Verses2016Day14();
            int val = verses.Part1("zpqevtbw", 64);
            Assert.True(val == 16106);
        }

        [Fact]
        public void Part2_Hash()
        {
            Verses2016Day14 verses = new Verses2016Day14();
            string val = verses.Hash("abc0", stretchTo: 2016);
            Assert.True(val.StartsWith("a107ff"));
        }

        [Fact]
        public void Part2_Part2()
        {
            Verses2016Day14 verses = new Verses2016Day14();
            int val = verses.Part2("zpqevtbw", 64);
            Assert.True(val == 22423);
        }
    }
}
