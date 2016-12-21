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
        int _startDestDistance;
        int? _maxPathLength;

        Dictionary<int, Node> _allNodes = new Dictionary<int, Node>();
        List<OpenNode> _openNodes = new List<OpenNode>();
        List<Node> _currentPath = new List<Node>();
        Node _currentNode;

        public Node Create(int x, int y)
        {
            return new Node(x, y, _seed, _currentPath.Count)
            {
                DistanceFrom = Node.DistanceBetween(x, y, _startX, _startY),
                DistanceTo = Node.DistanceBetween(x, y, _destX, _destY)
            };
        }

        public int PositionIndex(int x, int y, int? width = null)
        {
            return y * (width ?? _width) + x;
        }

        public Node AddNode(int x, int y)
        {
            if (x < 0 || y < 0)
                return null;

            int index = PositionIndex(x, y);

            if (_allNodes.ContainsKey(index))
            {
                if (_currentPath.IndexOf(_allNodes[index]) > -1)
                    return null;

                _allNodes[index].Steps = _currentPath.Count;
                return _allNodes[index];
            }

            Node node = Create(x, y);

            if (!_allNodes.ContainsKey(index))
                _allNodes.Add(index, node);

            if (node.IsOpen)
            {
                _openNodes.Add(new OpenNode()
                {
                    Node = node,
                    PathToNode = _currentPath.ToList()
                });
            }

            return node;
        }

        public Node InspectNeighbours(Node node)
        {
            List<Node> neighbours = new List<AdventOfCode.Node>();
            Node neighbour = AddNode(node.X - 1, node.Y);
            if (neighbour != null)
                neighbours.Add(neighbour);

            neighbour = AddNode(node.X + 1, node.Y);
            if (neighbour != null)
                neighbours.Add(neighbour);

            neighbour = AddNode(node.X, node.Y - 1);
            if (neighbour != null)
                neighbours.Add(neighbour);

            neighbour = AddNode(node.X, node.Y + 1);
            if (neighbour != null)
                neighbours.Add(neighbour);

            return neighbours.Where(x => x.IsOpen && x.TotalDistance <= node.TotalDistance).OrderBy(x => x.DistanceTo).FirstOrDefault();
        }

        public int Route(Node startNode)
        {
            _currentNode = startNode;
            Node nextNode;
            _currentPath = new List<AdventOfCode.Node>() { _currentNode };
            _allNodes.Add(PositionIndex(startNode.X, startNode.Y), startNode);

            while (_currentNode != null)
            {
                if (_currentNode.X == _destX && _currentNode.Y == _destY)
                    return _currentPath.Count - 1;

                if (_maxPathLength.HasValue && _currentPath.Count > _maxPathLength.Value)
                    nextNode = null;
                else
                    nextNode = InspectNeighbours(_currentNode);

                //DrawBoard();

                if (nextNode == null)
                {
                    _openNodes.ForEach(x => x.Node.Steps = x.PathToNode.Count);
                    _openNodes = _openNodes.OrderBy(x => x.Node.TotalDistance).OrderBy(x => x.Node.DistanceTo).ToList();
                    if (_openNodes.Count > 0)
                    {
                        OpenNode nextOpen = _openNodes[0];
                        _openNodes.RemoveAt(0);
                        nextOpen.Node.Steps = nextOpen.PathToNode.Count;
                        while (nextOpen != null && nextOpen.Node.Visits > 0 && _openNodes.Count > 0)
                        {
                            nextOpen = _openNodes.FirstOrDefault();
                            nextOpen.Node.Steps = nextOpen.PathToNode.Count;
                            _openNodes.RemoveAt(0);
                        }

                        if (nextOpen != null)
                        {
                            _currentPath = nextOpen.PathToNode;
                            nextNode = nextOpen.Node;
                        }
                    }
                }

                if (nextNode == null)
                    return -1;

                _currentPath.Add(nextNode);
                nextNode.Steps = _currentPath.Count - 1;
                _currentNode = nextNode;

                _currentNode.Visit();

                //DrawBoard();
            }

            return -1;
        }

        public int Part1(int startX, int startY, int seed, int destX, int destY, int? maxPathLength = null, int? width = null, int? height = null)
        {
            //InitializeOutput(".\\output\\13.1.txt");

            _seed = seed;
            _startX = startX;
            _startY = startY;
            _destX = destX;
            _destY = destY;
            _width = Math.Max(width ?? 10, Math.Max(startX, destX) * 2);
            _height = Math.Max(height ?? 10, Math.Max(startY, destY) * 2);
            _startDestDistance = Node.DistanceBetween(_startX, startY, destX, destY);
            _maxPathLength = maxPathLength;

            _allNodes = new Dictionary<int, Node>();
            _openNodes = new List<OpenNode>();
            _currentPath = new List<Node>();

            return Route(Create(_startX, _startY));
        }

        public int Part2(int startX, int startY, int seed)
        {
            _seed = seed;

            int maxX = startX + 50;
            int maxY = startY + 50;
            int index;
            int steps = -1;
            Node node;
            Dictionary<int, int> paths = new Dictionary<int, int>();
            for (int x = 0; x <= maxX; x++)
            {
                for (int y = 0; y <= maxY; y++)
                {
                    node = Create(x, y);
                    if (!node.IsOpen)
                        continue;

                    index = PositionIndex(x, y, maxX);
                    steps = Part1(startX, startY, seed, x, y, maxPathLength: 50, width: 100, height: 100);
                    if (steps != -1)
                        paths.Add(index, steps);
                }
            }

            return paths.Keys.Count;
        }

        private void DrawBoard()
        {
            int localWidth = _width * 2;
            int localHeight = _height * 2;
            char[,] board = new char[localWidth, localHeight];
            int biggestDist = Node.DistanceBetween(_startX, _startY, _destX, _destY);

            board[0, 0] = ' ';
            for (int i = 0; i < localWidth - 1; i++)
            {
                board[i + 1, 0] = i.ToString().ToCharArray().Last();
            }
            for (int i = 0; i < localHeight - 1; i++)
            {
                board[0, i + 1] = i.ToString().ToCharArray().Last();
            }

            for (int y = 0; y < localHeight - 1; y++)
            {
                for (int x = 0; x < localWidth - 1; x++)
                {
                    if (x > _width || y > _height)
                        continue;

                    int index = PositionIndex(x, y);
                    if (_allNodes.ContainsKey(index))
                    {
                        Node node = _allNodes[index];
                        if (node.IsOpen)
                            board[x + 1, y + 1] = ' ';
                        else
                            board[x + 1, y + 1] = '#';
                    }
                    else
                        board[x + 1, y + 1] = '?';
                }
            }

            board[_destX + 1, _destY + 1] = 'X';

            for (int i = 0; i < _currentPath.Count; i++)
            {
                board[_currentPath[i].X + 1, _currentPath[i].Y + 1] = 'O';
            }


            string boardStr = string.Empty;

            for (int y = 0; y < localHeight - 1; y++)
            {
                for (int x = 0; x < localWidth - 1; x++)
                {
                    boardStr = $"{boardStr}{board[x, y]}";
                }
                boardStr = $"{boardStr}\r\n";
            }

            DumpOutput(".\\output\\13.1.txt", boardStr, Encoding.ASCII);
        }
    }

    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Seed { get; set; }
        public int Steps { get; set; }
        public int Visits { get; set; }
        public int DistanceFrom { get; set; }
        public int DistanceTo { get; set; }
        public bool IsOpen { get; set; }

        public Node()
        {

        }

        public Node(int x, int y, int seed, int steps) : this()
        {
            X = x;
            Y = y;
            Seed = seed;
            Steps = steps;
            IsOpen = (OnBits(Binary(BaseValue())) & 1) == 0;
        }

        public void Visit()
        {
            Visits++;
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

        public int TotalDistance
        {
            get
            {
                return Steps + DistanceTo;
            }
        }

        public static int DistanceBetween(int sx, int sy, int dx, int dy)
        {
            return Math.Abs(sx - dx) + Math.Abs(sy - dy);
        }

    }

    public class OpenNode
    {
        public Node Node { get; set; }
        public List<Node> PathToNode { get; set; }
    }
}
