using System;
using System.Collections.Generic;
using System.Text;

namespace Project_PokerCards.Model
{
    class Card
    {
      public static int CardValue(string val)
        {
            switch (val)
            {
                case "T": return 10;
                case "J": return 11;
                case "Q": return 12;
                case "K": return 13;
                case "A": return 14;
                default: return int.Parse(val);
            }
        }
    }
}
