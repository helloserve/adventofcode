namespace helloserve.com.AdventOfCode.Test;

[TestClass]
public class Day03
{
	[TestMethod]
	[DataRow("Day03.txt", "357")]
	public void Day03_Part1_Test(string filename, string expected)
	{
		var day03 = new AdventOfCode.Day03();
		day03.Filename = filename;
		var actual = day03.Part1();
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow("Day03.txt", "3121910778619")]
	public void Day03_Part2_Test(string filename, string expected)
	{
		var day03 = new AdventOfCode.Day03();
		day03.Filename = filename;
		var actual = day03.Part2();
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow("818181911112111", 92)]
	[DataRow("811111111111119", 89)]
	[DataRow("234234234234278", 78)]
	[DataRow("987654321111111", 98)]
	[DataRow("5342626167342261132346432442524535654423854254336833422424525424435362223322423132824617223244222225", 88)]
	[DataRow("3858362282172", 88)]
	public void Day03_BatteryBank_Part1_Test(string bank, int expected)
	{
		var b = new BatteryBank(bank, 2);
		Assert.AreEqual(expected, b.BankJoltage);
	}

	[TestMethod]
	[DataRow("818181911112111", 888911112111)]
	[DataRow("811111111111119", 811111111119)]
	[DataRow("234234234234278", 434234234278)]
	[DataRow("987654321111111", 987654321111)]
	public void Day03_BatteryBank_Part2_Test(string bank, long expected)
	{
		var b = new BatteryBank(bank, 12);
		Assert.AreEqual(expected, b.BankJoltage);
	}
}
