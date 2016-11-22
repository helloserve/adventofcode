using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Models.Day6
{
    public class BrightGrid : LightGrid
    {
        protected override void TurnOn(int x, int y)
        {
            _lights[GetIndex(x, y)]++;
        }

        protected override void TurnOff(int x, int y)
        {
            int index = GetIndex(x, y);
            if (_lights[index] > 0)
                _lights[index]--;
        }

        protected override void Toggle(int x, int y)
        {
            _lights[GetIndex(x, y)] += 2;
        }
    }
}
