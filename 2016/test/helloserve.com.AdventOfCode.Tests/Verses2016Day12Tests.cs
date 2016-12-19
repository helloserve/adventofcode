using helloserve.com.AdventOfCode.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day12Tests : TestClass
    {
        private Verses2016Day12 verses = new Verses2016Day12();

        [Fact]
        public void Part1_Cpy()
        {
            int register = 0;
            verses.Cpy(1, ref register);
            Assert.True(register == 1);
        }

        [Fact]
        public void Part1_Inc()
        {
            int register = 0;
            verses.Inc(ref register);
            Assert.True(register == 1);
        }

        [Fact]
        public void Part1_Dec()
        {
            int register = 0;
            verses.Dec(ref register);
            Assert.True(register == -1);
        }

        [Fact]
        public void Part1_Jnz()
        {
            int register = 1;
            int register2 = 1;
            Assert.True(verses.Jnz(register, register2) == 1);

            register = 0;
            Assert.True(verses.Jnz(register, register2) == 1);

            register = 1;
            register2 = -3;
            Assert.True(verses.Jnz(register, register2) == -3);
        }

        [Fact]
        public void Part1_Simple()
        {
            Verses2016Day12 v = new Verses2016Day12();
            Assert.True(v.Part1("cpy 1 a", "a") == 1);
            v = new Verses2016Day12();
            Assert.True(v.Part1("cpy 1 a\r\ninc a", "a") == 2);
            v = new Verses2016Day12();
            Assert.True(v.Part1("cpy 1 a\r\ncpy 5 b\r\ncpy b a", "a") == 5);
            v = new Verses2016Day12();
            Assert.True(v.Part1("cpy 1 a\r\ndec a", "a") == 0);
            v = new Verses2016Day12();
            Assert.True(v.Part1("cpy 2 a\r\ndec a\r\njnz a -1\r\ncpy 3 a", "a") == 3);
        }

        [Fact]
        public void Part1_Ex()
        {            
            string input = "cpy 41 a\r\ninc a\r\ninc a\r\ndec a\r\njnz a 2\r\ndec a";
            Assert.True(verses.Part1(input, "a") == 42);
        }

        [Fact]
        public void Part1_Part1()
        {
            Assert.True(verses.Part1(ReadTextSource("12.txt"), "a") == 317993);
        }
    }
}
