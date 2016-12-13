using helloserve.com.AdventOfCode.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day11 : Verses2016
    {
        private int _moves = 0;
        private int _elevatorIndex = 0;
        private List<AssemblyItem> _items = new List<AssemblyItem>();
        private List<Floor> _floors = new List<Floor> { new Floor(1), new Floor(2), new Floor(3), new Floor(4) };
        private Elevator _elevator = new Elevator();

        public int Part1(string input)
        {
            input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(l => PopulateFloor(l));

            while (_floors.Any(f => f.Level < 4 && f.Items.Any()) || (!_elevator.IsEmpty || _elevatorIndex != 3))
            {
                if (_elevator.Item1 == null)
                    _elevator.Item1 = PickItem(_elevatorIndex);

                if (_elevator.Item2 == null)
                    _elevator.Item2 = PickItem(_elevatorIndex);

                if (_elevator.IsEmpty)
                    throw new InvalidOperationException("elevator is empty");

                _elevatorIndex++;

                if (_elevator.Item1 != null)
                {
                    if (_elevatorIndex == 3)
                    {
                        _floors[_elevatorIndex].Items.Add(_elevator.Item1.Value);
                        _elevator.Item1 = null;
                    }
                }

                if (_elevator.Item2 != null)
                {
                    if (_elevatorIndex == 3)
                    {
                        _floors[_elevatorIndex].Items.Add(_elevator.Item2.Value);
                        _elevator.Item2 = null;
                    }
                }

                _moves++;
            }
            return _moves;
        }

        private byte? PickItem(int floorIndex)
        {
            if (!_floors[floorIndex].Items.Any())
                return null;

            byte item = _floors[floorIndex].Items[0];
            _floors[floorIndex].Items.Remove(item);

            return item;
        }

        private void PopulateFloor(string line)
        {
            int index = 0;
            ReadWord(line, ref index, "The");
            int floorLevel = -1;
            switch (ReadWord(line, ref index))
            {
                case "first":
                    floorLevel = 0;
                    break;
                case "second":
                    floorLevel = 1;
                    break;
                case "third":
                    floorLevel = 2;
                    break;
                case "fourth":
                    floorLevel = 3;
                    break;
            }

            if (floorLevel == -1)
                throw new ArgumentException($"{line} specifies invalid floor");

            ReadWord(line, ref index, "floor");
            ReadWord(line, ref index, "contains");

            string containVerb = ReadWord(line, ref index);
            if (containVerb == "nothing")
                return;

            while (index < line.Length)
            {
                if (string.IsNullOrEmpty(containVerb))
                {
                    if (ReadWord(line, ref index) == "and")
                        ReadWord(line, ref index, "a");
                }
                else
                    containVerb = null;

                string isotope = ReadWord(line, ref index).Replace("-compatible", string.Empty);
                string assembly = ReadWord(line, ref index);

                _items.Add(AssemblyItem.CreateItem(assembly, isotope));
                _floors[floorLevel].Items.Add((byte)(_items.Count - 1));

                ReadWord(line, ref index);
            }
        }
    }

    internal class AssemblyItem : IEquatable<AssemblyItem>
    {
        public string Isotope { get; set; }

        public bool Equals(AssemblyItem other)
        {
            return Isotope.Equals(other.Isotope, StringComparison.CurrentCultureIgnoreCase);
        }

        public static AssemblyItem CreateItem(string assemblyType, string isotope)
        {
            switch (assemblyType)
            {
                case "microchip":
                    return new Microchip() { Isotope = isotope };
                case "generator":
                    return new Generator() { Isotope = isotope };
            }

            throw new ArgumentException($"{assemblyType} is an unknown assembly");
        }
    };

    internal class Microchip : AssemblyItem { };

    internal class Generator : AssemblyItem { };

    internal class Floor
    {
        public int Level { get; set; }
        public List<byte> Items { get; set; }

        public Floor(int level)
        {
            Level = level;
            Items = new List<byte>();
        }
    }

    internal class Elevator
    {
        public byte? Item1 { get; set; }
        public byte? Item2 { get; set; }

        public bool IsEmpty
        {
            get
            {
                return Item1 == null && Item2 == null;
            }
        }
    }
}
