using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Models.Day7
{
    public abstract class Gate: Input
    {
        public static Gate GetGate(string gate, Wire input1, Wire input2, string constant)
        {
            switch (gate)
            {
                case "AND":
                    return new AndGate(input1, input2);
                case "OR":
                    return new OrGate(input1, input2);
                case "NOT":
                    return new NotGate(input1, null);
                case "LSHIFT":
                    return new LShiftGate(constant);
                case "RSHIFT":
                    return new RShiftGate(constant);
                default:
                    throw new ArgumentException();
            }
        }

        public Wire Input1 { get; set; }
        public Wire Input2 { get; set; }        
    }

    public abstract class LogicGate : Gate
    {
        public LogicGate(Wire input1, Wire input2)
        {
            Input1 = input1;
            Input2 = input2;
        }
    }

    public class AndGate : LogicGate
    {
        public AndGate(Wire input1, Wire input2) : base(input1, input2) { }

        public override int Output
        {
            get
            {
                return Input1.Output & Input2.Output;
            }
        }
    }

    public class OrGate : LogicGate
    {
        public OrGate(Wire input1, Wire input2) : base(input1, input2) { }

        public override int Output
        {
            get
            {
                return Input1.Output | Input2.Output;
            }
        }
    }

    public class NotGate : LogicGate
    {
        public NotGate(Wire input1, Wire input2) : base(input1, input2) { }

        public override int Output
        {
            get
            {
                return ~Input1.Output;
            }
        }
    }

    public abstract class ShiftGate : Gate
    {
        protected int _shiftConstant;

        public ShiftGate(string constant)
        {
            _shiftConstant = int.Parse(constant);
        }
    }

    public class RShiftGate : ShiftGate
    {
        public RShiftGate(string constant) : base(constant) { }

        public override int Output
        {
            get
            {
                return Input1.Output >> _shiftConstant;
            }
        }
    }

    public class LShiftGate : ShiftGate
    {
        public LShiftGate(string constant) : base(constant) { }

        public override int Output
        {
            get
            {
                return Input1.Output << _shiftConstant;
            }
        }
    }
}
