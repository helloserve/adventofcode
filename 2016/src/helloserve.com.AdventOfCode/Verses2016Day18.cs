using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day18
    {
        public int Part1(string input, int rowCount)
        {
            List<char[]> rows = new List<char[]>();
            rows.Add(input.ToCharArray());
            int safeTiles = rows[0].Count(x => x == '.');
            for (int i = 1; i < rowCount; i++)
            {
                rows.Add(BuildRow(rows[i - 1], ref safeTiles));
            }

            return safeTiles;
        }

        private char[] BuildRow(char[] previousRow, ref int safeTiles)
        {
            char[] newRow = new char[previousRow.Length];
            char l;
            char c;
            char r;
            for (int i = 0; i < newRow.Length; i++)
            {
                if (i == 0)
                    l = '.';
                else
                    l = previousRow[i - 1];

                c = previousRow[i];

                if (i == newRow.Length - 1)
                    r = '.';
                else
                    r = previousRow[i + 1];

                if ((l == '^' && c == '^' && r == '.') ||
                    (l == '.' && c == '^' && r == '^') ||
                    (l == '^' && c == '.' && r == '.') ||
                    (l == '.' && c == '.' && r == '^'))
                    newRow[i] = '^';
                else
                {
                    newRow[i] = '.';
                    safeTiles++;
                }
            }

            return newRow;
        }
    }
}
