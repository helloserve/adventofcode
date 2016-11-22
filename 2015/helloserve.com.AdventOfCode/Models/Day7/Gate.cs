using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Models.Day7
{
    public abstract class Gate : Input
    {
        public static Gate GetGate(string gate, Input input1, Input input2, string constant1, string constant2)
        {
            switch (gate)
            {
                case "AND":
                    return new AndGate(input1 ?? new Signal(int.Parse(constant1)), input2 ?? new Signal(int.Parse(constant2)));
                case "OR":
                    return new OrGate(input1 ?? new Signal(int.Parse(constant1)), input2 ?? new Signal(int.Parse(constant2)));
                case "NOT":
                    return new NotGate(input1 ?? new Signal(int.Parse(constant1)), null);
                case "LSHIFT":
                    return new LShiftGate(input1, constant2);
                case "RSHIFT":
                    return new RShiftGate(input1, constant2);
                default:
                    return null;
            }
        }

        public Input Input1 { get; set; }
        public Input Input2 { get; set; }
    }

    public abstract class LogicGate : Gate
    {
        public LogicGate(Input input1, Input input2)
        {
            Input1 = input1;
            Input2 = input2;
        }
    }

    public class AndGate : LogicGate
    {
        public AndGate(Input input1, Input input2) : base(input1, input2) { }

        protected override int GetOutput()
        {
            return Input1.Output & Input2.Output;
        }
    }

    public class OrGate : LogicGate
    {
        public OrGate(Input input1, Input input2) : base(input1, input2) { }

        protected override int GetOutput()
        {
            return Input1.Output | Input2.Output;
        }
    }

    public class NotGate : LogicGate
    {
        public NotGate(Input input1, Input input2) : base(input1, input2) { }

        protected override int GetOutput()
        {
            return ~Input1.Output;
        }
    }

    public abstract class ShiftGate : Gate
    {
        protected int _shiftConstant;

        public ShiftGate(Input input, string constant)
        {
            Input1 = input;
            _shiftConstant = int.Parse(constant);
        }
    }

    public class RShiftGate : ShiftGate
    {
        public RShiftGate(Input input, string constant) : base(input, constant) { }

        protected override int GetOutput()
        {
            return Input1.Output >> _shiftConstant;
        }
    }

    public class LShiftGate : ShiftGate
    {
        public LShiftGate(Input input, string constant) : base(input, constant) { }

        protected override int GetOutput()
        {
            return Input1.Output << _shiftConstant;
        }
    }
}
