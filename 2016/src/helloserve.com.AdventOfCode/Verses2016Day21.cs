using helloserve.com.AdventOfCode.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day21 : Verses2016
    {
        public string SwapPos(string input, int pos1, int pos2)
        {
            char[] chars = input.ToCharArray();
            char c = chars[pos1];
            chars[pos1] = chars[pos2];
            chars[pos2] = c;
            return new string(chars);
        }

        public string SwapLet(string input, char letter1, char letter2)
        {
            char[] chars = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (chars[i] == letter1)
                    chars[i] = letter2;
                else if (input[i] == letter2)
                    chars[i] = letter1;
            }
            return new string(chars);
        }

        public string RotateLeft(string input, int count)
        {
            char[] chars = new char[input.Length];
            for (int i = count; i < input.Length; i++)
                chars[i - count] = input[i];

            for (int i = 0; i < count; i++)
                chars[chars.Length - count + i] = input[i];

            return new string(chars);
        }

        public string RotateRight(string input, int count)
        {
            char[] chars = new char[input.Length];
            for (int i = 0; i < count; i++)
                chars[count - 1 - i] = input[input.Length - 1 - i];

            for (int i = 0; i < input.Length - count; i++)
                chars[i + count] = input[i];

            return new string(chars);
        }

        public string RotatePos(string input, char letter)
        {
            int index = 0;
            while (index < input.Length && input[index] != letter)
                index++;

            input = RotateRight(input, 1);
            input = RotateRight(input, index);
            if (index >= 4)
                input = RotateRight(input, 1);

            return input;
        }

        public string RotatePosReverse(string input, char letter)
        {
            string tempInput = string.Empty;
            string reverseInput = input;
            while (tempInput != input)
            {
                reverseInput = RotateLeft(reverseInput, 1);
                tempInput = RotatePos(reverseInput, letter);
            }

            return reverseInput;
        }

        public string Reverse(string input, int index1, int index2)
        {
            int range = index2 - index1;
            char[] chars = input.ToCharArray();
            for (int i = 0; i <= range; i++)
            {
                chars[index1 + i] = input[index1 + range - i];
            }

            return new string(chars);
        }

        public string Move(string input, int posFrom, int posTo)
        {
            char c = input[posFrom];
            List<char> chars = input.ToCharArray().ToList();
            chars.RemoveAt(posFrom);
            chars.Insert(posTo, c);
            return new string(chars.ToArray());
        }

        public string Part1(string input, string password)
        {
            string[] lines = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                password = Command(line, password);
            }
            return password;
        }

        private string Command(string line, string input)
        {
            int i = 0;
            string word = ReadWord(line, ref i);
            switch (word)
            {
                case "swap":
                    return SwapCommand(line, input);
                case "rotate":
                    return RotateCommand(line, input);
                case "reverse":
                    return ReverseCommand(line, input);
                case "move":
                    return MoveCommand(line, input);
                default:
                    throw new NotImplementedException(line);
            }
        }

        private string CommandReverse(string line, string input)
        {
            int i = 0;
            string word = ReadWord(line, ref i);
            switch (word)
            {
                case "swap":
                    return SwapCommandReverse(line, input);
                case "rotate":
                    return RotateCommandReverse(line, input);
                case "reverse":
                    return ReverseCommand(line, input);
                case "move":
                    return MoveCommandReverse(line, input);
                default:
                    throw new NotImplementedException(line);
            }
        }


        private string SwapCommand(string line, string input)
        {
            int i = 0;
            ReadWord(line, ref i, expectedValue: "swap");
            string word = ReadWord(line, ref i);
            if (word == "position")
            {
                int pos1 = ReadInt(line, ref i);
                ReadWord(line, ref i, expectedValue: "with");
                ReadWord(line, ref i, expectedValue: "position");
                int pos2 = ReadInt(line, ref i);
                return SwapPos(input, pos1, pos2);
            }

            if (word == "letter")
            {
                char c1 = ReadWord(line, ref i)[0];
                ReadWord(line, ref i, expectedValue: "with");
                ReadWord(line, ref i, expectedValue: "letter");
                char c2 = ReadWord(line, ref i)[0];
                return SwapLet(input, c1, c2);
            }

            throw new NotImplementedException(line);
        }

        private string SwapCommandReverse(string line, string input)
        {
            int i = 0;
            ReadWord(line, ref i, expectedValue: "swap");
            string word = ReadWord(line, ref i);
            if (word == "position")
            {
                int pos1 = ReadInt(line, ref i);
                ReadWord(line, ref i, expectedValue: "with");
                ReadWord(line, ref i, expectedValue: "position");
                int pos2 = ReadInt(line, ref i);
                return SwapPos(input, pos2, pos1);
            }

            if (word == "letter")
            {
                char c1 = ReadWord(line, ref i)[0];
                ReadWord(line, ref i, expectedValue: "with");
                ReadWord(line, ref i, expectedValue: "letter");
                char c2 = ReadWord(line, ref i)[0];
                return SwapLet(input, c2, c1);
            }

            throw new NotImplementedException(line);
        }

        private string RotateCommand(string line, string input)
        {
            int i = 0;
            ReadWord(line, ref i, expectedValue: "rotate");
            string word = ReadWord(line, ref i);
            if (word == "left" || word == "right")
            {
                int steps = ReadInt(line, ref i);
                if (word == "left")
                    return RotateLeft(input, steps);
                if (word == "right")
                    return RotateRight(input, steps);
            }
            if (word == "based")
            {
                ReadWord(line, ref i, expectedValue: "on");
                ReadWord(line, ref i, expectedValue: "position");
                ReadWord(line, ref i, expectedValue: "of");
                ReadWord(line, ref i, expectedValue: "letter");
                char c = ReadWord(line, ref i)[0];
                return RotatePos(input, c);
            }

            throw new NotImplementedException(line);
        }

        private string RotateCommandReverse(string line, string input)
        {
            int i = 0;
            ReadWord(line, ref i, expectedValue: "rotate");
            string word = ReadWord(line, ref i);
            if (word == "left" || word == "right")
            {
                int steps = ReadInt(line, ref i);
                if (word == "left")
                    return RotateRight(input, steps);
                if (word == "right")
                    return RotateLeft(input, steps);
            }
            if (word == "based")
            {
                ReadWord(line, ref i, expectedValue: "on");
                ReadWord(line, ref i, expectedValue: "position");
                ReadWord(line, ref i, expectedValue: "of");
                ReadWord(line, ref i, expectedValue: "letter");
                char c = ReadWord(line, ref i)[0];
                return RotatePosReverse(input, c);
            }

            throw new NotImplementedException(line);
        }

        private string ReverseCommand(string line, string input)
        {
            int i = 0;
            ReadWord(line, ref i, expectedValue: "reverse");
            ReadWord(line, ref i, expectedValue: "positions");
            int pos1 = ReadInt(line, ref i);
            ReadWord(line, ref i, expectedValue: "through");
            int pos2 = ReadInt(line, ref i);
            return Reverse(input, Math.Min(pos1, pos2), Math.Max(pos1, pos2));
        }

        private string MoveCommand(string line, string input)
        {
            int i = 0;
            ReadWord(line, ref i, expectedValue: "move");
            ReadWord(line, ref i, expectedValue: "position");
            int pos1 = ReadInt(line, ref i);
            ReadWord(line, ref i, expectedValue: "to");
            ReadWord(line, ref i, expectedValue: "position");
            int pos2 = ReadInt(line, ref i);
            return Move(input, pos1, pos2);
        }
        private string MoveCommandReverse(string line, string input)
        {
            int i = 0;
            ReadWord(line, ref i, expectedValue: "move");
            ReadWord(line, ref i, expectedValue: "position");
            int pos1 = ReadInt(line, ref i);
            ReadWord(line, ref i, expectedValue: "to");
            ReadWord(line, ref i, expectedValue: "position");
            int pos2 = ReadInt(line, ref i);
            return Move(input, pos2, pos1);
        }

        public string Part2(string input, string password)
        {
            string[] lines = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = lines.Length - 1; i >= 0; i--)
            {
                password = CommandReverse(lines[i], password);
            }
            return password;
        }
    }
}
