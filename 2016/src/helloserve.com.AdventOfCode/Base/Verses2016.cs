﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Base
{
    public class Verses2016
    {
        public string ReadWord(string input, ref int index, string expectedValue = null)
        {
            string result = string.Empty;
            for (; index < input.Length; index++)
            {
                if (string.IsNullOrEmpty(result) && input[index] == ' ')
                    continue;

                if (input[index] == ' ')
                    break;

                result = $"{result}{input[index]}";
            }

            if (!string.IsNullOrEmpty(expectedValue) && expectedValue != result)
                throw new InvalidOperationException($"{result} did not match {expectedValue}");


            return result;
        }

        public int ReadInt(string input, ref int index)
        {
            return int.Parse(ReadWord(input, ref index));
        }
    }
}