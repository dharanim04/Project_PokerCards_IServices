using NUnit.Framework;
using Project_PokerCards.Application;
using Project_PokerCards.DataAccess;

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
        //Test files
        //checking if file path is not empty
        [Test]
        public void TestilePath()
        {
            if (filepath.Length == 0)
            {
                Assert.Fail("Filepath is empty");
            }
            else
            {
                Assert.Pass("Filepath is not empty");
            }
        }
        //checking if file exist
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
        
        //Test Playing Cards
        //checking to if returns value
        [Test]
        public void ReturnsSomeValue()
        {
            (int playerWin_1, int playerWin_2) = pokerGame.PlayersResult(filepath);

            Assert.IsTrue(playerWin_1>=0);
            Assert.IsTrue(playerWin_2>=0);
        }
        //checking for expected value from input file.
        [Test]
        public void ResultPlayingCards()
        { 
            (int playerWin_1, int playerWin_2) = pokerGame.PlayersResult(filepath);

            Assert.AreEqual(263, playerWin_1);
            Assert.AreEqual(237, playerWin_2);
        }

    }
}