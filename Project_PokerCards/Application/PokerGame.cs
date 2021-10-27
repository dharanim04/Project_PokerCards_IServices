using Project_PokerCards.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project_PokerCards.Application
{
    public interface IPokerGame
    {
        public (int, int) PlayersResult(string filePath);
    }
    public class PokerGame : IPokerGame
    {
    
        //instaniate cards class
        RankCard rankClas = new RankCard();
        string _filepath;

        int _playerWin_1;
        int _playerWin_2;
        /// <summary>
        /// returns count of each players
        /// </summary>
        /// <param name="filePath">inputs filepath</param>
        /// <returns>return two integer values of each player </returns>
        public (int, int) PlayersResult(string filePath)
        {
            _filepath = filePath;
            _playerWin_1 = 0;
            _playerWin_2 = 0;
            try
            {
                //get data from file read line by line
                foreach (var line in File.ReadLines(_filepath))
                {
                    List<string> player1 = line.Split(' ').Take(5).ToList();
                    List<string> player2 = line.Split(' ').Skip(5).Take(5).ToList();

                    //extracting Card suits
                    List<string> playerSuit_1 = player1.Select(x => { return x[1].ToString(); }).ToList();
                    List<string> playerSuit_2 = player2.Select(x => { return x[1].ToString(); }).ToList();

                    //extracting card values
                    List<int> playerValues_1 = player1.Select(x => { return Card.CardValue(x[0].ToString()); }).ToList();
                    List<int> playerValues_2 = player2.Select(x => { return Card.CardValue(x[0].ToString()); }).ToList();

                    int rankPlayer1 = rankClas.GetRank(playerSuit_1, playerValues_1);
                    int rankPlayer2 = rankClas.GetRank(playerSuit_2, playerValues_2);

                    if (rankPlayer1 > rankPlayer2) _playerWin_1++;
                    else if (rankPlayer2 > rankPlayer1) _playerWin_2++;
                    else
                    {
                        int tieRank = rankClas.TieBreak(rankPlayer1, playerValues_1, playerValues_2);

                        switch (tieRank)
                        {
                            case 1:
                                _playerWin_1++;
                                break;
                            case 2:
                                _playerWin_2++;
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return (_playerWin_1, _playerWin_2);
        }
    }
}
