using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Models.Day6
{
    public class LightGrid
    {
        protected int[] _lights;

        public LightGrid()
        {
            _lights = new int[1000000];
        }

        protected int GetIndex(int x, int y)
        {
            return 1000 * y + x;
        }

        public void ProcessCommand(string command)
        {
            Regex regex = new Regex(@"(?<command>\D*) ((?<fromX>\d*),(?<fromY>\d*)) \D* ((?<toX>\d*),(?<toY>\d*))");
            Match match = regex.Match(command);
            if (!match.Success)
                throw new ArgumentException();

            string cmd = match.Groups["command"].Value;
            int fromX = int.Parse(match.Groups["fromX"].Value);
            int fromY = int.Parse(match.Groups["fromY"].Value);
            int toX = int.Parse(match.Groups["toX"].Value);
            int toY = int.Parse(match.Groups["toY"].Value);

            for (int x = fromX; x <= toX; x++)
            {
                for (int y = fromY; y <= toY; y++)
                {
                    switch (cmd)
                    {
                        case "turn on":
                            TurnOn(x, y);
                            break;
                        case "turn off":
                            TurnOff(x, y);
                            break;
                        case "toggle":
                            Toggle(x, y);
                            break;
                    }

                }
            }
        }

        public virtual int NumberOfLightsOn
        {
            get
            {
                int on = 0;
                for (int i = 0; i < _lights.Length; i++)
                {
                    on += _lights[i];
                }
                return on;
            }
        }

        protected virtual void TurnOn(int x, int y)
        {
            _lights[GetIndex(x, y)] = 1;
        }

        protected virtual void TurnOff(int x, int y)
        {
            _lights[GetIndex(x, y)] = 0;
        }

        protected virtual void Toggle(int x, int y)
        {
            int index = GetIndex(x, y);
            if (_lights[index] == 1)
                _lights[index] = 0;
            else
                _lights[index] = 1;
        }
    }
}
