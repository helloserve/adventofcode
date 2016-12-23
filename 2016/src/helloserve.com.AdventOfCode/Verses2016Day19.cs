using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day19
    {
        public int Part1(int count)
        {
            int[] elves = new int[count];
            //initialize
            for (int i = 0; i < count; i++)
                elves[i] = i + 1;

            while (count > 1)
            {
                int newCount = count / 2;

                int[] newCircle = new int[newCount];
                int j = 0;
                int nj;
                while (j < count)
                {
                    nj = j / 2;
                    if (nj >= newCircle.Length)
                    {
                        int[] adjustedCircle = new int[newCount];
                        Array.Copy(newCircle, 1, adjustedCircle, 0, newCount - 1);
                        newCircle = adjustedCircle;
                        nj = newCount - 1;
                    }

                    newCircle[nj] = elves[j];
                    j += 2;
                }

                elves = newCircle;
                count = newCount;
            }

            return elves[0];
        }
    }
}
