using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace helloserve.com.AdventOfCode;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net10_0)]
[MemoryDiagnoser]
public class Day02 : Base
{
    public override string Filename { get; set; } = "Day02.txt";

    private Range ParseValue(string value)
    {
        return Range.Make(value);
    }

    [Benchmark, BenchmarkCategory("Day 02")]
    public override string Part1()
    {
        var ranges = ReadSingleLineInput(Filename, ParseValue);
        var finalSum = ranges.Sum(o =>
        {
            o.FindInvalidIds();
            return o.InvalidIdSum;
        });

        return finalSum.ToString();
    }

    [Benchmark, BenchmarkCategory("Day 02")]
    public override string Part2()
    {
        var ranges = ReadSingleLineInput(Filename, ParseValue);
        var finalSum = ranges.Sum(o =>
        {
            o.FindExtendedInvalidIds();
            return o.InvalidIdSum;
        });

        return finalSum.ToString();
    }
}

public class Range
{
    public long Start { get; set; }
    public long End { get; set; }
    public long[] InvalidIds { get; internal set; }
    public long InvalidIdSum { get; set; }

    public void FindInvalidIds()
    {
        var invalidIds = new List<long>();
        InvalidIdSum = 0;
        for (long i = 0; i < (End - Start) + 1; i++)
        {
            var value = Start + i;
            var valueStr = value.ToString();
            if (valueStr.Length % 2 != 0)
            {
                continue;
            }

            var halfLength = valueStr.Length / 2;
            if (string.Equals(valueStr.Substring(0, halfLength), valueStr.Substring(halfLength, halfLength)))
            {
                invalidIds.Add(value);
                InvalidIdSum += (value);
            }
        }

        InvalidIds = invalidIds.ToArray();
    }

    public void FindExtendedInvalidIds()
    {
        var invalidIds = new List<long>();
        InvalidIdSum = 0;

        for (long i = 0; i < (End - Start) + 1; i++)
        {
            var value = Start + i;
            if (IsExtendedInvalidId(value))
            {
                invalidIds.Add(value);
                InvalidIdSum += (value);
            }
        }

        InvalidIds = invalidIds.ToArray();
    }

    public static bool IsExtendedInvalidId(long value)
    {
        var valueStr = value.ToString();

        int index = 0;
        string firstPart = string.Empty;
        string secondPart = string.Empty;

        for (int length = 1; length <= valueStr.Length / 2; length++)
        {
            if (valueStr.Length % length != 0)
            {
                continue;
            }

            if (index + length > valueStr.Length || index + length + length > valueStr.Length)
            {
                break;
            }

            firstPart = valueStr.Substring(index, length);
            secondPart = valueStr.Substring(index + length, length);

            while (string.Equals(firstPart, secondPart))
            {
                index++;

                if (index + length > valueStr.Length || index + length + length > valueStr.Length)
                {
                    break;
                }

                firstPart = valueStr.Substring(index, length);
                secondPart = valueStr.Substring(index + length, length);
            }

            if (index + length + length > valueStr.Length)
            {
                return true;
            }

            index = 0;
        }

        return false;
    }

    public static Range Make(string rangeString)
    {
        var parts = rangeString.Split('-', StringSplitOptions.RemoveEmptyEntries);
        return new Range
        {
            Start = long.Parse(parts[0]),
            End = long.Parse(parts[1]),
        };
    }
}
