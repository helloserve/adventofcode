using helloserve.com.AdventOfCode.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day15
    {
        public int Part1(string input)
        {
            List<Disc> discs = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => ParseDisc(x)).ToList();
            int t = 0;
            bool thoroughfare;
            while (true)
            {
                thoroughfare = true;
                for (int i = 0; i < discs.Count; i++)
                {
                    thoroughfare &= discs[i].PositionAfterT(t + i + 1) == 0;
                    if (!thoroughfare)
                        break;
                }
                if (thoroughfare)
                    return t;
                t++;
            }
        }

        private Disc ParseDisc(string def)
        {
            Regex regex = new Regex(@"Disc #(?<discNumber>\d*) has (?<positions>\d*) positions; at time=0, it is at position (?<startPosition>\d*).");
            Match match = regex.Match(def);
            if (match.Success)
            {
                return new Disc()
                {
                    Number = int.Parse(match.Groups["discNumber"].Value),
                    TotalPositions = int.Parse(match.Groups["positions"].Value),
                    StartPosition = int.Parse(match.Groups["startPosition"].Value)
                };
            }

            throw new ArgumentException();
        }
    }

    public class Disc
    {
        public int Number { get; set; }
        public int TotalPositions { get; set; }
        public int StartPosition { get; set; }        

        public int PositionAfterT(int time)
        {
            int position = StartPosition + time;
            while (position >= TotalPositions)
            {
                position = position - TotalPositions;
            }
            return position;
        }
    }
}
