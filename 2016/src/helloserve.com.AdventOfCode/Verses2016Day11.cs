using helloserve.com.AdventOfCode.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day11 : Verses2016
    {
        private ScenarioNode _currentNode = new ScenarioNode();

        public int Part1(string input)
        {
            input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(l => PopulateFloor(l));

            return _currentNode.PickMoves().GetValueOrDefault();
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

            Floor floor = _currentNode.Floors.SingleOrDefault(f => f.Level == floorLevel);
            if (floor == null)
            {
                floor = new AdventOfCode.Floor(floorLevel);
                _currentNode.Floors.Add(floor);
            }

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

                ScenarioNode.Items.Add(AssemblyItem.CreateItem(assembly, isotope));
                _currentNode.Floors[floorLevel].Items.Add((byte)(ScenarioNode.Items.Count - 1));

                ReadWord(line, ref index);
            }

            _currentNode.Floors.OrderBy(f => f.Level).ToList();
        }
    }

    internal class ScenarioNode
    {
        public static List<AssemblyItem> Items = new List<AssemblyItem>();

        public int Moves { get; set; }
        public int FloorIndex { get; set; }
        public List<Floor> Floors { get; set; }
        //public Elevator Elevator { get; set; }

        public ScenarioNode PreviousNode { get; set; }
        public List<ScenarioNode> NextNodes { get; set; }

        public ScenarioNode()
        {
            Floors = new List<AdventOfCode.Floor>();
            NextNodes = new List<AdventOfCode.ScenarioNode>();
        }

        public int? PickMoves()
        {
            if (!Floors.Any(f => f.Level < 4 && f.Items.Any()))
                //|| (!Elevator.IsEmpty || FloorIndex != 3))
                return Moves;

            if (!Floors[FloorIndex].Items.Any())
                return null;

            //check to see if any items are fried, in which case this move consideration failed.
            //TODO fried

            #region Determine and create all the possible moves            

            List<byte?[]> fits = new List<byte?[]>();

            //look up to see if we find one that match isotope so that we can move the lift up
            if (FloorIndex < Floors.Count - 1)
            {
                fits = FindAssemblyFits(FloorIndex + 1);
                SaveMoves(fits, FloorIndex + 1);
            }

            //look at same level to see if there are any fits
            fits = FindAssemblyFits(FloorIndex);
            SaveMoves(fits, FloorIndex);

            //look at lower floor
            if (FloorIndex > 0)
            {
                fits = FindAssemblyFits(FloorIndex - 1);
                SaveMoves(fits, FloorIndex - 1);
            }

            //look at some odd special cases
            fits = SingleAssemblyItems();
            
            //try up first
            if (FloorIndex < Floors.Count - 1)
                SaveMoves(fits, FloorIndex + 1);
            
            //should we consider going down?
            if (FloorIndex > 0 && Floors[FloorIndex - 1].Items.Any())
                SaveMoves(fits, FloorIndex - 1);

            #endregion

            int? nodeResult = null;
            while (NextNodes.Count > 0)
            {
                nodeResult = NextNodes[0].PickMoves();
                if (nodeResult.HasValue)
                    return nodeResult;

                NextNodes.RemoveAt(0);
            }

            return null;
        }

        private List<byte?[]> FindAssemblyFits(int targetFloorIndex)
        {
            int? targetAssemblyItem = null;
            List<byte?[]> fits = new List<byte?[]>();

            //do target floor first, so that we can early exit if the floor contains nothing
            for (int j = 0; j < Floors[targetFloorIndex].Items.Count; j++)
            {
                for (int i = 0; i < Floors[FloorIndex].Items.Count; i++)
                {
                    if (Items[Floors[FloorIndex].Items[i]].Fit(Items[Floors[targetFloorIndex].Items[j]]))
                    {
                        byte?[] fit = new byte?[] { (byte)i, null };
                        fits.Add(fit);

                        //we can also consider the pair together if they are on the same floor
                        if (targetFloorIndex == FloorIndex)
                        {
                            fit = new byte?[] { (byte)i, (byte)targetAssemblyItem };
                            fits.Add(fit);
                        }
                    }
                }
            }

            return fits;
        }

        private List<byte?[]> SingleAssemblyItems()
        {
            List<byte?[]> fits = new List<byte?[]>();

            foreach (var item in Floors[FloorIndex].Items)
            {
                fits.Add(new byte?[] { item, null });
            }

            return fits;
        }

        private void SaveMoves(List<byte?[]> fits, int targetFloorIndex)
        {
            foreach (var fit in fits)
            {
                ScenarioNode newNode = AddNodeFrom();

                //move the elevator
                newNode.FloorIndex = targetFloorIndex;
                newNode.Moves++;

                //offload the elevator contents
                if (fit[0].HasValue)
                    newNode.Floors[FloorIndex].Items.Add(fit[0].Value);
                if (fit[1].HasValue)
                    newNode.Floors[FloorIndex].Items.Add(fit[1].Value);
            }
        }

        private ScenarioNode AddNodeFrom()
        {
            ScenarioNode clone = new ScenarioNode();

            NextNodes.Add(clone);
            clone.PreviousNode = this;

            clone.Floors = new List<AdventOfCode.Floor>();
            for (int i = 0; i < Floors.Count; i++)
                clone.Floors.Add(Floors[i].Clone());
            //clone.Elevator = Elevator.Clone();
            clone.FloorIndex = FloorIndex;
            clone.Moves = Moves;

            return clone;
        }
    }

    internal class AssemblyItem : IEquatable<AssemblyItem>
    {
        public string Isotope { get; set; }

        public bool Equals(AssemblyItem other)
        {
            return Isotope.Equals(other.Isotope, StringComparison.CurrentCultureIgnoreCase);
        }

        public bool Fit(AssemblyItem other)
        {
            return (((this is Microchip) && (other is Generator)) ||
                   ((this is Generator) && (other is Microchip))) && Equals(other);
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

        public Floor Clone()
        {
            Floor clone = new Floor(Level);

            for (int i = 0; i < Items.Count; i++)
                clone.Items.Add(Items[i]);

            return clone;
        }
    }

    //internal class Elevator
    //{
    //    public byte? Item1 { get; set; }
    //    public byte? Item2 { get; set; }

    //    public bool IsEmpty
    //    {
    //        get
    //        {
    //            return Item1 == null && Item2 == null;
    //        }
    //    }

    //    public Elevator Clone()
    //    {
    //        Elevator clone = new Elevator();

    //        clone.Item1 = Item1;
    //        clone.Item2 = Item2;

    //        return clone;
    //    }
    //}
}
