using NUnit.Framework;
using Project_PokerCards;
using Project_PokerCards.Data;

namespace TestPokerCards
{
    public class Tests
    {
        FileReader fr;
        PokerGame pokerGame;
        string filepath;
        [SetUp]
        public void Setup()
        {
            fr = new FileReader();
            pokerGame = new PokerGame();
            filepath = fr.FilePath;
        }

        [TearDown]
        public void TearDown()
        {
            fr = null;
            pokerGame = null;
        }

        [Test]
        public void TestFileExist()
        {
            bool fileInput = fr.IfExists();
            if (fileInput)
            {
                Assert.Pass("file exist"); ;
            }
            else
            {
                Assert.Fail("File doesnot exist");
            }
        }

        [Test]
        public void ResultPlayingCards()
        {
           
            (int playerWin_1, int playerWin_2) = pokerGame.PlayersResult(filepath);

            Assert.AreEqual(263, playerWin_1);
            Assert.AreEqual(237, playerWin_2);

        }

    }
}