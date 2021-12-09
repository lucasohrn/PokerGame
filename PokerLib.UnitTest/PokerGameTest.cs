using NUnit.Framework;
using Poker;
using Poker.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLib.UnitTest
{
	[TestFixture]
	public class PokerGameTest
	{
        private Poker.Lib.IPokerGame game;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void PokerGameInitializeithPlayers()
        {
            game = new PokerGame(new string[2] { "PlayerOne", "PlayerTwo" });
            Assert.AreEqual(2, this.game.Players.Length);
        }

        [Test]
        public void PokerGameCanSaveToFile()
        {
            string[] players = { "Anna", "Petra" };
            string fileName = "savedgame.txt";
            PokerGame game = new PokerGame(players);
            game.SaveGame(fileName);
            string[] lines;

            lines = File.ReadAllLines(fileName);

            Assert.AreEqual("[\"Anna\",\"Petra\"] [0,0]", lines[0]);
        }

        [Test]
        public void GameCanLoadAFile()
        {
            string[] players = { "Sven", "Per" };
            string fileName = "savedgame.txt";
            PokerGame game = new PokerGame(players);
            game.SaveGame(fileName);

            PokerGame LoadGame = new PokerGame(fileName);

            Assert.AreEqual(2, game.Players.Length);
            Assert.AreEqual("Sven", game.Players[0].Name);
            Assert.AreEqual(0, game.Players[0].Wins);
            Assert.AreEqual("Per", game.Players[1].Name);
            Assert.AreEqual(0, game.Players[1].Wins);
        }

        [Test, Sequential]
        public void PokerGameHaveWorkingEvents([Values(0, 1, 2, 3, 4)] int i)
        {
            PokerGame game = new PokerGame(new string[2] { "PlayerOne", "PlayerTwo" });
            int count = 0;
            bool eventsIsWorking = false;

            game.NewDeal += IfNewDealEventIsWorking;
            game.SelectCardsToDiscard += IfSelectCardsToDiscard;
            game.RecievedReplacementCards += IfRecievedReplacementCardsWork;
            game.ShowAllHands += IfTheShowAllHandsEventIsWorking;
            game.Winner += IfTheWinnerEventIsWorking;
            game.Draw += IfDrawEventIsWorking;

            void IfNewDealEventIsWorking()
            {
                eventsIsWorking = true;
                count++;
            }
            void IfSelectCardsToDiscard(IPlayer player)
            {
                player.Discard = new ICard[] { player.Hand[i] };
                player.Discard = new ICard[] { player.Hand[i] };
                eventsIsWorking = true;
                count++;
                game.gameIsOver = true;
            }

            void IfTheShowAllHandsEventIsWorking()
            {
                eventsIsWorking = true;
                count++;
                game.gameIsOver = true;
            }
            void IfTheWinnerEventIsWorking(IPlayer player)
            {
                eventsIsWorking = true;
                count++;
                game.gameIsOver = true;
            }
            void IfRecievedReplacementCardsWork(IPlayer player) { }
            void IfDrawEventIsWorking(IPlayer[] player) { }


            game.RunGame();
            Assert.IsTrue(eventsIsWorking);
        }
    }
}
