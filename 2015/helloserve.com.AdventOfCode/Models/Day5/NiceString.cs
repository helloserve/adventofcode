using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Models.Day5
{
    public class NiceString
    {
        protected string _value;

        public NiceString(string value)
        {
            _value = value;
        }

        public virtual bool IsNice()
        {
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            string[] excludes = new string[] { "ab", "cd", "pq", "xy" };
            int vowelCount = 0;
            int doubleCount = 0;
            int excludeCount = 0;

            char c;
            for (int i = 0; i < _value.Length; i++)
            {
                c = _value[i];
                if (vowels.Contains(c))
                    vowelCount++;
                if (i > 0)
                {
                    string lastDu = string.Format("{0}{1}", _value[i - 1], _value[i]);
                    if (lastDu[0] == lastDu[1])
                        doubleCount++;
                    if (excludes.Contains(lastDu))
                        excludeCount++;
                }
            }

            return vowelCount >= 3 && doubleCount >= 1 && excludeCount == 0;
        }
    }
}
