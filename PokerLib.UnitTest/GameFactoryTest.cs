using NUnit.Framework;
using Poker.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLib.UnitTest
{
    public class GameFactoryTest
    {
        [Test]
        public void GameFactoryReturnsPlayers()
        {
            string[] players = new string[]
             {
                 new string("Lucas"),
                 new string("Sixten")
            };
            var gameFactory = GameFactory.NewGame(players);

            var expectedNumberOfPlayers = 2;

            Assert.AreEqual(expectedNumberOfPlayers, gameFactory.Players.Length);
        }

        [Test]
        public void GameFactoryLoadedFileIsNotEmpty()
        {
            string[] players = { "Lucas", "Sixten" };
            string fileName = "savedgame.txt";
            PokerGame game = new PokerGame(players);
            game.SaveGame(fileName);

            var LoadGame = GameFactory.LoadGame(fileName);

            Assert.IsNotEmpty(LoadGame.Players);
        }
    }
}
