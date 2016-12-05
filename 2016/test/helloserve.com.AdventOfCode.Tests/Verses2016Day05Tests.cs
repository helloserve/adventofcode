using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day05Tests
    {
        private Verses2016Day05 verses = new Verses2016Day05();

        [Fact]
        public void Par1t1_Ex1()
        {            
            //Assert.True(verses.GetCodeItem("abc", 3231929, 1) == "1");
            Assert.True(verses.GetCodeItem("abc", 5017308, 1) == "8");

            //Assert.True(verses.Part1("abc") == "1");
        }
    }
}
