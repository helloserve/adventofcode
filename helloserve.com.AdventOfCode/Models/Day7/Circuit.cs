using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Models.Day7
{
    public class Circuit : Input
    {
        Wire _wire;
        Dictionary<string, string> _instructions;

        public Circuit(string[] diagram, string wire)
        {
            IndexDiagram(diagram);
        }

        public override int Output
        {
            get
            {
                return _wire.Output;
            }
        }

        private void IndexDiagram(string[] diagram)
        {
            _instructions = new Dictionary<string, string>();
            foreach (string instruction in diagram)
            {
                string[] parts = instruction.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                string wire = parts[1].Trim();
                if (!_instructions.ContainsKey(wire))
                    _instructions.Add(wire, parts[0].Trim());
            }
        }

        private Wire ProcessInstructionsForWire(string wire)
        {
            if (!_instructions.ContainsKey(wire))
                throw new ArgumentException(string.Format("Instructions for wire '{0}' not found.", wire));

            string instruction = _instructions[wire];

            Wire result = new Wire()
            {
                Name = wire
            };

            string[] parts = instruction.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int signal = -1;
            if (int.TryParse(parts[0], out signal))
            {

            }
        }
    }
}
