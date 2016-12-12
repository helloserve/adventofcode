using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day10
    {
        public int Part1(string input, int value1, int value2)
        {
            string[] lines = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < lines.Length; i++)
            {
                ParseLine(input);
            }            
        }

        private void ParseLine(string input)
        {
            string word = input.Substring(0, input.IndexOf(" "));
            if (word == "value")
                AssignValue(input);            
        }

        private void AssignValue(string input)
        {

        }
    }
}
