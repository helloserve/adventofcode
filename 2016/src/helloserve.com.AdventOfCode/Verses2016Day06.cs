using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day06
    {
        public string Part1(string input)
        {
            string[] lines = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            List<char>[] characters = Unwrap(lines);

            char[] message = new char[characters.Length];
            for (int i = 0; i < characters.Length; i++)
            {
                message[i] = characters[i].GroupBy(c => c).Select(x => new { C = x.Key, Count = x.Count() }).OrderByDescending(x => x.Count).Take(1).Single().C;
            }

            return new string(message);
        }

        private List<char>[] Unwrap(string[] lines)
        {
            List<char>[] characters = new List<char>[lines[0].Length];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (characters[j] == null)
                        characters[j] = new List<char>();

                    characters[j].Add(lines[i][j]);
                }
            }
            return characters;
        }
    }
}
