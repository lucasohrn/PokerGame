using NUnit.Framework;
using Poker.Lib;
using static Poker.Suite;
using static Poker.Rank;
using Poker;
using System.Linq;

namespace PokerLib.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, Combinatorial]
        public void CanEvaluateRoyalStraightFlush([Values(0, 1, 2, 3)] int suite)
        {
            //A royal straight flush is a hand that contains five cards of sequential rank, all of the same suit, valued 10 or greater 
            Card[] cards = new Card[] { new Card((Suite)suite, Ten), new Card((Suite)suite, Jack),
            new Card((Suite)suite, Queen), new Card((Suite)suite, King), new Card((Suite)suite, Ace) };

            Player player = new Poker.Lib.Player("", 1);

            for (int i = 0; i < 5; ++i)
            {
                player.Hand[i] = cards[i];
            }
            player.graveyard = new Graveyard(); //kommer returna en error om spelaren inte har en graveyard;
            player.BeforeShowHand();
            Assert.IsTrue(player.HandType == Poker.HandType.RoyalStraightFlush);
        }

        [Test, Combinatorial]
        public void CanEvaluateStraightFlush([Values(0, 1, 2, 3)] int suite, [Values(2, 3, 4, 5, 6, 7, 8, 9)] int rank)
        {
            //A royal straight flush is a hand that contains five cards of sequential rank, all of the same suit
            Card[] cards = new Card[5];
            Player player = new Poker.Lib.Player("", 1);

            for (int i = 0; i < 5; ++i)
            {
                cards[i] = new Card((Suite)suite, (Rank)(i + rank));
                player.Hand[i] = cards[i];
            }
            player.graveyard = new Graveyard(); //kommer returna en error om spelaren inte har en graveyard;
            player.BeforeShowHand();
            Assert.IsTrue(player.HandType == Poker.HandType.StraightFlush);
        }

        [Test, Combinatorial]
        public void CanEvaluateFourOfAKind([Values(0, 1, 2, 3, 4)] int irellevantCard,
        [Values(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)] int rank)
        {
            Card[] cards = new Card[5];
            Player player = new Poker.Lib.Player("", 1);

            for (int i = 0; i < 5; ++i)
            {
                if (i == irellevantCard)
                {
                    if (rank == 2)
                    {
                        cards[i] = new Card((Suite)0, (Rank)(rank + 1));
                    }
                    else
                    {
                        cards[i] = new Card((Suite)0, (Rank)(rank - 1));
                    }
                    player.Hand[i] = cards[i];
                    continue;
                }

                cards[i] = new Card((Suite)0, (Rank)(rank));
                player.Hand[i] = cards[i];
            }

            player.graveyard = new Graveyard(); //kommer returna en error om spelaren inte har en graveyard;
            player.BeforeShowHand();
            Assert.IsTrue(player.HandType == Poker.HandType.FourOfAKind);
        }

        [Test, Combinatorial]
        public void CanEvaluateFullhouse([Values(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)] int firstRank,
        [Values(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)] int secondRank)
        {
            Card[] cards = new Card[5];
            Player player = new Poker.Lib.Player("", 1);

            for (int i = 0; i < 5; ++i)
            {
                Assume.That(firstRank != secondRank);

                if (i < 3)
                {
                    cards[i] = new Card((Suite)0, (Rank)(firstRank));
                }
                else
                {
                    cards[i] = new Card((Suite)0, (Rank)(secondRank));
                }
                player.Hand[i] = cards[i];
            }
            player.graveyard = new Graveyard(); //kommer returna en error om spelaren inte har en graveyard;
            player.BeforeShowHand();
            Assert.IsTrue(player.HandType == Poker.HandType.FullHouse);
        }
    }
}