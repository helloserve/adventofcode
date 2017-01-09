using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day21
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

        public string RotateLeft(string input)
        {
            char[] chars = new char[input.Length];
            for (int i = 1; i < input.Length; i++)
            {
                chars[i - 1] = input[i];
            }
            chars[chars.Length - 1] = input[0];

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

            if (index >= 4)
                index += 2;
            else
                index++;

            input = RotateRight(input, index);

            return input;
        }

        public string Reverse(string input, char letter1, char letter2)
        {
            int index1 = -1;
            int index2 = -1;
            int range;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == letter1 && index1 < 0)
                    index1 = i;
                if (input[i] == letter2 && index2 < 0)
                    index2 = i;

                if (index1 > 0 && index2 > 0)
                    break;
            }
            range = index2 - index1;

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
    }
}
