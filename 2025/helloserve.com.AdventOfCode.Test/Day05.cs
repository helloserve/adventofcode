namespace helloserve.com.AdventOfCode.Test;

[TestClass]
public class Day05
{
    [TestMethod]
    [DataRow("Day05.txt", "3")]
    public void Day05_Part1_Test(string filename, string expected)
    {
        AdventOfCode.Day05 day05 = new();
        day05.Filename = filename;
        var result = day05.Part1();
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow("Day05.txt", "14")]
    public void Day05_Part2_Test(string filename, string expected)
    {
        AdventOfCode.Day05 day05 = new();
        day05.Filename = filename;
        var result = day05.Part2();
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow("2-4,6-8", false)]
    [DataRow("12345-567890,567891-9867865", true)]
    [DataRow("567891-9867865,12345-567890", true)]
    [DataRow("10-16,14-20", true)]
    public void Day05_FreshRange_OverlappingOrAdjacentTests(string lines, bool expected)
    {
        var ranges = lines.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(r => new FreshRange(r)).ToList();
        Assert.AreEqual(expected, ranges[0].IsOverlappingOrAdjacent(ranges[1]));
    }

    [TestMethod]
    [DataRow("12345-567890,567891-9867865", "12345-9867865")]
    [DataRow("10-16,14-20", "10-20")]
    public void Day05_FreshRange_JoinTests(string lines, string expected)
    {
        var ranges = lines.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(r => new FreshRange(r)).ToList();
        ranges[0].Join(ranges[1]);
        var expectedRange = new FreshRange(expected);
        Assert.AreEqual(expectedRange.Start, ranges[0].Start);
        Assert.AreEqual(expectedRange.End, ranges[0].End);
    }
}
