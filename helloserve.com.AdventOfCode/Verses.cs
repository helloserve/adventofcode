using helloserve.com.AdventOfCode.Models.Day2;
using helloserve.com.AdventOfCode.Models.Day3;
using helloserve.com.AdventOfCode.Models.Day5;
using helloserve.com.AdventOfCode.Models.Day6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public static class Verses
    {
        private static int[] Day1(string input)
        {
            char c;
            int[] floors = new int[input.Length];
            int floor = 0;
            for (int i = 0; i < input.Length; i++)
            {
                c = input[i];
                if (c == '(')
                    floor++;
                if (c == ')')
                    floor--;

                floors[i] = floor;
            }
            return floors;
        }

        public static int Day1_Part1(string input)
        {
            int[] floors = Day1(input);
            return floors[floors.Length - 1];
        }

        public static int Day1_Part2(string input)
        {
            int[] floors = Day1(input);
            for (int i = 0; i < floors.Length; i++)
            {
                if (floors[i] == -1)
                    return i + 1;
            }

            return floors.Length;
        }

        public static int Day2_Part1(string input)
        {
            string[] packages = input.Split(new char[] { '\n' });
            int totalArea = 0;
            foreach (string package in packages)
            {
                string[] dimensions = package.Split(new char[] { 'x' });
                int l = int.Parse(dimensions[0]);
                int w = int.Parse(dimensions[1]);
                int h = int.Parse(dimensions[2]);

                Present present = new Present(l, w, h);

                totalArea += present.PackageArea;
            }
            return totalArea;
        }

        public static int Day2_Part2(string input)
        {
            string[] packages = input.Split(new char[] { '\n' });
            int totalArea = 0;
            foreach (string package in packages)
            {
                string[] dimensions = package.Split(new char[] { 'x' });
                int l = int.Parse(dimensions[0]);
                int w = int.Parse(dimensions[1]);
                int h = int.Parse(dimensions[2]);

                Present present = new Present(l, w, h);

                totalArea += present.LintArea;
            }
            return totalArea;
        }

        public static int Day3_Part1(string input)
        {
            List<House> houses = new List<House>();

            House house = House.GetHouse(ref houses, 0, 0);
            house.Presents++;

            foreach (char c in input)
            {
                switch (c)
                {
                    case '^':
                        house = house.GoNorth(ref houses);
                        break;
                    case 'v':
                        house = house.GoSouth(ref houses);
                        break;
                    case '<':
                        house = house.GoWest(ref houses);
                        break;
                    case '>':
                        house = house.GoEast(ref houses);
                        break;
                }

                house.Presents++;
            }

            return house.TotalWithAtLeastOnePresent();
        }

        public static int Day3_Part2(string input)
        {
            List<House> houses = new List<House>();

            House houseBySanta = House.GetHouse(ref houses, 0, 0);
            houseBySanta.Presents++;

            House houseByRobo = House.GetHouse(ref houses, 0, 0);
            houseByRobo.Presents++;

            House currentHouse = houseBySanta;
            House nextHouse = houseBySanta;

            foreach (char c in input)
            {
                switch (c)
                {
                    case '^':
                        nextHouse = currentHouse.GoNorth(ref houses);
                        break;
                    case 'v':
                        nextHouse = currentHouse.GoSouth(ref houses);
                        break;
                    case '<':
                        nextHouse = currentHouse.GoWest(ref houses);
                        break;
                    case '>':
                        nextHouse = currentHouse.GoEast(ref houses);
                        break;
                }

                nextHouse.Presents++;

                if (currentHouse == houseBySanta)
                {
                    houseBySanta = nextHouse;
                    currentHouse = houseByRobo;
                }
                else
                {
                    houseByRobo = nextHouse;
                    currentHouse = houseBySanta;
                }
            }

            return houses[0].TotalWithAtLeastOnePresent();
        }

        public static int Day4(string input, int zeroCount = 5)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

            string hashCrit = "".PadLeft(zeroCount, '0');
            int lowerBound = 100000;
            int upperBound = (int)Math.Pow(10, input.Length + 1);
            string hash = string.Empty;
            for (int i = 0; i < upperBound; i++)
            {
                byte[] buff = ASCIIEncoding.ASCII.GetBytes(string.Format("{0}{1}", input, i + lowerBound));
                hash = BitConverter.ToString(md5.ComputeHash(buff)).Replace("-", string.Empty);

                if (hash.StartsWith(hashCrit))
                    return i + lowerBound;
            }

            return 0;
        }

        #region Day4 Non brute force
        //public static int Day4(string input)
        //{
        //    uint[] s = new uint[64] { 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 5, 9, 14, 20, 5, 9, 14, 20, 5, 9, 14, 20, 5, 9, 14, 20, 4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23, 6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21 };
        //    uint[] K = new uint[64];
        //    for (int i = 0; i < 64; i++)
        //    {
        //        K[i] = (uint)Math.Floor(4294967296 * Math.Abs(Math.Sin(i + 1)));
        //    }

        //    uint a0 = 0x67452301;   //A
        //    uint b0 = 0xefcdab89;   //B
        //    uint c0 = 0x98badcfe;   //C
        //    uint d0 = 0x10325476;   //D

        //    byte[] message = ASCIIEncoding.ASCII.GetBytes(input);
        //}
        #endregion

        public static int Day5_Part1(string input)
        {
            string[] lines = input.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int niceCount = 0;
            foreach (string line in lines)
            {
                NiceString str = new NiceString(line);
                if (str.IsNice())
                    niceCount++;
            }

            return niceCount;
        }

        public static int Day5_Part2(string input)
        {
            string[] lines = input.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int niceCount = 0;
            foreach (string line in lines)
            {
                NicerString str = new NicerString(line);
                if (str.IsNice())
                    niceCount++;
            }

            return niceCount;
        }

        public static int Day6_Part1(string input)
        {
            LightGrid grid = new LightGrid();
            string[] commands = input.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string command in commands)
            {
                grid.ProcessCommand(command);
            }

            return grid.NumberOfLightsOn;
        }

        public static int Day6_Part2(string input)
        {
            BrightGrid grid = new BrightGrid();
            string[] commands = input.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string command in commands)
            {
                grid.ProcessCommand(command);
            }

            return grid.NumberOfLightsOn;
        }

        public static int Day7_Part1(string input, string wireToReport)
        {

        }
    }
}
