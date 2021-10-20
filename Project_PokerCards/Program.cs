using Project_PokerCards.Data;
using System;

namespace Project_PokerCards
{
    class Program
    {
        static void Main(string[] args)
        {
          
            // checking if file exists
            FileReader fr = new FileReader();
                      
            int playerWin_1 = 0;
            int playerWin_2 = 0;

            bool fileInput = fr.IfExists();
            if (!fileInput)
            {
                return;
            }
            // get filepath value
            string filepath = fr.FilePath;
            PokerGame pokerGame = new PokerGame();

            (playerWin_1, playerWin_2) = pokerGame.PlayersResult(filepath);
            

            Console.WriteLine("Player 1: {0} hands", playerWin_1);
            Console.WriteLine("Player 2: {0} hands", playerWin_2);

            Console.ReadLine();
        }

    }

}