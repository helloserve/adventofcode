namespace helloserve.com.AdventOfCode.Test;

[TestClass]
public class Day04
{
	[TestMethod]
	[DataRow("Day04.txt", "13")]
	public void Day04_Test_Part1(string filename, string expected)
	{
		AdventOfCode.Day04 day04 = new();
		day04.Filename = filename;
		var result = day04.Part1();
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	[DataRow("Day04.txt", "43")]
	public void Day04_Test_Part2(string filename, string expected)
	{
		AdventOfCode.Day04 day04 = new();
		day04.Filename = filename;
		var result = day04.Part2();
		Assert.AreEqual(expected, result);
	}
}
