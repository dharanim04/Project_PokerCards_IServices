using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_PokerCards.Classes
{
    public class CompareClass
    {
        public int TieBreak(int rank, List<int> playerValues_1, List<int> playerValues_2)
        {
            switch (rank)
            {
                case 10:
                    //Royal Flush
                    return 0;
                case 9:
                    //Straight flush
                    return CheckForHighCard(playerValues_1, playerValues_2);
                case 8:
                    //Four of a kind
                    return CheckForPairs(playerValues_1, playerValues_2);
                case 7:
                    //Full house
                    int duplicatePlayer1Val = playerValues_1.GroupBy(x => x).Where(g => g.Count() == 3).FirstOrDefault().FirstOrDefault();
                    int duplicatePlayer2Val = playerValues_2.GroupBy(x => x).Where(g => g.Count() == 3).FirstOrDefault().FirstOrDefault();

                    if (duplicatePlayer1Val > duplicatePlayer2Val) return 1;
                    else if (duplicatePlayer1Val < duplicatePlayer2Val) return 2;
                    else
                    {
                        duplicatePlayer1Val = playerValues_1.GroupBy(x => x).Where(g => g.Count() == 2).FirstOrDefault().FirstOrDefault();
                        duplicatePlayer2Val = playerValues_2.GroupBy(x => x).Where(g => g.Count() == 2).FirstOrDefault().FirstOrDefault();

                        if (duplicatePlayer1Val > duplicatePlayer2Val) return 1;
                        else if (duplicatePlayer1Val < duplicatePlayer2Val) return 2;
                        else return 0;
                    }
                case 6:
                    //Flush
                    return CheckForHighCard(playerValues_1, playerValues_2);
                case 5:
                    //Straight
                    return CheckForHighCard(playerValues_1, playerValues_2);
                case 4:
                    //Three of a kind
                    return CheckForPairs(playerValues_1, playerValues_2);
                case 3:
                    //Two pairs
                    var duplicatePlayer1 = playerValues_1.GroupBy(x => x).SelectMany(grp => grp.Skip(1)).ToList();
                    var duplicatePlayer2 = playerValues_2.GroupBy(x => x).SelectMany(grp => grp.Skip(1)).ToList();

                    if (duplicatePlayer1.All(duplicatePlayer2.Contains))
                    {
                        int remainPlayer1 = playerValues_1.Except(duplicatePlayer1).FirstOrDefault();
                        int remainPlayer2 = playerValues_2.Except(duplicatePlayer2).FirstOrDefault();

                        if (remainPlayer1 > remainPlayer2) return 1;
                        else if (remainPlayer1 < remainPlayer2) return 2;
                        else return 0;
                    }
                    else
                    {
                        return CheckForHighCard(duplicatePlayer1, duplicatePlayer2);
                    }
                case 2:
                    //Pair
                    return CheckForPairs(playerValues_1, playerValues_2);
                case 1:
                    //High card
                    return CheckForHighCard(playerValues_1, playerValues_2);
                default:
                    break;
            }
            return 0;
        }
        //checking pair
        public int CheckForPairs(List<int> playerValues_1, List<int> playerValues_2)
        {
            int duplicatePlayer1 = playerValues_1.GroupBy(x => x).SelectMany(grp => grp.Skip(1)).FirstOrDefault();
            int duplicatePlayer2 = playerValues_2.GroupBy(x => x).SelectMany(grp => grp.Skip(1)).FirstOrDefault();

            if (duplicatePlayer1 > duplicatePlayer2) return 1;
            else if (duplicatePlayer1 < duplicatePlayer2) return 2;
            else
            {
                playerValues_1.RemoveAll(s => s == duplicatePlayer1);
                playerValues_2.RemoveAll(s => s == duplicatePlayer2);
                return CheckForHighCard(playerValues_1, playerValues_2);
            }
        }
        //Checking for highest card
        public int CheckForHighCard(List<int> playerValues_1, List<int> playerValues_2)
        {
            int len = playerValues_1.Count();
            playerValues_1.Sort();
            playerValues_2.Sort();

            for (int i = len - 1; i >= 0; i--)
            {
                if (playerValues_1[i] > playerValues_2[i]) return 1;
                else if (playerValues_1[i] < playerValues_2[i]) return 2;
                else continue;
            }

            return 0;
        }
        //checking for consecutive
        public bool IsConsecutive(List<int> playerValues)
        {
            return (playerValues.Distinct().Count() == 5 && (playerValues.Max() - playerValues.Min() + 1) == 5);
        }
        //checking for same suit
        public bool IsSameSuit(List<string> playerSuit)
        {
            return !playerSuit.Any(o => o != playerSuit[0]);
        }

    }
}
