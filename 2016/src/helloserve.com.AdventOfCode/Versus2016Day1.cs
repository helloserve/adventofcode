using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public static class Day1Extensions
    {
        public static char Turn(this char currentDirection, string turn)
        {
            string directions = "NESW";
            int index = directions.IndexOf(currentDirection);

            if (turn == "L")
                index++;

            if (turn == "R")
                index--;

            if (index > 3)
                index = index - 4;
            if (index < 0)
                index = 4 + index;

            return directions[index];
        }

        public static Vector2 GetDirectionVector(this char direction)
        {
            switch (direction)
            {
                case 'N':
                    return Vector2.North;
                case 'E':
                    return Vector2.East;
                case 'S':
                    return Vector2.South;
                case 'W':
                    return Vector2.West;
                default:
                    throw new ArgumentException();
            }
        }

        public static Vector2 Move(this Vector2 position, Vector2 direction, int steps)
        {
            return direction
                .Multiply(steps)
                .Add(position);
        }
    }

    public class Vector2 : IEquatable<Vector2>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2 Multiply(int scalar)
        {
            return new Vector2()
            {
                X = this.X *= scalar,
                Y = this.Y *= scalar
            };
        }

        public Vector2 Add(Vector2 vector)
        {
            return new Vector2()
            {
                X = this.X += vector.X,
                Y = this.Y += vector.Y
            };
        }

        public int RectilinearDistance()
        {
            return Math.Abs(X) + Math.Abs(Y);
        }

        public bool Equals(Vector2 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public static Vector2 Zero
        {
            get { return new Vector2() { X = 0, Y = 0 }; }
        }

        public static Vector2 North
        {
            get { return new Vector2() { X = 1, Y = 0 }; }
        }

        public static Vector2 East
        {
            get { return new Vector2() { X = 0, Y = -1 }; }
        }

        public static Vector2 South
        {
            get { return new Vector2() { X = -1, Y = 0 }; }
        }

        public static Vector2 West
        {
            get { return new Vector2() { X = 0, Y = 1 }; }
        }
    }

    public class Versus2016Day1
    {
        public Versus2016Day1() { }

        public int Part1(string input)
        {
            Vector2 position = Vector2.Zero;

            char direction = 'N';

            string[] commands = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i].Trim();
                string dir = command.Substring(0, 1);
                int steps = int.Parse(command.Substring(1, command.Length - 1));

                direction = direction.Turn(dir);

                position = position.Move(direction.GetDirectionVector(), steps);
            }

            return position.RectilinearDistance();
        }

        public int Part2(string input)
        {
            Vector2 position = Vector2.Zero;
            List<Vector2> positions = new List<Vector2>();

            char direction = 'N';

            string[] commands = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i].Trim();
                string dir = command.Substring(0, 1);
                int steps = int.Parse(command.Substring(1, command.Length - 1));

                direction = direction.Turn(dir);
                Vector2 dirVector = direction.GetDirectionVector();
                for (int j = 0; j < steps; j++)
                {
                    position = position.Move(dirVector, 1);
                    if (positions.Any(v => v.Equals(position)))
                        return position.RectilinearDistance();

                    positions.Add(position);
                }

            }

            return position.RectilinearDistance();
        }
    }
}
