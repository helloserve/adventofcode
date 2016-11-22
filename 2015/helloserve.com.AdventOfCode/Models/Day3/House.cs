using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode.Models.Day3
{
    public class House
    {
        public static House GetHouse(ref List<House> houses, int x, int y)
        {
            House house = null;
            int i = 0;
            while (i < houses.Count)
            {
                if (houses[i].X == x && houses[i].Y == y)
                {
                    house = houses[i];
                    break;
                }
                i++;
            }
            if (house == null)
            {
                house = new House(x, y);
                houses.Add(house);
            }

            return house;
        }

        public int X;
        public int Y;

        public House North;
        public House South;
        public House East;
        public House West;

        public bool Visited;
        public int Presents;

        public House(int x, int y)
        {
            X = x;
            Y = y;
        }

        public House GoNorth(ref List<House> houses)
        {
            if (North == null)
            {
                North = GetHouse(ref houses, X, Y - 1);
                North.South = this;
            }
            return North;
        }

        public House GoSouth(ref List<House> houses)
        {
            if (South == null)
            {
                South = GetHouse(ref houses, X, Y + 1);
                South.North = this;
            }
            return South;
        }

        public House GoEast(ref List<House> houses)
        {
            if (East == null)
            {
                East = GetHouse(ref houses, X + 1, Y);
                East.West = this;
            }
            return East;
        }

        public House GoWest(ref List<House> houses)
        {
            if (West == null)
            {
                West = GetHouse(ref houses, X - 1, Y);
                West.East = this;
            }
            return West;
        }

        public int TotalWithAtLeastOnePresent()
        {
            if (Visited)
                return 0;

            Visited = true;

            int houses = 0;

            if (Presents >= 1)
                houses++;

            if (North != null)
                houses += North.TotalWithAtLeastOnePresent();
            if (South != null)
                houses += South.TotalWithAtLeastOnePresent();
            if (East != null)
                houses += East.TotalWithAtLeastOnePresent();
            if (West != null)
                houses += West.TotalWithAtLeastOnePresent();

            return houses;
        }
    }
}
