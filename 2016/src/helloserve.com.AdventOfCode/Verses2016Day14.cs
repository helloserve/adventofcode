using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day14
    {
        private ConcurrentDictionary<int, string> _hashTable = new ConcurrentDictionary<int, string>();
        private List<int> _keys = new List<int>();
        private bool _halt = false;

        private string HashOnce(string input, MD5 md5)
        {
            byte[] inputBuffer = Encoding.UTF8.GetBytes(input);
            byte[] hashBuffer = md5.ComputeHash(inputBuffer);
            return $"{BitConverter.ToString(hashBuffer):x}".Replace("-", "").ToLower();
        }

        public string Hash(string input, MD5 md5 = null, int? stretchTo = 0, int index = 0)
        {
            md5 = md5 ?? MD5.Create();
            string result = HashOnce(input, md5);

            for (int i = 0; i < stretchTo; i++)
            {
                result = HashOnce(result, md5);
            }

            return result;
        }

        public void CalculateHashRange(string salt, int startIndex, int skipCount, int? stretchTo = null)
        {
            int index = startIndex;
            using (MD5 md5 = MD5.Create())
            {
                while (!_halt)
                {
                    string hash = Hash($"{salt}{index}", md5: md5, stretchTo: stretchTo);
                    _hashTable.AddOrUpdate(index, hash, (k, v) => hash);
                    index += skipCount;
                }
            }
        }

        public List<Task> StartHashCalc(string salt, int? stretchTo = null)
        {
            List<Task> calcs = new List<Task>();
            int threadCount = Environment.ProcessorCount - 1;
            for (int i = 0; i < threadCount; i++)
            {
                int taskIndex = i;
                calcs.Add(Task.Run(() => CalculateHashRange(salt, taskIndex, threadCount, stretchTo: stretchTo)));
            }

            return calcs;
        }

        public char? Contains3Chars(string value)
        {
            for (int i = 0; i + 2 < value.Length; i++)
            {
                if (value[i] == value[i + 1] && value[i] == value[i + 2])
                    return value[i];
            }

            return null;
        }

        public bool Contains5Chars(string value, char c)
        {
            for (int i = 0; i + 4 < value.Length; i++)
            {
                if (value[i] == c && value[i + 1] == c && value[i + 2] == c && value[i + 3] == c && value[i + 4] == c)
                    return true;
            }

            return false;
        }

        public int FindKey(int count)
        {
            int i = 0;
            string hash3;
            char? c;
            string hash5;
            while (_keys.Count < count)
            {
                while (!_hashTable.ContainsKey(i)) { }

                hash3 = _hashTable[i];
                c = Contains3Chars(hash3);
                if (c.HasValue)
                {
                    bool contains5 = false;
                    int j = 1;
                    while (j <= 1000 && !contains5)
                    {
                        while (!_hashTable.ContainsKey(i + j)) { }

                        hash5 = _hashTable[i + j];
                        contains5 |= Contains5Chars(hash5, c.Value);

                        j++;
                    }

                    if (contains5)
                        _keys.Add(i);
                }

                i++;
            }

            return _keys[count - 1];
        }

        public int Part1(string salt, int keyCount)
        {
            List<Task> hashCalcs = StartHashCalc(salt);
            int keyIndex = FindKey(keyCount);

            //some cleanup
            _halt = true;
            foreach (Task calc in hashCalcs)
            {
                calc.Wait();
            }

            return keyIndex;
        }

        public int Part2(string salt, int keyCount)
        {
            List<Task> hashCalcs = StartHashCalc(salt, stretchTo: 2016);
            int keyIndex = FindKey(keyCount);

            //some cleanup
            _halt = true;
            foreach (Task calc in hashCalcs)
            {
                calc.Wait();
            }

            return keyIndex;
        }
    }
}
