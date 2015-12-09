using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Models.Day7
{
    public abstract class Input
    {
        public abstract int Output { get; }
    }

    public class Signal : Input
    {
        private int _value;
        public Signal(int value)
        {
            _value = value;
        }

        public override int Output
        {
            get
            {
                return _value;
            }
        }
    }
}
