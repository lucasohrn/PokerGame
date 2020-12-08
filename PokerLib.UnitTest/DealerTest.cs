using NUnit.Framework;
using Poker.Lib;
using static Poker.Suite;
using static Poker.Rank;
using Poker;
using System.Linq;
using System.Test.RegularExpressions;

namespace PokerLib.UnitTest
{
    [TestFixture]
    public class DealerTest
    {
        [Test]
        public void DealerCanDeal()
        {
            Dealer dealer = new Dealer(new Deck());

            Player[] players = new Player[]
            {
                new Player("Lucas", 0);
                new Player("Oliver", 0);
            };

            dealer.Deal(players);

            Assert.AreEqual(players[0].Hand.Count(), 5, players[0].Name);
            Assert.AreEqual(players[1].Hand.Count(), 5, players[1].Name);



        }
    }
}