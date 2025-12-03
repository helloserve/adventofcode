using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace helloserve.com.AdventOfCode;

[SimpleJob(RuntimeMoniker.Net80)]
[MemoryDiagnoser]
public class Day03 : Base
{
	public override string Filename { get; set; } = "Day03.txt";

	private BatteryBank ParseLinePart1(string line)
	{
		return new BatteryBank(line, 2);
	}

	private BatteryBank ParseLinePart2(string line)
	{
		return new BatteryBank(line, 12);
	}

	[Benchmark, BenchmarkCategory("Day 03")]
	public override string Part1()
	{
		var batteryBanks = ReadMultiLineInput(Filename, ParseLinePart1);
		return batteryBanks.Sum(o => o.BankJoltage).ToString();
	}

	[Benchmark, BenchmarkCategory("Day 03")]
	public override string Part2()
	{
		var batteryBanks = ReadMultiLineInput(Filename, ParseLinePart2);
		return batteryBanks.Sum(o => o.BankJoltage).ToString();
	}
}

public struct BatteryBank
{
	public string Bank;
	public int BatteriesCount;
	public byte[] Batteries;

	public long BankJoltage => long.Parse(string.Join("", Batteries[0..BatteriesCount]));

	public BatteryBank(string bankString, int count)
	{
		Bank = bankString;
		BatteriesCount = count;

		Batteries = bankString
			.Substring(bankString.Length - count, count)
			.Select(o => byte.Parse(o.ToString()))
			.ToArray();

		for (int i = bankString.Length - count - 1; i >= 0; i--)
		{
			byte val = byte.Parse(bankString[i].ToString());

			SetBatteryValue(val, 0, count);
		}
	}

	private void SetBatteryValue(byte val, int index, int remainingCount)
	{
		if (remainingCount == 0)
		{
			return;
		}

		if (val >= Batteries[index])
		{
			SetBatteryValue(Batteries[index], index + 1, remainingCount - 1);
			Batteries[index] = val;
		}
	}
}
