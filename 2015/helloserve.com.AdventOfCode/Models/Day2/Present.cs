using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Models.Day2
{
    public class Present
    {
        public int Length;
        public int Width;
        public int Height;

        public int PackageArea;
        public int LintArea;

        public Present(int l, int w, int h)
        {
            Length = l;
            Width = w;
            Height = h;

            CalculatePackageArea();

            CalculateLintArea();
        }

        private void CalculateLintArea()
        {
            int smallest = Length;
            int small = Width;
            if (Width < smallest)
            {
                small = smallest;
                smallest = Width;
            }

            if (Height < smallest)
            {
                small = smallest;
                smallest = Height;
            }
            else if (Height < small)
                small = Height;

            int lintArea = 2 * small + 2 * smallest;
            int bowArea = Length * Width * Height;

            LintArea = lintArea + bowArea;
        }

        private void CalculatePackageArea()
        {
            int area1 = Length * Width;
            int area2 = Width * Height;
            int area3 = Length * Height;
            int minArea = Math.Min(area3, Math.Min(area1, area2));

            PackageArea = 2 * area1 + 2 * area2 + 2 * area3 + minArea;
        }
    }
}
