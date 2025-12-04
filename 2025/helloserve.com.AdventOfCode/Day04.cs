using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace helloserve.com.AdventOfCode;

[SimpleJob(RuntimeMoniker.Net80)]
[MemoryDiagnoser]
public class Day04 : Base
{
	public override string Filename { get; set; } = "Day04.txt";


	[Benchmark, BenchmarkCategory("Day 04")]
	public override string Part1()
	{
		var lines = File.ReadAllLines(Filename);
		var totalInput = string.Join("", lines);
		Grid grid = new Grid(lines[0].Length, lines.Count(), totalInput);
		return grid.GetAccessibleCells(false).ToString();
	}

	[Benchmark, BenchmarkCategory("Day 04")]
	public override string Part2()
	{
		var lines = File.ReadAllLines(Filename);
		var totalInput = string.Join("", lines);
		Grid grid = new Grid(lines[0].Length, lines.Count(), totalInput);

		int accessibleCount = grid.GetAccessibleCells(true);
		int totalAccessibleCount = accessibleCount;
		while (accessibleCount > 0)
		{
			accessibleCount = grid.GetAccessibleCells(true);
			totalAccessibleCount += accessibleCount;
		}

		return totalAccessibleCount.ToString();
	}
}

public struct Grid
{
	public int Width;
	public int Height;
	public GridCell[] GridCells;

	public Grid(int width, int height, string grid)
	{
		Width = width;
		Height = height;

		List<GridCell> cells = new List<GridCell>();
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				cells.Add(new GridCell()
				{
					HasPaper = char.Equals(grid[GetIndex(x, y)], '@')
				});
			}
		}

		GridCells = cells.ToArray();
	}

	private int GetIndex(int x, int y) => (y * Height) + x;

	private bool HasPaper(int x, int y)
	{
		if (x < 0 || x >= Width || y < 0 || y >= Height)
		{
			return false;
		}

		return GridCells[GetIndex(x, y)].HasPaper;
	}

	public bool CanAccessCell(int x, int y)
	{
		if (!HasPaper(x, y))
		{
			return false;
		}

		int sumOfNeighbours =
			(HasPaper(x - 1, y) ? 1 : 0) +
			(HasPaper(x + 1, y) ? 1 : 0) +
			(HasPaper(x, y - 1) ? 1 : 0) +
			(HasPaper(x, y + 1) ? 1 : 0) +
			(HasPaper(x - 1, y - 1) ? 1 : 0) +
			(HasPaper(x - 1, y + 1) ? 1 : 0) +
			(HasPaper(x + 1, y - 1) ? 1 : 0) +
			(HasPaper(x + 1, y + 1) ? 1 : 0);

		return sumOfNeighbours < 4;
	}

	public int GetAccessibleCells(bool process)
	{
		int totalAccessible = 0;
		for (int x = 0; x < Width; x++)
		{
			for (int y = 0; y < Height; y++)
			{
				bool canAccess = CanAccessCell(x, y);
				if (canAccess)
				{
					totalAccessible++;
					if (process)
					{
						GridCells[GetIndex(x, y)].HasPaper = false;
					}
				}

			}
		}

		return totalAccessible;
	}
}

public struct GridCell
{
	public bool HasPaper;
}