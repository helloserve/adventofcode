using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day17
    {
        private readonly char[] _openCharacters = new char[] { 'b', 'c', 'd', 'e', 'f' };

        private int _width = 3;
        private int _height = 3;

        private VaultRoom _room = new AdventOfCode.VaultRoom();
        private string _shortestRoute = string.Empty;
        private string _longestRoute = string.Empty;

        public string Part1(string input)
        {
            Trace(input);
            return _shortestRoute;
        }

        public int Part2(string input)
        {
            Trace(input);
            return _longestRoute.Length;
        }

        public void Trace(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                string hash;
                while (_room != null)
                {
                    if (_room.X == _width && _room.Y == _height)
                    {
                        if (string.IsNullOrEmpty(_shortestRoute) || _room.RouteSteps.Length < _shortestRoute.Length)
                            _shortestRoute = _room.RouteSteps;
                        if (string.IsNullOrEmpty(_longestRoute) || _room.RouteSteps.Length > _longestRoute.Length)
                            _longestRoute = _room.RouteSteps;
                    }
                    else
                    {
                        if (!_room.Visited)
                        {
                            hash = Hash($"{input}{_room.RouteSteps}", md5);
                            _room.AddRooms(
                                IsDoorOpen(hash[0]) && _room.Y > 0,
                                IsDoorOpen(hash[1]) && _room.Y < _height,
                                IsDoorOpen(hash[2]) && _room.X > 0,
                                IsDoorOpen(hash[3]) && _room.X < _width);

                        }

                        _room.Visited = true;
                    }

                    if (!_room.HasRooms)
                    {
                        if (_room.Parent != null)
                            _room.Parent.Rooms.Remove(_room);

                        _room = _room.Parent;
                    }
                    else
                        _room = _room.Rooms[0];
                }
            }            
        }

        private bool IsDoorOpen(char c)
        {
            return _openCharacters.Contains(c);
        }

        private string Hash(string input, MD5 md5)
        {
            byte[] inputBuffer = Encoding.UTF8.GetBytes(input);
            byte[] hashBuffer = md5.ComputeHash(inputBuffer);
            return $"{BitConverter.ToString(hashBuffer):x}".Replace("-", "").ToLower().Substring(0, 4);
        }
    }

    public class VaultRoom
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string RouteSteps { get; set; }
        public VaultRoom Parent { get; set; }
        public List<VaultRoom> Rooms { get; set; }
        public bool Visited { get; set; }

        public bool HasRooms
        {
            get { return Rooms.Count > 0; }
        }

        public VaultRoom()
        {
            RouteSteps = string.Empty;
            Rooms = new List<AdventOfCode.VaultRoom>();
        }

        public void AddRooms(bool up, bool down, bool left, bool right)
        {
            if (up)
            {
                Rooms.Add(new VaultRoom()
                {
                    Parent = this,
                    RouteSteps = $"{this.RouteSteps}U",
                    X = this.X,
                    Y = this.Y - 1
                });
            }

            if (down)
            {
                Rooms.Add(new VaultRoom()
                {
                    Parent = this,
                    RouteSteps = $"{this.RouteSteps}D",
                    X = this.X,
                    Y = this.Y + 1
                });
            }

            if (left)
            {
                Rooms.Add(new VaultRoom()
                {
                    Parent = this,
                    RouteSteps = $"{this.RouteSteps}L",
                    X = this.X - 1,
                    Y = this.Y
                });
            }

            if (right)
            {
                Rooms.Add(new VaultRoom()
                {
                    Parent = this,
                    RouteSteps = $"{this.RouteSteps}R",
                    X = this.X + 1,
                    Y = this.Y
                });
            }
        }
    }
}
