using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace helloserve.com.AdventOfCode.Test.Base
{
    [TestClass]
    public class VersesTests
    {
        protected string FromFile(string filename)
        {
            return File.ReadAllText(Path.Combine(@".\Input", filename));
        }
    }
}

