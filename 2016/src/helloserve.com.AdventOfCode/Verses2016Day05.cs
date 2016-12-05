using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class CodeItem
    {
        public int Index { get; set; }
        public char Character6 { get; set; }
        public char Character7 { get; set; }
    }

    public class Verses2016Day05
    {
        private bool _codeComplete = false;
        private List<CodeItem> _items = new List<CodeItem>();
        private object _itemLock = new object();

        public string Part1(string input)
        {
            string code = string.Empty;

            ThreadOut(input, () =>
            {
                if (_codeComplete)
                    return;

                code = new String(_items.OrderBy(i => i.Index).Take(8).Select(i => i.Character6).ToArray());
                if (code.Length == 8)
                    _codeComplete = true;
            });

            return code;
        }

        public string Part2(string input)
        {
            char[] code = new char[8];
            ThreadOut(input, () =>
            {
                int pos;
                foreach (CodeItem item in _items.OrderBy(i => i.Index))
                {
                    if (int.TryParse(new string(item.Character6, 1), out pos))
                    {
                        if (pos < code.Length && code[pos] == 0)
                            code[pos] = item.Character7;
                    }
                }

                if (!code.Any(x => x == '\0'))
                    _codeComplete = true;
            });



            return new string(code);
        }

        private void ThreadOut(string input, Action testForCode)
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                int startIndex = i;
                tasks.Add(Task.Run(() => GetCodeItem(input, startIndex, Environment.ProcessorCount, testForCode)));
            }
            while (true)
            {
                if (tasks[0].IsCompleted)
                    tasks.RemoveAt(0);
                if (tasks.Count == 0)
                    break;
            }
        }

        private void GetCodeItem(string input, int startIndex, int skip, Action testForCode)
        {
            using (MD5 md5 = MD5.Create())
            {
                for (int i = startIndex; i < int.MaxValue; i += skip)
                {
                    if (_codeComplete)
                        break;

                    string hash = BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes($"{input}{i}"))).Replace("-", "").ToLower();
                    if (hash.StartsWith("00000"))
                    {
                        lock (_itemLock)
                        {
                            _items.Add(new CodeItem()
                            {
                                Index = i,
                                Character6 = hash[5],
                                Character7 = hash[6]
                            });
                            testForCode();
                        }
                    }
                }
            }
        }
    }
}
