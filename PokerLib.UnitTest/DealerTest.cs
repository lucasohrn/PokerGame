using NUnit.Framework;
using Poker.Lib;
using static Poker.Suite;
using static Poker.Rank;
using Poker;
using System.Linq;
using System.Text.RegularExpressions;

namespace PokerLib.UnitTest
{
    [TestFixture]
    public class DealerTest
    {
        class MockDeck : IDeck
        {
            
            public bool DealerShuffledTheDeck { get; private set; }
            public MockDeck(int numberOfPlayers, string[] hands)
            {

            }

            public ICard DrawTopCard()
            {
                return null;
            }

            public void ReturnCard(Player[] players)
            {
                throw new System.NotImplementedException();
            }

            public void Shuffle()
            {
                DealerShuffledTheDeck = true;
            }
        }

        [Test]
        public void DealerCanDeal()
        {
            Dealer dealer = new Dealer(new Deck());

            ICard[] testHand1 = new Card[]
            {
                new Card(Clubs, Two),
                new Card(Hearts, Two),
                new Card(Clubs, Three),
                new Card(Hearts, Three),
                new Card(Clubs, Four)
            };

            ICard[] testHand2 = new Card[]
            {
                new Card(Diamonds, Two),
                new Card(Spades, Two),
                new Card(Diamonds, Three),
                new Card(Spades, Three),
                new Card(Diamonds, Four)
            };

            Player[] players = new Player[]
            {
                new Player("Lucas", 0),
                new Player("Oliver", 0)
            };

            dealer.FirstDeal(players);

            Assert.AreEqual(players[0].Hand.Count(), 5);
            Assert.AreEqual(players[1].Hand.Count(), 5);

            CollectionAssert.AreEqual(players[0].Hand, testHand1);
            CollectionAssert.AreEqual(players[1].Hand, testHand2);
        }

    }
}