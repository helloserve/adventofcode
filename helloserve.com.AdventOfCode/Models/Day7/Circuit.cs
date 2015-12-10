using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Models.Day7
{
    public class Circuit : Input
    {
        Wire _wire;
        Dictionary<string, string> _instructions;
        Dictionary<string, Wire> _wires;

        public Circuit(string[] diagram, string wire)
        {
            IndexDiagram(diagram);
            _wire = ProcessInstructionsForWire(wire);
        }

        protected override int GetOutput()
        {
            return _wire.Output;
        }

        private void IndexDiagram(string[] diagram)
        {
            _wires = new Dictionary<string, Wire>();
            _instructions = new Dictionary<string, string>();
            foreach (string instruction in diagram)
            {
                string[] parts = instruction.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                string wire = parts[1].Trim();
                if (!_instructions.ContainsKey(wire))
                    _instructions.Add(wire, parts[0].Trim());
                else
                    _instructions[wire] = parts[0].Trim();
            }
        }

        private Wire ProcessInstructionsForWire(string wire)
        {
            if (string.IsNullOrEmpty(wire))
                return null;

            if (_wires.ContainsKey(wire))
                return _wires[wire];

            if (!_instructions.ContainsKey(wire))
                throw new ArgumentException(string.Format("Instructions for wire '{0}' not found.", wire));

            string instruction = _instructions[wire];

            Wire result = new Wire()
            {
                Name = wire
            };

            Input input = null;

            Regex regex3Parts = new Regex(@"(?<wire1>[a-z]*)\s*(?<constant1>\d*)\s(?<gate>[A-Z]*)\s(?<wire2>[a-z]*)\s*(?<constant2>\d*)");
            Match match = regex3Parts.Match(instruction);
            if (match.Success)
            {
                Input wire1 = ProcessInstructionsForWire(match.Groups["wire1"].Value);
                Input wire2 = ProcessInstructionsForWire(match.Groups["wire2"].Value);
                input = Gate.GetGate(match.Groups["gate"].Value, wire1, wire2, match.Groups["constant1"].Value, match.Groups["constant2"].Value);
            }
            else
            {
                Regex regex2Parts = new Regex(@"NOT (?<wire>[a-z]*)(?<constant>\d*)");
                match = regex2Parts.Match(instruction);
                if (match.Success)
                {
                    input = Gate.GetGate("NOT", ProcessInstructionsForWire(match.Groups["wire"].Value), null, match.Groups["constant"].Value, null);
                }
                else
                {
                    int signal = -1;
                    if (int.TryParse(instruction, out signal))
                    {
                        input = new Signal(signal);
                    }
                    else
                    {
                        Regex regexWire = new Regex(@"(?<wire>[a-z]*)");
                        match = regexWire.Match(instruction);
                        if (match.Success)
                        {
                            input = ProcessInstructionsForWire(match.Groups["wire"].Value);
                        }
                    }
                }
            }

            if (input == null)
            {
                throw new ArgumentException(string.Format("Could not process instruction '{0}'", instruction));
            }

            input.Instruction = instruction;
            result.Input = input;

            _wires.Add(wire, result);

            return result;
        }
    }
}
