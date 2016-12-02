using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day02
    {
        public Verses2016Day02() { }

        public int Part1(string input)
        {
            string[][] keyPad = new string[][] { new string[] { "1", "2", "3" }, new string[] { "4", "5", "6" }, new string[] { "7", "8", "9" } };
            string[] commandLines = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int x = 1;
            int y = 1;

            string code = string.Empty;

            for (int i = 0; i < commandLines.Length; i++)
            {
                foreach (char c in commandLines[i])
                {
                    switch (c)
                    {
                        case 'U':
                        case 'u':
                            y--;
                            break;
                        case 'D':
                        case 'd':
                            y++;
                            break;
                        case 'L':
                        case 'l':
                            x--;
                            break;
                        case 'R':
                        case 'r':
                            x++;
                            break;
                    }

                    y = Math.Max(0, Math.Min(y, keyPad.Length - 1));
                    x = Math.Max(0, Math.Min(x, keyPad[0].Length - 1));
                }

                string button = keyPad[y][x];
                code = $"{code}{button}";
            }

            return int.Parse(code);
        }
    }
}
