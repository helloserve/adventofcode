using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day20
    {
        public long Part1(string input)
        {
            List<IpRange> ranges = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => new IpRange(x)).ToList();
            ranges.Sort();

            long ip = 0;
            for (int i = 0; i < ranges.Count; i++)
            {
                if (ip >= ranges[i].Low)
                    ip = ranges[i].High + 1;
                else
                    return ip;
            }

            return -1;
        }

        public long Part2(string input, long minRange, long maxRange)
        {
            List<IpRange> ranges = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => new IpRange(x)).ToList();
            ranges.Sort();

            long ipCount = 0;
            for (int i = 0; i < ranges.Count; i++)
            {
                if (i == 0)
                    ipCount += ranges[i].Low - minRange;

                if (i >= 1 && ranges[i].Low > ranges[i - 1].High)
                    ipCount += ranges[i].Low - ranges[i - 1].High - 1;

                if (i == ranges.Count - 1)
                    ipCount += maxRange - ranges[i].High;
            }

            return ipCount;
        }
    }

    public class IpRange : IComparable<IpRange>
    {
        public long Low { get; set; }
        public long High { get; set; }

        public IpRange(string range)
        {
            string[] values = range.Split(new char[] { '-' });
            Low = long.Parse(values[0]);
            High = long.Parse(values[1]);
        }

        public int CompareTo(IpRange other)
        {
            return Low.CompareTo(other.Low);
        }
    }
}
