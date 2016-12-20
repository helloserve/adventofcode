using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Base
{
    public class Verses2016
    {
        private ConcurrentDictionary<string, object> _fileLocks = new ConcurrentDictionary<string, object>();
        private readonly char[] _nonWordChars = new char[] { ' ', ',', '.' };

        public string ReadWord(string input, ref int index, string expectedValue = null)
        {
            string result = string.Empty;
            for (; index < input.Length; index++)
            {
                if (string.IsNullOrEmpty(result) && _nonWordChars.Contains(input[index]))
                    continue;

                if (_nonWordChars.Contains(input[index]))
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

        public void InitializeOutput(string filename)
        {
            lock (FileLock(filename))
            {
                if (File.Exists(filename))
                    File.Delete(filename);
            }
        }

        public void LogOutput(string filename, string contents)
        {
            lock (FileLock(filename))
            {
                File.AppendAllText(filename, contents);
            }
        }
        public void DumpOutput(string filename, string contents, Encoding encoding)
        {
            lock (FileLock(filename))
            {
                File.WriteAllText(filename, contents, encoding);
            }
        }


        private object FileLock(string filename)
        {
            object fileLock;
            if (!_fileLocks.ContainsKey(filename))
            {
                fileLock = new object();
                _fileLocks.AddOrUpdate(filename, fileLock, (k, v) => fileLock);
            }
            else
                fileLock = _fileLocks[filename];

            return fileLock;
        }
    }
}
