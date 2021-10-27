using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Project_PokerCards.Application;
using Project_PokerCards.DataAccess;
using System;

namespace Project_PokerCards
{
    class Program
    {
        public static void Main(string[] args)
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

            //calling poker game service
            var serviceProvider = AddServices();
            IPokerGame _pokerGame = serviceProvider.GetService<IPokerGame>();
            int playerWin_1 = 0;
            int playerWin_2 = 0;


            //get result of each player
            (playerWin_1, playerWin_2) = _pokerGame.PlayersResult(filepath);

            Console.WriteLine("Player 1: {0} hands", playerWin_1);
            Console.WriteLine("Player 2: {0} hands", playerWin_2);

            Console.ReadLine();
        }
        private static ServiceProvider AddServices()
        {
            //setup our DI-DependencyInjection
            return new ServiceCollection()
                    .AddSingleton<IPokerGame, PokerGame>()
                    .BuildServiceProvider();
        }
    }
}