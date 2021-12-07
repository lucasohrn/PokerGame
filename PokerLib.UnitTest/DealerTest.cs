using NUnit.Framework;
using Poker.Lib;
using static Poker.Suite;
using static Poker.Rank;
using Poker;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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

            Player[] dummyPlayers = new Player[]
            {
                new Player("testPlayer1", 0),
                new Player("testPlayer2", 0)
            };

            dummyPlayers[0].Hand[0] = new Card(Clubs, Two);
            dummyPlayers[0].Hand[1] = new Card(Hearts, Two);
            dummyPlayers[0].Hand[2] = new Card(Clubs, Three);
            dummyPlayers[0].Hand[3] = new Card(Hearts, Three);
            dummyPlayers[0].Hand[4] = new Card(Clubs, Four);

            dummyPlayers[1].Hand[0] = new Card(Diamonds, Two);
            dummyPlayers[1].Hand[1] = new Card(Spades, Two);
            dummyPlayers[1].Hand[2] = new Card(Diamonds, Three);
            dummyPlayers[1].Hand[3] = new Card(Spades, Three);
            dummyPlayers[1].Hand[4] = new Card(Diamonds, Four);

            Player[] players = new Player[]
            {
                new Player("Lucas", 0),
                new Player("Sixten", 0)
            };

            dealer.FirstDeal(players);

            Assert.AreEqual(players[0].Hand.Count(), 5);
            Assert.AreEqual(players[1].Hand.Count(), 5);

            for (int i = 0; i < players.Length; i++)
            {
				for (int j = 0; j < 5; j++)
				{
                    Assert.AreEqual(players[i].Hand[j].Rank, dummyPlayers[i].Hand[j].Rank);
                    Assert.AreEqual(players[i].Hand[j].Suite, dummyPlayers[i].Hand[j].Suite);
                }
                    
            }
        }

        [Test]
        public void DealerCanShuffle()
        {
            Deck shuffledDeck = new Deck();
            Deck unShuffleddeck = new Deck();

            shuffledDeck.Shuffle();

            for (int i = 0; i < shuffledDeck.deck.Count; i++)
            {
                Assert.AreEqual(shuffledDeck.deck[i], unShuffleddeck.deck[i].Rank);
			}

        }

        [Test]
        public void DeckHaveRightAmountOfCardsAfterShuffled()
        {
            //Arrange
            Deck deck = new Deck();
            deck.Shuffle();
            //Act 
            var expectedAmount = 52;
            //Assert
            Assert.AreEqual(expectedAmount, deck.deck.Count);
        }

        [Test]
        public void DeckAmountDecreaseByOneWhenDrawCard()
        {
            //Arrange
            Deck deck = new Deck();
            //Act
            deck.DrawTopCard();
            //Assert
            Assert.AreEqual(51, deck.deck.Count);
        }
    }
}