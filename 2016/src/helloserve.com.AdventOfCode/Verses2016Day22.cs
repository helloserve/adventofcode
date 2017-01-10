using helloserve.com.AdventOfCode.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day22 : Verses2016
    {
        ServerNode[] _nodes;
        int _width;
        int _height;
        int _targetX;
        int _targetY;

        public int Part1(string input)
        {
            Setup(input);

            ServerNode node1;
            ServerNode node2;

            int viablePairs = 0;

            for (int i = 0; i < _nodes.Length; i++)
            {
                for (int j = 0; j < _nodes.Length; j++)
                {
                    if (i == j)
                        continue;

                    node1 = _nodes[i];

                    if (node1.Used == 0)
                        continue;

                    node2 = _nodes[j];

                    if (node1.Used < node2.Available)
                        viablePairs++;
                }
            }

            return viablePairs;
        }

        public int Part2(string input)
        {
            InitializeOutput(@".\output\22.txt");
            Setup(input);
            _targetX = _width - 1;
            _targetY = 0;
            LogGrid();
            return 0;
        }

        private void Setup(string input)
        {
            Regex regex = new Regex(@"\/dev\/grid\/node-x(?<X>\d*)-y(?<Y>\d*)\s*(?<Size>\d*)T\s*(?<Used>\d*)T\s*(?<Avail>\d*)T\s*(?<UsePC>\d*)%");
            Match match = regex.Match(input);
            ServerNode node;
            List<ServerNode> nodes = new List<ServerNode>();
            while (match.Success)
            {
                node = new AdventOfCode.ServerNode(
                    int.Parse(match.Groups["X"].Value),
                    int.Parse(match.Groups["Y"].Value),
                    int.Parse(match.Groups["Size"].Value),
                    int.Parse(match.Groups["Used"].Value));

                _width = Math.Max(node.X, _width);
                _height = Math.Max(node.Y, _height);

                nodes.Add(node);

                match = match.NextMatch();
            }

            _width++;
            _height++;
            _nodes = new ServerNode[_width * _height];

            foreach (ServerNode n in nodes)
            {
                _nodes[GetIndex(n.X, n.Y)] = n;
            }
        }

        private int GetIndex(int x, int y)
        {
            return y * _height + x;
        }

        private void LogGrid()
        {
            StringBuilder blr = new StringBuilder();
            ServerNode node;
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (x == 0 && y == 0)
                        blr.Append("*");
                    else
                    {
                        node = _nodes[GetIndex(x, y)];

                        if (node.Used == 0)
                            blr.Append("_");
                        else if (node.X == _targetX && node.Y == _targetY)
                            blr.Append("G");
                        else
                            blr.Append(".");
                    }
                }
                blr.Append("\r\n");
            }

            LogOutput(@".\output\22.txt", blr.ToString());
        }
    }

    public class ServerNode
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public int Used { get; set; }

        public ServerNode(int x, int y, int size, int used)
        {
            X = x;
            Y = y;
            Size = size;
            Used = used;
        }

        public int Available
        {
            get { return Size - Used; }
        }

        public int UsePC
        {
            get { return (int)Math.Truncate((decimal)Used / (decimal)Size * 100M); }
        }
    }
}
