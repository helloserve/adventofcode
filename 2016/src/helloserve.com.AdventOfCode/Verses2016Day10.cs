using helloserve.com.AdventOfCode.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day10 : Verses2016
    {
        private Dictionary<int, List<int>> _bots = new Dictionary<int, List<int>>();
        private Dictionary<int, List<int>> _outputs = new Dictionary<int, List<int>>();
        private List<int> _botsUpdated = new List<int>();

        public int Part1(string input, int value1, int value2)
        {
            List<string> lines = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> stackedLines = new List<string>();

            while (lines.Count > 0)
            {
                while (lines.Count > 0)
                {
                    bool processResult = ParseLine(lines[0]);
                    if (!processResult)
                        stackedLines.Add(lines[0]);
                    lines.RemoveAt(0);

                    for (int b = 0; b < _botsUpdated.Count; b++)
                    {
                        if (_bots.ContainsKey(_botsUpdated[b]) && _bots[_botsUpdated[b]].Contains(value1) && _bots[_botsUpdated[b]].Contains(value2))
                            return _botsUpdated[b];
                    }
                    _botsUpdated.Clear();
                }

                while (stackedLines.Count > 0)
                {
                    bool stackedResult = ParseLine(stackedLines[0]);
                    if (!stackedResult)
                        break;

                    stackedLines.RemoveAt(0);
                }

                lines = stackedLines;
                stackedLines = new List<string>();
            }

            return -1;
        }

        public int Part2(string input, int value1, int value2)
        {
            Part1(input, value1, value2);
            return _outputs[0].First() * _outputs[1].First() * _outputs[2].First();
        }

        private bool ParseLine(string input)
        {
            string word = input.Substring(0, input.IndexOf(" "));
            if (word == "value")
                return AssignValue(input);
            else if (word == "bot")
                return GiveValues(input);

            return false;
        }

        private bool AssignValue(string input)
        {
            int index = 0;
            ReadWord(input, ref index, "value");
            int value = ReadInt(input, ref index);
            string goesto = ReadWord(input, ref index) + ReadWord(input, ref index);
            if (goesto != "goesto")
                throw new InvalidOperationException();
            string bot = ReadWord(input, ref index);
            int botId = ReadInt(input, ref index);

            return AssignToBot(botId, value);
        }

        private bool GiveValues(string input)
        {
            int index = 0;
            ReadWord(input, ref index, "bot");
            int sourceBotId = ReadInt(input, ref index);

            if (!_bots.ContainsKey(sourceBotId))
                return false;

            if (_bots[sourceBotId].Count < 2)
                return false;

            string command = ReadWord(input, ref index);
            while (!string.IsNullOrEmpty(command))
            {
                if (command == "gives" || command == "and")
                {
                    string type = ReadWord(input, ref index);
                    ReadWord(input, ref index, "to");
                    string dest = ReadWord(input, ref index);
                    int destId = ReadInt(input, ref index);

                    if (!HandOverValue(sourceBotId, type, dest, destId))
                        return false;
                }

                command = ReadWord(input, ref index);
            }

            return true;
        }

        public bool HandOverValue(int sourceId, string type, string destination, int destinationId)
        {
            int value = 0;
            switch (type)
            {
                case "low":
                    value = _bots[sourceId].Min();
                    break;
                case "high":
                    value = _bots[sourceId].Max();
                    break;
                default:
                    throw new ArgumentException();
            }

            bool assigned = false;
            switch (destination)
            {
                case "output":
                    assigned = AssignToOutput(destinationId, value);
                    break;
                case "bot":
                    assigned = AssignToBot(destinationId, value);
                    break;
                default:
                    throw new ArgumentException();
            }

            if (!assigned)
                return false;

            _bots[sourceId].Remove(value);

            return true;
        }

        private bool AssignToOutput(int id, int value)
        {
            if (!_outputs.ContainsKey(id))
                _outputs.Add(id, new List<int>());
            _outputs[id].Add(value);

            return true;
        }

        private bool AssignToBot(int id, int value)
        {
            if (!_bots.ContainsKey(id))
                _bots.Add(id, new List<int>());

            if (_bots[id].Count >= 2)
                return false;

            _bots[id].Add(value);

            _botsUpdated.Add(id);

            return true;
        }
    }
}
