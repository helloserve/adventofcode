using helloserve.com.AdventOfCode.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day11 : Verses2016
    {
        private ScenarioNode _currentNode = new ScenarioNode();

        public int? Part1(string input)
        {
            InitializeOutput(".\\output\\11.1.txt");

            input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(l => PopulateFloor(l));

            int? result = null;
            while (_currentNode != null)
            {
                LogOutput(".\\output\\11.1.txt", _currentNode.ToString());

                result = _currentNode.Win();
                if (result.HasValue)
                    return result;

                if (_currentNode.Validate())
                    _currentNode.PickMoves();

                _currentNode = _currentNode.Traverse();
            }

            return null;
        }

        private void PopulateFloor(string line)
        {
            int index = 0;
            ReadWord(line, ref index, "The");
            int floorLevel = -1;
            switch (ReadWord(line, ref index))
            {
                case "first":
                    floorLevel = 1;
                    break;
                case "second":
                    floorLevel = 2;
                    break;
                case "third":
                    floorLevel = 3;
                    break;
                case "fourth":
                    floorLevel = 4;
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
                if (containVerb != "a" && (containVerb == "and" || ReadWord(line, ref index) == "and"))
                    ReadWord(line, ref index, "a");

                string isotope = ReadWord(line, ref index).Replace("-compatible", string.Empty);
                string assembly = ReadWord(line, ref index);

                ScenarioNode.Items.Add(AssemblyItem.CreateItem(assembly, isotope));
                _currentNode.Floors[floorLevel - 1].Items.Add((byte)(ScenarioNode.Items.Count - 1));

                containVerb = ReadWord(line, ref index);
            }

            _currentNode.Floors.OrderBy(f => f.Level).ToList();
        }
    }

    internal class ScenarioNode : IEquatable<ScenarioNode>
    {
        public static List<string> SeenScenarios = new List<string>();
        public static List<AssemblyItem> Items = new List<AssemblyItem>();
        public static int NodeIdentifierSequence = 1;

        public int NodeIdentifier { get; set; }
        public int Moves { get; set; }
        public int FloorIndex { get; set; }
        public List<Floor> Floors { get; set; }
        public bool Traversed { get; set; }

        public ScenarioNode PreviousNode { get; set; }
        public List<ScenarioNode> NextNodes { get; set; }

        public ScenarioNode()
        {
            Floors = new List<AdventOfCode.Floor>();
            NextNodes = new List<AdventOfCode.ScenarioNode>();
            Traversed = false;
        }

        public int? Win()
        {
            if (!Floors.Any(f => f.Level < 4 && f.Items.Any()))
                return Moves;

            return null;
        }

        public bool Validate()
        {
            if (!Floors[FloorIndex].Items.Any())
                return false;

            //check to see if any items are fried, in which case this move consideration failed.
            if (Cooked())
                return false;

            return true;
        }

        public void PickMoves()
        {
            List<byte?[]> fits = new List<byte?[]>();

            if (FloorIndex < Floors.Count - 1)
            {
                fits = FindAssemblyFits(FloorIndex);
                fits.AddRange(SameAssemblyItems());
                fits.AddRange(FindAssemblyFits(FloorIndex + 1));

                fits = DistinctFits(fits);

                SaveMoves(fits, FloorIndex + 1);
            }

            if (FloorIndex > 0)
            {
                fits = FindAssemblyFits(FloorIndex);
                fits.AddRange(SameAssemblyItems());
                fits = FindAssemblyFits(FloorIndex - 1);

                fits = DistinctFits(fits);

                SaveMoves(fits, FloorIndex - 1);
            }

            //remaining options
            fits.AddRange(SingleAssemblyItems());
            fits = DistinctFits(fits);

            //try up first
            if (FloorIndex < Floors.Count - 1)
                SaveMoves(fits, FloorIndex + 1);

            //should we consider going down?
            if (FloorIndex > 0 && Floors.Any(f => f.Level < FloorIndex + 1 && f.Items.Any()))
                SaveMoves(fits, FloorIndex - 1);
        }

        public ScenarioNode Traverse()
        {
            SeenScenarios.Add(GetScenarioString());

            if (!Traversed && NextNodes.Count > 0)
            {
                ScenarioNode next = NextNodes[0];
                while (next != null && SeenScenarios.Any(s => s.Equals(next)))
                {
                    NextNodes.RemoveAt(0);
                    if (NextNodes.Count > 0)
                        next = NextNodes[0];
                    else
                        next = null;
                }

                Traversed = NextNodes.Count == 0;
                if (next != null)
                {
                    NextNodes.RemoveAt(0);
                    return next;
                }
            }

            return PreviousNode;
        }

        private bool Cooked()
        {
            List<int> singleItems = new List<int>();
            AssemblyItem item;

            for (int i = 0; i < Floors[FloorIndex].Items.Count; i++)
            {
                item = Items[Floors[FloorIndex].Items[i]];
                if (Floors[FloorIndex].Items.Any(x => item.Fit(Items[x])) && item is Microchip)
                    continue;

                singleItems.Add(i);
            }

            for (int i = 0; i < singleItems.Count; i++)
            {
                item = Items[Floors[FloorIndex].Items[singleItems[i]]];
                if (singleItems.Any(x => item.Fried(Items[Floors[FloorIndex].Items[x]])))
                    return true;
            }

            return false;
        }

        private List<byte?[]> FindAssemblyFits(int targetFloorIndex)
        {
            List<byte?[]> fits = new List<byte?[]>();

            //do target floor first, so that we can early exit if the floor contains nothing
            for (int j = 0; j < Floors[targetFloorIndex].Items.Count; j++)
            {
                for (int i = 0; i < Floors[FloorIndex].Items.Count; i++)
                {
                    if (Items[Floors[FloorIndex].Items[i]].Fit(Items[Floors[targetFloorIndex].Items[j]]))
                    {
                        byte?[] fit;
                        if (targetFloorIndex == FloorIndex)
                            fit = new byte?[] { (byte)Floors[targetFloorIndex].Items[i], (byte)Floors[targetFloorIndex].Items[j] };
                        else
                            fit = new byte?[] { (byte)Floors[FloorIndex].Items[i], null };

                        fits.Add(fit);
                    }
                }
            }

            return fits;
        }

        private List<byte?[]> SameAssemblyItems()
        {
            List<byte?[]> fits = new List<byte?[]>();
            for (int i = 0; i < Floors[FloorIndex].Items.Count; i++)
            {
                for (int j = 0; j < Floors[FloorIndex].Items.Count; j++)
                {
                    if (i == j)
                        continue;

                    if (Items[Floors[FloorIndex].Items[i]].MatchType(Items[Floors[FloorIndex].Items[j]]))
                        fits.Add(new byte?[] { Floors[FloorIndex].Items[i], Floors[FloorIndex].Items[j] });
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

                //move items from the current floor to the new floor
                if (fit[0].HasValue)
                {
                    newNode.Floors[FloorIndex].Items.Remove(fit[0].Value);
                    newNode.Floors[newNode.FloorIndex].Items.Add(fit[0].Value);
                }
                if (fit[1].HasValue)
                {
                    newNode.Floors[FloorIndex].Items.Remove(fit[1].Value);
                    newNode.Floors[newNode.FloorIndex].Items.Add(fit[1].Value);
                }

                if (SeenScenarios.Any(s => s.Equals(newNode.GetScenarioString())))
                    continue;

                NextNodes.Add(newNode);
            }
        }

        private ScenarioNode AddNodeFrom()
        {
            ScenarioNode clone = new ScenarioNode();

            clone.NodeIdentifier = NodeIdentifierSequence++;
            clone.PreviousNode = this;

            clone.Floors = new List<AdventOfCode.Floor>();
            for (int i = 0; i < Floors.Count; i++)
                clone.Floors.Add(Floors[i].Clone());
            clone.FloorIndex = FloorIndex;
            clone.Moves = Moves;

            return clone;
        }

        private List<byte?[]> DistinctFits(List<byte?[]> fits)
        {
            byte?[] fit;
            int i = 0;
            while (i < fits.Count)
            {
                fit = fits[i];
                fits.RemoveAt(i);
                if (!fits.Any(f => (f[0] == fit[0] && f[1] == fit[1]) || (f[0] == fit[1] && f[1] == fit[0])))
                {
                    fits.Insert(i, fit);
                    i++;
                }
            }

            return fits;
        }

        public override string ToString()
        {
            StringBuilder blr = new StringBuilder();
            blr.AppendLine($"Node {NodeIdentifier} Moves {Moves}");
            for (int i = Floors.Count - 1; i >= 0; i--)
            {
                string floorIndicator = (FloorIndex == i) ? ">" : " ";
                blr.Append($"Floor{floorIndicator}{Floors[i].Level} [");
                for (int j = 0; j < Floors[i].Items.Count; j++)
                {
                    blr.Append($"{Items[Floors[i].Items[j]].ToString()},");
                }
                blr.AppendLine("]");
            }

            return blr.ToString();
        }

        private string GetScenarioString()
        {
            string result = $"{FloorIndex}";
            for (int i = Floors.Count - 1; i >= 0; i--)
            {
                result = $"{result}_{Floors[i].Level}[";
                foreach (byte index in Floors[i].Items.OrderBy(x => x))
                {
                    result = $"{result}{Items[index].ToString()},";
                }
                result = $"{result}]";
            }
            return result;
        }

        public bool Equals(ScenarioNode other)
        {
            return GetScenarioString().Equals(other.GetScenarioString());
        }
    }

    internal class AssemblyItem
    {
        public string Isotope { get; set; }

        public bool MatchIsotype(AssemblyItem other)
        {
            return Isotope.Equals(other.Isotope, StringComparison.CurrentCultureIgnoreCase);
        }

        public bool MatchType(AssemblyItem other)
        {
            return GetType().Name == other.GetType().Name;
        }

        public bool Fit(AssemblyItem other)
        {
            return (((this is Microchip) && (other is Generator)) ||
                   ((this is Generator) && (other is Microchip))) && MatchIsotype(other);
        }

        public bool Fried(AssemblyItem other)
        {
            return ((this is Microchip) && (other is Generator)) && !MatchIsotype(other);
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

        public override string ToString()
        {
            return $"{GetType().Name.Substring(0, 1)}{Isotope.Substring(0, 1).ToUpper()}";
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
}
