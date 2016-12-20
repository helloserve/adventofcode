using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day13
    {
        public int BaseValue(int x, int y, int fav)
        {
            return x * x + 3 * x + 2 * x * y + y + y * y + fav;
        }

        public string Binary(int v)
        {
            byte[] buffer = BitConverter.GetBytes(v);
            string bufferStr = string.Empty;
            for (int i = buffer.Length - 1; i > 0; i--)
            {
                bufferStr = $"{bufferStr}{Convert.ToString(buffer[i], 2).PadLeft(8, '0')}";
            }
            bufferStr = $"{bufferStr}{Convert.ToString(buffer[0], 2).PadLeft(8, '0')}";

            return bufferStr;
        }

        public int OnBits(string binary)
        {
            return binary.Replace("0", "").Length;
        }

        public bool IsOpen(int x, int y, int seed)
        {
            return OnBits(Binary(BaseValue(x, y, seed))) % 2 == 0;
        }

        public int DistanceBetween(int sx, int sy, int dx, int dy)
        {
            return (int)Math.Round(Math.Sqrt(Math.Pow(sx - dx, 2) + Math.Pow(sy - dy, 2)));
        }

        public int Route(Node startNode, int seed, int destX, int destY)
        {
            return 0;
        }

        public int Part1(int startX, int startY, int seed, int destX, int destY)
        {
            return Route(new Node()
            {
                X = startX,
                Y = startY,
                IsOpen = IsOpen(startX, startY, seed),
                DistanceFrom = 0,
                DistanceTo = DistanceBetween(startX, startY, destX, destY)
            }, seed, destX, destY);
        }
    }

    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsOpen { get; set; }
        public bool Visited { get; set; }
        public int DistanceFrom { get; set; }
        public int DistanceTo { get; set; }
    }
}
