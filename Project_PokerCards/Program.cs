using Project_PokerCards.Data;
using System;

namespace Project_PokerCards
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate filereader
            FileReader fr = new FileReader();
            // checking if file exists
            bool fileInput = fr.IfExists();
            if (!fileInput)
            {
                return;
            }
            // get filepath value 
            string filepath = fr.FilePath;

            //instantiate poker game class
            PokerGame pokerGame = new PokerGame();
            int playerWin_1 = 0;
            int playerWin_2 = 0;

            //get result of each player
            (playerWin_1, playerWin_2) = pokerGame.PlayersResult(filepath);

            Console.WriteLine("Player 1: {0} hands", playerWin_1);
            Console.WriteLine("Player 2: {0} hands", playerWin_2);

            Console.ReadLine();
        }

    }

}