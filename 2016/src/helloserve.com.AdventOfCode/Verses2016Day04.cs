using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace helloserve.com.AdventOfCode
{
    public class Room
    {
        public int SectorId { get; set; }

        private string _encryptedValue { get; set; }
        private List<CharacterOrder> _encryptedCharOrders { get; set; }
        private string _checksum { get; set; }

        public Room(string roomCode)
        {
            Regex regex = new Regex(@"(?<encrypted>[a-z-]*)(?<sectorId>\d*)\[{1}(?<checksum>[a-z]{5})\]{1}$");
            Match match = regex.Match(roomCode);
            if (!match.Success)
                return;

            SectorId = int.Parse(match.Groups["sectorId"].Value);
            _encryptedValue = match.Groups["encrypted"].Value.Replace("-", "");
            _checksum = match.Groups["checksum"].Value;
            Decrypt();
        }

        public bool IsValid
        {
            get
            {
                bool result = true;
                for (int i = 0; i < _checksum.Length; i++)
                {
                    result &= _checksum[i] == _encryptedCharOrders[i].Character;
                }

                return result;
            }
        }

        private void Decrypt()
        {
            _encryptedCharOrders = new List<CharacterOrder>();

            Dictionary<char, CharacterOrder> orderLookup = new Dictionary<char, AdventOfCode.Room.CharacterOrder>();

            for (int i = 0; i < _encryptedValue.Length; i++)
            {
                char c = _encryptedValue[i];
                if (orderLookup.ContainsKey(c))
                    orderLookup[c].Order++;
                else
                    orderLookup.Add(c, new CharacterOrder() { Character = c, Order = 1 });
            }

            _encryptedCharOrders = orderLookup.Values.ToList();
            _encryptedCharOrders.Sort();
            _encryptedCharOrders = _encryptedCharOrders.Take(_checksum.Length).ToList();
        }

        private class CharacterOrder : IComparable
        {
            public char Character { get; set; }
            public int Order { get; set; }

            public int CompareTo(object obj)
            {
                CharacterOrder other = obj as CharacterOrder;
                if (other == null)
                    throw new ArgumentException();

                int result = other.Order.CompareTo(Order);
                if (result == 0)
                    result = Character.CompareTo(other.Character);

                return result;
            }
        }
    }

    public class Verses2016Day04
    {
        public int Part1(string input)
        {
            string[] lines = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            List<Room> rooms = new List<AdventOfCode.Room>();
            foreach (var line in lines)
            {
                rooms.Add(new AdventOfCode.Room(line));
            }

            return rooms.Sum(r => r.IsValid ? r.SectorId : 0);
        }
    }
}
