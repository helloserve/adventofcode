using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Models.Day7
{
    public class Wire : Input
    {
        public string Name { get; set; }

        public Input Input { get; set; }

        protected override int GetOutput()
        {
            return Input.Output;
        }
    }
}
