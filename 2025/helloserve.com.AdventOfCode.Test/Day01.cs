namespace helloserve.com.AdventOfCode.Test;

[TestClass]
public sealed class Day01
{
	[TestMethod]
	[DataRow("Day01.txt", "3")]
	public void Part1(string filename, string expected)
	{
		AdventOfCode.Day01 day01 = new();
		day01.Filename = filename;
		var result = day01.Part1();
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	[DataRow("Day01.txt", "6")]
	public void Part2(string filename, string expected)
	{
		AdventOfCode.Day01 day01 = new();
		day01.Filename = filename;
		var result = day01.Part2();
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	[DataRow(4, 4)]
	[DataRow(-5, 95)]
	[DataRow(100, 0)]
	[DataRow(345, 45)]
	[DataRow(-781, 19)]
	[DataRow(-500, 0)]
	public void CircularModTest(int value, int expected)
	{
		var actual = AdventOfCode.Day01.CircularMod(value, 100);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(50, -68, 82, 1)]
	[DataRow(50, -300, 50, 3)]
	[DataRow(95, 10, 5, 1)]
	[DataRow(5, -10, 95, 1)]
	[DataRow(5, -810, 95, 9)]
	public void CircularMoveTest(int start, int move, int expectedPosition, int expectedPasses)
	{
		var result = AdventOfCode.Day01.CircularMove(start, move, 100);
		Assert.AreEqual(expectedPosition, result.position);
		Assert.AreEqual(expectedPasses, result.passes);
	}
}
