using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day08
    {
        public int Part1(string input, int width = 50, int height = 6, string filename = null)
        {
            int[,] screen = new int[width, height];

            string[] commands = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            ApplyCommands(commands, screen, width, height);

            int totalOn = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    totalOn += screen[x, y];
                }
            }

            if (!string.IsNullOrEmpty(filename))
                DumpScreen(screen, width, height, filename);

            return totalOn;
        }

        private void DumpScreen(int[,] screen, int width, int height, string filename)
        {
            string output = string.Empty;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    output = $"{output}{screen[x, y]}";
                }
                output = $"{output}\r\n";
            }

            File.WriteAllText(filename, output);
        }

        private void ApplyCommands(string[] commands, int[,] screen, int width, int height)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                ApplyCommand(commands[i], screen, width, height);
            }
        }

        private void ApplyCommand(string command, int[,] screen, int width, int height)
        {
            if (command.StartsWith("rect"))
                ApplyRectangle(command, screen, width, height);
            if (command.StartsWith("rotate"))
                ApplyRotate(command, screen, width, height);
        }

        private void ApplyRectangle(string command, int[,] screen, int width, int height)
        {
            string[] sizes = command.Replace("rect ", "").Split(new char[] { 'x' }, StringSplitOptions.RemoveEmptyEntries);
            int w = Math.Min(width, int.Parse(sizes[0]));
            int h = Math.Min(height, int.Parse(sizes[1]));

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    screen[x, y] = 1;
                }
            }
        }

        private void ApplyRotate(string command, int[,] screen, int width, int height)
        {
            string[] parts = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts[1] == "row")
                ApplyRotateRow(int.Parse(parts[2].Substring("y=".Length)), int.Parse(parts[4]), screen, width, height);
            else
                ApplyRotateColumn(int.Parse(parts[2].Substring("x=".Length)), int.Parse(parts[4]), screen, width, height);
        }

        private void ApplyRotateRow(int row, int offset, int[,] screen, int width, int height)
        {
            int[] buffer = new int[width];
            int offsetx;
            for (int x = 0; x < width; x++)
            {
                offsetx = x + offset;

                if (offsetx >= width)
                    offsetx = offsetx - width;

                buffer[offsetx] = screen[x, row];
            }

            for (int x = 0; x < width; x++)
            {
                screen[x, row] = buffer[x];
            }
        }

        private void ApplyRotateColumn(int column, int offset, int[,] screen, int width, int height)
        {
            int[] buffer = new int[height];
            int offsety;
            for (int y = 0; y < height; y++)
            {
                offsety = y + offset;

                if (offsety >= height)
                    offsety = offsety - height;

                buffer[offsety] = screen[column, y];
            }

            for (int y = 0; y < height; y++)
            {
                screen[column, y] = buffer[y];
            }
        }
    }
}
