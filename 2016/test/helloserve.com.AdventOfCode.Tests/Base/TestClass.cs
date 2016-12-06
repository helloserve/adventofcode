using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace helloserve.com.AdventOfCode.Tests.Base
{
    public class TestClass
    {
        public string ReadTextSource(string filename)
        {
            string path = $".\\Resources\\{filename}";
            return File.ReadAllText(path);
        }
    }
}
