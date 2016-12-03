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
            Initialize(values[0], values[1], values[2]);
        }

        public Triangle(string side1, string side2, string side3)
        {
            Initialize(side1, side2, side3);
        }

        private void Initialize(string side1, string side2, string side3)
        {
            Side1 = int.Parse(side1.Trim());
            Side2 = int.Parse(side2.Trim());
            Side3 = int.Parse(side3.Trim());
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

        public int Part2(string input)
        {
            string[] lines = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            List<Triangle> triangles = new List<AdventOfCode.Triangle>();
            for (int i = 0; i + 2 < lines.Length; i += 3)
            {
                string[] line1 = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] line2 = lines[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] line3 = lines[i + 2].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                triangles.Add(new Triangle(line1[0], line2[0], line3[0]));
                triangles.Add(new Triangle(line1[1], line2[1], line3[1]));
                triangles.Add(new Triangle(line1[2], line2[2], line3[2]));
            }

            return triangles.Sum(x => x.IsValid ? 1 : 0);
        }
    }
}
