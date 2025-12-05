using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace helloserve.com.AdventOfCode;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net10_0)]
[MemoryDiagnoser]
public class Day05 : Base
{
    public override string Filename { get; set; } = "Day05.txt";

    private List<FreshRange> ProcessRanges(string[] lines, out int lineIndex)
    {
        List<FreshRange> ranges = new();
        lineIndex = 0;
        while (lines[lineIndex].Length > 0)
        {
            var range = new FreshRange(lines[lineIndex]);
            var overlapping = ranges.Where(r => r.IsOverlappingOrAdjacent(range)).ToList();

            while (overlapping.Any())
            {
                foreach (var overlap in overlapping)
                {
                    range.Join(overlap);
                    ranges.Remove(overlap);
                }

                overlapping = ranges.Where(r => r.IsOverlappingOrAdjacent(range)).ToList();
            }

            ranges.Add(range);
            lineIndex++;
        }
        lineIndex++;

        return ranges;
    }

    [Benchmark, BenchmarkCategory("Day 05")]
    public override string Part1()
    {
        string[] lines = File.ReadAllLines(Filename);
        var ranges = ProcessRanges(lines, out int lineIndex);
        long freshCount = 0;
        while (lineIndex < lines.Length)
        {
            var id = long.Parse(lines[lineIndex]);
            var rangesContained = ranges.Where(r => r.IsInRange(id)).ToList();
            if (rangesContained.Any())
            {
                freshCount++;
            }
            lineIndex++;
        }

        return freshCount.ToString();
    }

    [Benchmark, BenchmarkCategory("Day 05")]
    public override string Part2()
    {
        string[] lines = File.ReadAllLines(Filename);
        var ranges = ProcessRanges(lines, out int lineIndex);
        var freshRangeTotal = ranges.Sum(r => r.End - r.Start + 1);
        return freshRangeTotal.ToString();
    }
}

public class FreshRange
{
    public string RangeStr => $"{Start:N0}-{End:N0}";

    public long Start { get; private set; }
    public long End { get; private set; }

    public FreshRange(string rangeStr)
    {
        var parts = rangeStr.Split('-', StringSplitOptions.RemoveEmptyEntries);

        Start = long.Parse(parts[0]);
        End = long.Parse(parts[1]);

        if (Start > End)
        {
            throw new Exception("Invalid Range");
        }
    }

    public bool IsInRange(long value)
    {
        return value >= Start && value <= End;
    }

    public bool IsOverlappingOrAdjacent(FreshRange range)
    {
        return ((Start >= range.Start && Start <= range.End) || (End <= range.End && End >= range.Start) ||
                (range.Start >= Start && range.Start <= End) || (range.End >= Start && range.End <= End)) ||    //overlapping
               (Start == range.End + 1 || End == range.Start - 1); //adjacent
    }

    public void Join(FreshRange range)
    {
        Start = Math.Min(Start, range.Start);
        End = Math.Max(End, range.End);
    }

    public override string ToString()
    {
        return RangeStr;
    }
}