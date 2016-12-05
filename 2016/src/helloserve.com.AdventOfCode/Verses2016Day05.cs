using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day05
    {
        public string Part1(string input)
        {
            List<Task> tasks = new List<Task>();
            string code = string.Empty;
            object codeObject = new object();
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                int startIndex = i;
                tasks.Add(Task.Run(() => GetCodeItem(input, startIndex, Environment.ProcessorCount))
                    .ContinueWith(a =>
                    {
                        lock (codeObject)
                        {
                            code = $"{code}{a.Result}";
                        }
                    }));
            }
            while (true)
            {
                if (tasks.Count == 0)
                    break;

                if (tasks[0].IsCompleted)
                    tasks.RemoveAt(0);
            }

            return code;
        }

        public string GetCodeItem(string input, int startIndex, int skip, int? range = int.MaxValue)
        {
            for (int i = startIndex; i < range; i += skip)
            {
                MD5 md5 = MD5.Create();
                md5.Initialize();
                string hash = Encoding.ASCII.GetString(md5.ComputeHash(Encoding.ASCII.GetBytes($"{input}{i}")));
                if (hash.StartsWith("00000"))
                    return hash.Substring(5, 1);
            }

            return null;
        }

        //public string GetHexString(byte[] buffer)
        //{
        //    string hexString = string.Empty;
        //    for (int i = 0; i < buffer.Length; i++)
        //    {
        //        hexString = $"{hexString}{buffer[i]:x}";
        //    }

        //    return hexString;
        //}
    }
}
