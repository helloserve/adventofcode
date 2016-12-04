using helloserve.com.AdventOfCode.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests
{
    public class Verses2016Day04Tests : TestClass
    {
        Verses2016Day04 verses = new Verses2016Day04();

        [Fact]
        public void Part1_Simple_IsRoom_1()
        {
            Assert.True(verses.Part1("abcde-1[abcde]") == 1);            
            Assert.True(verses.Part1("xyabc-1[abcxy]") == 1);
            Assert.True(verses.Part1("aa-bb-cc-xy-1[abcxy]") == 1);
        }

        [Fact]
        public void Part1_Ex()
        {
            Assert.True(verses.Part1("aaaaa-bbb-z-y-x-123[abxyz]") == 123);
            Assert.True(verses.Part1("a-b-c-d-e-f-g-h-987[abcde]") == 987);            
            Assert.True(verses.Part1("not-a-real-room-404[oarel]") == 404);
            Assert.True(verses.Part1("totally -real-room-200[decoy]") == 0);

            Assert.True(verses.Part1("aaaaa-bbb-z-y-x-123[abxyz]\r\na-b-c-d-e-f-g-h-987[abcde]\r\nnot-a-real-room-404[oarel]\r\ntotally -real-room-200[decoy]") == 1514);
        }

        [Fact]
        public void Part1_Part1()
        {
            Assert.True(verses.Part1(ReadTextSource("4.txt")) == 361724);
        }

        [Fact]
        public void Part2_Room_Name()
        {
            Room room = new Room("abcde-1[abcde]");
            Assert.True(room.Name == "bcdef");
            room = new Room("qzmt-zixmtkozy-ivhz-343[abcxy]");
            Assert.True(room.Name == "very encrypted name");
        }

        [Fact]
        public void Part2_Part2()
        {
            verses.Part2(ReadTextSource("4.txt"), "Output\\4.2.txt");
        }
    }
}

