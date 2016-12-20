using helloserve.com.AdventOfCode.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day13 : Verses2016
    {
        int _seed;
        int _startX;
        int _startY;
        int _destX;
        int _destY;
        int _width;
        int _height;

        Dictionary<int, Node> _allNodes = new Dictionary<int, Node>();
        List<Node> _currentPath = new List<Node>();

        public Node Create(int x, int y)
        {
            return new Node(x, y, _seed)
            {
                DistanceFrom = Node.DistanceBetween(x, y, _startX, _startY),
                DistanceTo = Node.DistanceBetween(x, y, _destX, _destY)
            };
        }

        public int PositionIndex(int x, int y)
        {
            return y * _height + x;
        }

        public Node AddNode(int x, int y)
        {
            int index = PositionIndex(x, y);
            if (_allNodes.ContainsKey(index) && _allNodes[index] != null)
                return _allNodes[index];

            Node node = Create(x, y);
            if (node.IsOpen())
            {
                _allNodes.Add(index, node);
                return node;
            }

            return null;
        }

        public Node InspectNeighbours(Node node)
        {
            List<Node> neighbours = new List<AdventOfCode.Node>();
            Node neighbour = AddNode(node.X - 1, node.Y);
            if (neighbour != null)
                neighbours.Add(neighbour);

            neighbour = AddNode(node.Y + 1, node.Y);
            if (neighbour != null)
                neighbours.Add(neighbour);

            neighbour = AddNode(node.X, node.Y - 1);
            if (neighbour != null)
                neighbours.Add(neighbour);

            neighbour = AddNode(node.X, node.Y + 1);
            if (neighbour != null)
                neighbours.Add(neighbour);

            return neighbours.Where(x => !x.Visited).OrderBy(x => x.DistanceFrom + x.DistanceTo).FirstOrDefault();
        }

        public int Route(Node startNode)
        {
            Node currentNode = startNode;
            Node nextNode;
            _currentPath = new List<AdventOfCode.Node>() { currentNode };

            while (currentNode != null)
            {
                nextNode = InspectNeighbours(currentNode);
                if (nextNode == null)
                {
                    _currentPath.Remove(currentNode);
                    currentNode = _currentPath[_currentPath.Count - 1];
                }
                else
                {
                    currentNode = nextNode;
                    _currentPath.Add(currentNode);
                }

                currentNode.Visit();

                DrawBoard();

                if (currentNode.X == _destX && currentNode.Y == _destY)
                    return _currentPath.Count - 1;
            }

            return -1;
        }

        public int Part1(int startX, int startY, int seed, int destX, int destY)
        {
            InitializeOutput(".\\output\\13.1.txt");

            _seed = seed;
            _startX = startX;
            _startY = startY;
            _destX = destX;
            _destY = destY;
            _width = Math.Max(startX, destX) * 2;
            _height = Math.Max(startY, destY) * 2;

            return Route(Create(_startX, _startY));
        }

        private void DrawBoard()
        {
            string board = string.Empty;
            int biggestDist = Node.DistanceBetween(_startX, _startY, _destX, _destY);
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    int index = PositionIndex(x, y);
                    if (_allNodes.ContainsKey(index))
                    {
                        Node node = _allNodes[index];
                        if (node.Visited)
                        {
                            char distanceChar;
                            int nodeDist = node.DistanceFrom + node.DistanceTo;
                            if (nodeDist < biggestDist / 4)
                                distanceChar = (char)176;
                            else if (nodeDist < biggestDist / 2)
                                distanceChar = (char)177;
                            else if (nodeDist < biggestDist / 2 + biggestDist / 4)
                                distanceChar = (char)178;
                            else
                                distanceChar = (char)219;

                            board = $"{board}{distanceChar}";
                        }
                        else
                            board = $"{board} ";
                    }
                    else
                        board =  $"{board}#";
                }
            }

            DumpOutput(".\\output\\13.1.txt", board, Encoding.ASCII);
        }
    }

    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Seed { get; set; }
        public int Steps { get; set; }
        public bool Visited { get; set; }
        public int DistanceFrom { get; set; }
        public int DistanceTo { get; set; }

        private bool? _isOpen;

        public Node()
        {

        }

        public Node(int x, int y, int seed) : this()
        {
            X = x;
            Y = y;
            Seed = seed;
        }

        public void Visit()
        {
            Visited = true;
        }

        public int BaseValue()
        {
            return X * X + 3 * X + 2 * X * Y + Y + Y * Y + Seed;
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

        public bool IsOpen()
        {
            return (_isOpen ?? (_isOpen = ((OnBits(Binary(BaseValue())) & 1) == 0))).GetValueOrDefault();
        }

        public static int DistanceBetween(int sx, int sy, int dx, int dy)
        {
            return (int)Math.Round(Math.Sqrt(Math.Pow(sx - dx, 2) + Math.Pow(sy - dy, 2)));
        }

    }
}
