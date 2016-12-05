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
        public char Character { get; set; }
    }

    public class Verses2016Day05
    {
        private bool _codeComplete = false;
        private List<CodeItem> _items = new List<CodeItem>();
        private object _itemLock = new object();

        public string Part1(string input)
        {
            List<Task> tasks = new List<Task>();
            
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                int startIndex = i;
                tasks.Add(Task.Run(() => GetCodeItem(input, startIndex, Environment.ProcessorCount)));
            }
            while (true)
            {
                if (tasks[0].IsCompleted)
                    tasks.RemoveAt(0);
                if (tasks.Count == 0)
                    break;
                if (_items.Count > 10)
                {
                    _codeComplete = true;
                }
            }

            string code = new String(_items.OrderBy(i => i.Index).Take(8).Select(i => i.Character).ToArray());
            return code;
        }

        private void GetCodeItem(string input, int startIndex, int skip, int? range = int.MaxValue)
        {
            using (MD5 md5 = MD5.Create())
            {
                for (int i = startIndex; i < range; i += skip)
                {
                    if (_codeComplete)
                        break;

                    string hash = BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes($"{input}{i}"))).Replace("-", "").ToLower();
                    if (hash.StartsWith("00000"))
                    {
                        lock (_itemLock)
                        {
                            _items.Add(new CodeItem() { Index = i, Character = hash[5] });
                        }
                    }
                }
            }
        }
    }
}
