using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day09
    {
        public string Decompress(string input)
        {
            char c;
            string result = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                c = input[i];
                if (c == '(')
                {
                    result = $"{result}{Expand(input, ref i)}";
                }
                else
                {
                    result = $"{result}{c}";
                }
            }

            return result.Replace(" ", "");
        }

        private string Expand(string input, ref int i)
        {
            i++;
            char c = input[i];
            string countStr = string.Empty;
            while (c != 'x')
            {
                countStr = $"{countStr}{c}";
                i++;
                c = input[i];
            }
            i++;
            c = input[i];
            string repeatStr = string.Empty;
            while (c != ')')
            {
                repeatStr = $"{repeatStr}{c}";
                i++;
                c = input[i];
            }

            int count = int.Parse(countStr);
            int repeat = int.Parse(repeatStr);
            i++;
            repeatStr = input.Substring(i, count);

            i += count - 1;
            string result = string.Empty;
            for (int r = 0; r < repeat; r++)
            {
                result = $"{result}{repeatStr}";
            }
            return result;
        }

        public long DecompressCount(string input)
        {
            char c;
            long result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                c = input[i];
                if (c == '(')
                {
                    result += ExpandCount(input, ref i);
                }
                else
                {
                    result++;
                }
            }

            return result;
        }

        private long ExpandCount(string input, ref int i)
        {
            i++;
            char c = input[i];
            string countStr = string.Empty;
            while (c != 'x')
            {
                countStr = $"{countStr}{c}";
                i++;
                c = input[i];
            }
            i++;
            c = input[i];
            string repeatStr = string.Empty;
            while (c != ')')
            {
                repeatStr = $"{repeatStr}{c}";
                i++;
                c = input[i];
            }

            int count = int.Parse(countStr);
            int repeat = int.Parse(repeatStr);
            i++;
            string repeatSource = input.Substring(i, count);
            long repeatCount = 0;
            for (int j = 0; j < count; j++)
            {
                c = repeatSource[j];
                if (c == '(')
                {
                    repeatCount += ExpandCount(repeatSource, ref j);
                }
                else
                {
                    repeatCount++;
                }
            }

            i += count - 1;
            //string result = string.Empty;
            //for (int r = 0; r < repeat; r++)
            //{
            //    result += $"{result}{repeatStr}";
            //}
            return repeatCount * repeat;
        }

        public int Part1(string input)
        {
            List<string> lines = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return lines.Sum(x => Decompress(x).Length);
        }

        public long Part2(string input)
        {
            List<string> lines = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            long result = 0;
            for (int i = 0; i < lines.Count; i++)
            {
                result += DecompressCount(lines[i]);
            }
            return result;
        }
    }
}
