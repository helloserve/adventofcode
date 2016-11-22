using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Models.Day5
{
    public class NicerString : NiceString
    {
        public NicerString(string value) : base(value)
        {
        }

        public override bool IsNice()
        {
            List<string> pairLetters = new List<string>();

            int pairCount = 0;
            int splitCount = 0;

            char c;
            char cc;
            char ccc;
            for (int i = 0; i < _value.Length; i++)
            {
                c = _value[i];
                if (i > 0)
                {
                    cc = _value[i - 1];
                    string pair = string.Format("{0}{1}", cc, c);
                    int pairIndex = pairLetters.IndexOf(pair);

                    if (pairIndex == -1)
                        pairLetters.Add(pair);
                    else if (i - 1 > pairIndex + 1)
                        pairCount++;

                    if (i > 1)
                    {
                        ccc = _value[i - 2];
                        if (ccc == c)
                            splitCount++;
                    }
                }
            }

            return pairCount >= 1 && splitCount >= 1;
        }
    }
}
