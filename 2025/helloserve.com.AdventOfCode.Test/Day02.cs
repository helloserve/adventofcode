namespace helloserve.com.AdventOfCode.Test;

[TestClass]
public class Day02
{
	[TestMethod]
	[DataRow("Day02.txt", "1227775554")]
	public void Day02_Part1(string filename, string expected)
	{
		AdventOfCode.Day02 day02 = new();
		day02.Filename = filename;
		var result = day02.Part1();
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	[DataRow("Day02.txt", "4174379265")]
	public void Day02_Part2(string filename, string expected)
	{
		AdventOfCode.Day02 day02 = new();
		day02.Filename = filename;
		var result = day02.Part2();
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	[DataRow(1188511885, true)]
	[DataRow(222220, false)]
	[DataRow(222222, true)]
	[DataRow(38593859, true)]
	[DataRow(82882882, false)]
	[DataRow(808080, true)]
	public void Day02_IsExtendedId_Test(long value, bool expected)
	{
		Assert.AreEqual(expected, Range.IsExtendedInvalidId(value));
	}
}
