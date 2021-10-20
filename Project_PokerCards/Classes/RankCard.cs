using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_PokerCards.Classes
{
    class RankCard: CompareClass
    {
        public int GetRank(List<string> playerSuit, List<int> playerValues)
        {
            var groupedCountedList = playerValues.GroupBy(x => x).Select(o => o.Count()).ToList();

            bool isSameSuit = IsSameSuit(playerSuit);
            bool isConsecutive = IsConsecutive(playerValues);

            if (isSameSuit && isConsecutive && playerValues.Contains(14)) return 10; //Royal Flush
            else if (isSameSuit && isConsecutive) return 9; //Straight flush
            else if (groupedCountedList.Count() == 2 && groupedCountedList.Contains(4)) return 8; //Four of a kind
            else if (groupedCountedList.Count() == 2 && groupedCountedList.Contains(3) && groupedCountedList.Contains(2)) return 7; //Full house
            else if (isSameSuit) return 6; //Flush
            else if (isConsecutive) return 5; //Straight
            else if (groupedCountedList.Count() == 3 && groupedCountedList.Contains(3)) return 4; //Three of a kind
            else if (groupedCountedList.Count() == 3 && groupedCountedList.Contains(2)) return 3; //Two pairs
            else if (groupedCountedList.Count() == 4) return 2; //Pair
            else if (groupedCountedList.Count() == 5) return 1; //High card

            return 0;
        }
    }
}
