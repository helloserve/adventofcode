using helloserve.com.AdventOfCode.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day12 : Verses2016
    {
        public int? Cpy(int x, ref int y)
        {
            y = x;
            return null;
        }

        public int? Inc(ref int x)
        {
            x++;
            return null;
        }

        public int? Dec(ref int x)
        {
            x--;
            return null;
        }

        public int Jnz(int x, int y)
        {
            if (x > 0)
                return y;
            else
                return 1;
        }

        private int? ParseCommand(string input)
        {
            int index = 0;
            string command = ReadWord(input, ref index);
            switch (command)
            {
                case "cpy":
                case "CPY":
                    return ParseCpy(input, index);
                case "inc":
                case "INC":
                    return ParseInc(input, index);
                case "dec":
                case "DEC":
                    return ParseDec(input, index);
                case "jnz":
                case "JNZ":
                    return ParseJnz(input, index);
            }

            return null;
        }

        private int? ParseCpy(string input, int index)
        {
            string val1str = ReadWord(input, ref index);
            int val;
            string dest = ReadWord(input, ref index);
            if (!int.TryParse(val1str, out val))
                val = _registers[Reg(val1str)];
            return Cpy(val, ref _registers[Reg(dest)]);
        }

        private int? ParseInc(string input, int index)
        {
            string regStr = ReadWord(input, ref index);
            return Inc(ref _registers[Reg(regStr)]);
        }

        private int? ParseDec(string input, int index)
        {
            string regStr = ReadWord(input, ref index);
            return Dec(ref _registers[Reg(regStr)]);
        }

        private int? ParseJnz(string input, int index)
        {
            string valStr = ReadWord(input, ref index);
            int val;
            if (!int.TryParse(valStr, out val))
                val = _registers[Reg(valStr)];
            string jumpStr = ReadWord(input, ref index);
            int jump;
            if (!int.TryParse(jumpStr, out jump))
                jump = _registers[Reg(jumpStr)];

            return Jnz(val, jump);
        }

        private int Reg(string register)
        {
            switch (register)
            {
                case "a":
                case "A":
                    return 0;
                case "b":
                case "B":
                    return 1;
                case "c":
                case "C":
                    return 2;
                case "d":
                case "D":
                    return 3;
            }

            throw new ArgumentException($"Invalid register reference '{register}'");
        }

        private void Execute(string[] commands)
        {
            _commandIndex = 0;
            while (_commandIndex < commands.Length)
            {
                _commandIndex += ParseCommand(commands[_commandIndex]) ?? 1;
            }
        }

        private delegate int? Command();

        private int[] _registers = new int[4];
        private int _commandIndex;

        public int Part1(string input, string fromRegister, int[] initialState = null)
        {
            _registers = initialState ?? new int[] { 0, 0, 0, 0 };
            string[] lines = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            Execute(lines);
            return _registers[Reg(fromRegister)];
        }
    }
}
