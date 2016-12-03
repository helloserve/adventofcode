using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Triangle
    {
        public int Side1 { get; set; }
        public int Side2 { get; set; }
        public int Side3 { get; set; }

        public Triangle(string input)
        {
            string[] values = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Side1 = int.Parse(values[0].Trim());
            Side2 = int.Parse(values[1].Trim());
            Side3 = int.Parse(values[2].Trim());
        }

        public bool IsValid
        {
            get
            {
                return (Side1 + Side2 > Side3) &&
                       (Side1 + Side3 > Side2) &&
                       (Side2 + Side3 > Side1);
            }
        }
    }

    public class Verses2016Day03
    {
        public int Part1(string input)
        {
            List<string> lines = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return lines.Select(l => new Triangle(l)).Sum(x => x.IsValid ? 1 : 0);            
        }

    }
}
