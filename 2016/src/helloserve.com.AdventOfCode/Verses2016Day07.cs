using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Verses2016Day07
    {
        public string[] ParseIp(string ip)
        {
            Regex regex = new Regex(@"(\D*)\[(\D*)\](\D*)");
            Match match = regex.Match(ip);
            if (match.Success)
                return new string[] { match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value };
            else
                return new string[3];
        }

        public bool ContainsAbba(string part)
        {
            int i = 0;
            while (i + 3 < part.Length)
            {
                if (part[i] == part[i + 3] && part[i + 1] == part[i + 2] && part[i] != part[i + 1])
                {
                    return true;
                }

                i++;
            }

            return false;
        }

        public bool IsTls(string ip)
        {
            string[] ipParts = ParseIp(ip);

            if (ipParts[0].Length < 4)
                return false;

            bool abbaInHypernet = ContainsAbba(ipParts[1]);
            bool result = ContainsAbba(ipParts[0]) && !abbaInHypernet;

            if (!result && ipParts.Length > 2)
            {
                if (ipParts[2].Length < 4)
                    return false;

                result = ContainsAbba(ipParts[2]) && !abbaInHypernet;
            }

            return result;
        }

        public int Part1(string input)
        {
            List<string> ips = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return ips.Select(x => IsTls(x) ? 1 : 0).Sum();
        }
    }
}
