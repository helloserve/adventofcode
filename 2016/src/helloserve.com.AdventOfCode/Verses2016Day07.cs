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
            string outside = string.Empty;
            string inside = string.Empty;
            bool isOutside = true;
            for (int i = 0; i < ip.Length; i++)
            {
                if (ip[i] == '[' && isOutside)
                {
                    isOutside = false;
                    inside = $"{inside}_";
                    continue;
                }
                if (ip[i] == ']' && !isOutside)
                {
                    isOutside = true;
                    outside = $"{outside}_";
                    continue;
                }

                if (isOutside)
                    outside = $"{outside}{ip[i]}";
                else
                    inside = $"{inside}{ip[i]}";

            }
            return new string[] { outside, inside };
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
            return ContainsAbba(ipParts[0]) && !abbaInHypernet;
        }

        public int Part1(string input)
        {
            List<string> ips = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> ipValues = ips.Select(x => IsTls(x) ? 1 : 0).ToList();
            return ipValues.Sum();
        }

        public string[] ContainsAba(string part, char[] characters = null)
        {
            List<string> abas = new List<string>();
            int i = 0;
            while (i + 2 < part.Length)
            {
                if (part[i] == part[i + 2] && part[i] != part[i + 1])
                {
                    if (characters == null || (part[i] == characters[0] && part[i + 1] == characters[1]))
                        abas.Add(new string(new char[] { part[i], part[i + 1], part[i + 2] }));
                }

                i++;
            }

            return abas.ToArray();
        }

        public bool IsSsl(string ip)
        {
            string[] ipParts = ParseIp(ip);

            if (ipParts[0].Length < 3 || ipParts[1].Length < 3)
                return false;

            string[] abas = ContainsAba(ipParts[0]);
            for (int i = 0; i < abas.Length; i++)
            {
                string[] babs = ContainsAba(ipParts[1], new char[] { abas[i][1], abas[i][0] });
                if (babs.Length > 0)
                    return true;
            }

            return false;
        }

        public int Part2(string input)
        {
            List<string> ips = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> ipValues = ips.Select(x => IsSsl(x) ? 1 : 0).ToList();
            return ipValues.Sum();
        }
    }
}
