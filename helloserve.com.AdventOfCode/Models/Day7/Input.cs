using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Models.Day7
{
    public abstract class Input
    {
        public string Instruction { get; set; }

        protected abstract int GetOutput();

        private int? _output;
        public int Output
        {
            get
            {
                if (!_output.HasValue)
                    _output = GetOutput();
                return _output.Value;
            }
        }
    }

    public class Signal : Input
    {
        private int _value;
        public Signal(int value)
        {
            _value = value;
        }

        protected override int GetOutput()
        {
            return _value;
        }
    }
}
