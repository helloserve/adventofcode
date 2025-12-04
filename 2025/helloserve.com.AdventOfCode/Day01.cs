using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace helloserve.com.AdventOfCode;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net10_0)]
[MemoryDiagnoser]
public class Day01 : Base
{
	public override string Filename { get; set; } = "Day01.txt";

	private int ParseLine(string line)
	{
		var directionPart = line.Substring(0, 1);
		var valuePart = int.Parse(line.Substring(1));

		return directionPart switch
		{
			"L" => -valuePart,
			"R" => valuePart,
			_ => throw new InvalidOperationException(),
		};
	}

	[Benchmark, BenchmarkCategory("Day 01")]
	public override string Part1()
	{
		var input = ReadMultiLineInput(Filename, ParseLine);

		int position = 50;
		int zeroStops = 0;

		foreach (var move in input)
		{
			position += move;
			var newPosition = CircularMod(position, 100);

			if (newPosition >= 100 || newPosition < 0)
				throw new Exception("invalid position");

			position = newPosition;

			if (position == 0)
			{
				zeroStops++;
			}
		}

		return zeroStops.ToString();
	}

	[Benchmark, BenchmarkCategory("Day 01")]
	public override string Part2()
	{
		var input = ReadMultiLineInput(Filename, ParseLine);

		int position = 50;
		int zeroStops = 0;

		foreach (var move in input)
		{
			var moveResult = CircularMove(position, move, 100);
			var newPosition = moveResult.position;

			if (newPosition >= 100 || newPosition < 0)
			{
				throw new Exception("invalid position");
			}

			position = newPosition;
			zeroStops += moveResult.passes;
		}

		return zeroStops.ToString();
	}

	public static int CircularMod(int value, int modulus)
	{
		var mod = value % modulus;

		if (value >= modulus || mod == 0)
		{
			return mod;
		}
		else if (value < 0)
		{
			return -((-value) % modulus) + modulus;
		}

		return value;
	}

	public static (int position, int passes) CircularMove(int start, int move, int modulus)
	{
		if (move == 0)
		{
			return (start, 0);
		}

		var wholeRotations = Math.Abs(move / modulus);
		var partialRotations = move % modulus;

		var rawPosition = start + partialRotations;
		var newPosition = CircularMod(rawPosition, modulus);

		if ((start < 0 && rawPosition > 0) ||
			(rawPosition < 0 && start > 0) ||
			(start < modulus && rawPosition > modulus) ||
			(rawPosition < modulus && start > modulus) ||
			newPosition == 0)
		{
			wholeRotations++;
		}

		return (newPosition, wholeRotations);
	}
}
