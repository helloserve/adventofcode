using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day02
    {
        public Verses2016Day02() { }

        public string Part1(string input)
        {
            string[][] keyPad = new string[][] { new string[] { "1", "2", "3" }, new string[] { "4", "5", "6" }, new string[] { "7", "8", "9" } };
            return Input(input, keyPad, 1, 1);
        }

        public string Part2(string input)
        {
            string[][] keyPad = new string[][]
            {
                new string[] { null, null, "1", null, null },
                new string[] { null, "2", "3", "4", null },
                new string[] { "5", "6", "7", "8", "9" },
                new string[] { null, "A", "B", "C", null },
                new string[] { null, null, "D", null, null }
            };
            return Input(input, keyPad, 0, 2);
        }

        private static string Input(string input, string[][] keyPad, int x, int y)
        {
            string[] commandLines = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            string code = string.Empty;

            for (int i = 0; i < commandLines.Length; i++)
            {
                foreach (char c in commandLines[i])
                {
                    int newx = x;
                    int newy = y;
                    switch (c)
                    {
                        case 'U':
                        case 'u':
                            newy--;
                            break;
                        case 'D':
                        case 'd':
                            newy++;
                            break;
                        case 'L':
                        case 'l':
                            newx--;
                            break;
                        case 'R':
                        case 'r':
                            newx++;
                            break;
                    }

                    newy = Math.Max(0, Math.Min(newy, keyPad.Length - 1));
                    newx = Math.Max(0, Math.Min(newx, keyPad[newy].Length - 1));

                    if (string.IsNullOrEmpty(keyPad[newy][newx]))
                    {
                        newx = x;
                        newy = y;
                    }

                    x = newx;
                    y = newy;
                }

                string button = keyPad[y][x];
                code = $"{code}{button}";
            }

            return code;
        }
    }
}
