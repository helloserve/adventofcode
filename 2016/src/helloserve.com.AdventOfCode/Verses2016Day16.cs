using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day16
    {
        public string Expand(string a, int length)
        {
            char[] result = a.ToCharArray();
            while (result.Length < length)
            {
                char[] b = new char[result.Length];
                for (int i = 0; i < result.Length; i++)
                {
                    b[result.Length - 1 - i] = result[i] == '1' ? '0' : '1';
                }

                char[] expandedResult = new char[result.Length + 1 + b.Length];
                Array.Copy(result, expandedResult, result.Length);
                expandedResult[result.Length] = '0';
                Array.Copy(b, 0, expandedResult, result.Length + 1, b.Length);
                result = expandedResult;
            }

            char[] finalResult = new char[length];
            Array.Copy(result, finalResult, length);
            return new string(finalResult);
        }

        public string Checksum(string value)
        {
            char[] input = value.ToCharArray();
            char[] checksum = new char[0];
            int checksumLength = 0;
            while (checksumLength == 0 || checksumLength % 2 == 0)
            {
                checksum = new char[input.Length / 2];
                int i = 0;
                checksumLength = 0;
                while (i + 1 < input.Length)
                {
                    if (input[i] == input[i + 1])
                        checksum[checksumLength] = '1';
                    else
                        checksum[checksumLength] = '0';

                    i += 2;
                    checksumLength++;
                }

                input = checksum;
            }

            return new string(checksum);
        }

        public string Part1(string state, int size)
        {
            return Checksum(Expand(state, size));
        }
    }
}
