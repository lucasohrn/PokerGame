using NUnit.Framework;
using Poker.Lib;
using static Poker.Suite;
using static Poker.Rank;
using Poker;
using System.Linq;

namespace PokerLib.UnitTest
{
    public class GameTest
    {
        [SetUp]
        public void Setup()
        { }

        [Test, Combinatorial]
        public void CanEvaluateRoyalStraightFlush([Values(0, 1, 2, 3)] int suite)
        {
            //A royal straight flush is a hand that contains five cards of sequential rank, all of the same suit, valued 10 or greater 
            Player player = new Poker.Lib.Player("", 1);

            for (int i = 0; i < 5; ++i)
            {
                player.Hand[i] = new Card((Suite)suite, (Rank)10 + i);
            }
            player.graveyard = new Graveyard(); //kommer returna en error om spelaren inte har en graveyard;
            player.BeforeShowHand();
            Assert.IsTrue(player.HandType == Poker.HandType.RoyalStraightFlush);
        }

        [Test, Combinatorial]
        public void CanEvaluateStraightFlush([Values(0, 1, 2, 3)] int suite, [Values(2, 3, 4, 5, 6, 7, 8, 9)] int rank)
        {
            //A royal straight flush is a hand that contains five cards of sequential rank, all of the same suit
            Player player = new Poker.Lib.Player("", 1);

            for (int i = 0; i < 5; ++i)
            {
                player.Hand[i] = new Card((Suite)suite, (Rank)(i + rank));
            }
            player.graveyard = new Graveyard(); //kommer returna en error om spelaren inte har en graveyard;
            player.BeforeShowHand();
            Assert.IsTrue(player.HandType == Poker.HandType.StraightFlush);
        }

        [Test, Combinatorial]
        public void CanEvaluateFourOfAKind([Values(0, 1, 2, 3, 4)] int irellevantCard,
        [Values(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)] int rank)
        {
            Player player = new Poker.Lib.Player("", 1);

            for (int i = 0; i < 5; ++i)
            {
                if (i == irellevantCard)
                {
                    if (rank == 2)
                    {
                        player.Hand[i] = new Card((Suite)0, (Rank)(rank + 1));
                    }
                    else
                    {
                        player.Hand[i] = new Card((Suite)0, (Rank)(rank - 1));
                    }

                    continue;
                }

                player.Hand[i] = new Card((Suite)0, (Rank)(rank));
            }

            player.graveyard = new Graveyard(); //kommer returna en error om spelaren inte har en graveyard;
            player.BeforeShowHand();
            Assert.IsTrue(player.HandType == Poker.HandType.FourOfAKind);
        }

        [Test, Combinatorial]
        public void CanEvaluateFullhouse([Values(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)] int firstRank,
        [Values(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)] int secondRank)
        {
            Player player = new Player("", 1);

            for (int i = 0; i < 5; ++i)
            {
                Assume.That(firstRank != secondRank);

                if (i < 3)
                {
                    player.Hand[i] = new Card((Suite)0, (Rank)(firstRank));
                }
                else
                {
                    player.Hand[i] = new Card((Suite)0, (Rank)(secondRank));
                }
            }
            player.graveyard = new Graveyard(); //kommer returna en error om spelaren inte har en graveyard;
            player.BeforeShowHand();
            Assert.IsTrue(player.HandType == Poker.HandType.FullHouse);
        }

        [Test]
        public void CanEvaluateFlush([Values(0, 1, 2, 3)] int suite) 
        {
            //A flush is a hand that contains five cards all of the same suit
            Player player = new Poker.Lib.Player("", 1);

            Card[] cards = new Card[5] { new Card((Suite)suite, Rank.Two), new Card((Suite)suite, Rank.Four),
            new Card((Suite)suite, Rank.Six), new Card((Suite)suite, Rank.Eight), new Card((Suite)suite, Rank.Ace) };

            for (int i = 0; i < 5; i++)
            {
                player.Hand[i] = cards[i];
            }

            player.graveyard = new Graveyard(); //kommer returna en error om spelaren inte har en graveyard;
            player.BeforeShowHand();
            Assert.IsTrue(player.HandType == Poker.HandType.Flush);
        }

        [Test, Combinatorial]
        public void CanEvaluateTwoPairs([Values(2, 3, 4)] int irellevantCard, [Values(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)] int firstRank,
        [Values(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)] int secondRank)
        {
            Card[] cards = new Card[5];
            Player player = new Poker.Lib.Player("", 1);

            for (int i = 0; i < 5; ++i)
            {
                Assume.That(firstRank != secondRank);

                if (i == 0 || i == 1)
                {
                    cards[i] = new Card((Suite)0, (Rank)(firstRank));
                }
                else if (i == 2 || i == 3)
                {
                    cards[i] = new Card((Suite)1, (Rank)(secondRank));
                }
                else
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (irellevantCard != firstRank && irellevantCard != secondRank)
                        {
                            cards[i] = new Card((Suite)1, (Rank)(irellevantCard));
                            break;
                        }
                        irellevantCard++;
                    }
                }
                player.Hand[i] = cards[i];
            }
            player.graveyard = new Graveyard(); //kommer returna en error om spelaren inte har en graveyard;
            player.BeforeShowHand();
            Assert.IsTrue(player.HandType == Poker.HandType.TwoPairs);
        }
        
        [Test, Combinatorial]
        public void CanEvaluateStraight([Values(2, 3, 4, 5, 6, 7, 8, 9)] int rank, [Values(0, 1, 2, 3, 4)] int oddColor)
        {
            //A straight is a hand that contains five cards of sequential rank
            Player player = new Poker.Lib.Player("", 1);

            for (int i = 0; i < 5; ++i)
            {
                if (i == oddColor)
                {
                    player.Hand[i] = new Card((Suite)1, (Rank)(i + rank));
                    continue;
                }

                player.Hand[i] = new Card((Suite)0, (Rank)(i + rank));
            }

            player.graveyard = new Graveyard(); //kommer returna en error om spelaren inte har en graveyard;
            player.BeforeShowHand();
            Assert.IsTrue(player.HandType == Poker.HandType.Straight);
        }

        [Test, Combinatorial]
        public void CanEvaluateThreeOfAKind([Values(0, 1, 2, 3, 4)] int irellevantCard, [Values(0, 1, 2, 3, 4)] int irellevantCard2,
        [Values(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)] int rank)
        {
            Assume.That(irellevantCard != irellevantCard2);

            Player player = new Poker.Lib.Player("", 1);

            for (int i = 0; i < 5; ++i)
            {
                if (i == irellevantCard)
                {
                    if (rank == 2)
                    {
                        player.Hand[i] = new Card((Suite)2, (Rank)(rank + 4));
                    }
                    else
                    {
                        player.Hand[i] = new Card((Suite)1, (Rank)(rank - 1));
                    }
                    continue;
                }

                else if (i == irellevantCard2)
                {
                    if (rank == 2)
                    {
                        player.Hand[i] = new Card((Suite)2, (Rank)(rank + 5));
                    }
                    else if (rank == 3)
                    {
                        player.Hand[i] = new Card((Suite)1, (Rank)(rank + 3));
                    }
                    else
                    {
                        player.Hand[i] = new Card((Suite)1, (Rank)(rank - 2));
                    }
                    continue;
                }

                player.Hand[i] = new Card((Suite)0, (Rank)(rank));
            }

            player.graveyard = new Graveyard(); //kommer returna en error om spelaren inte har en graveyard;
            player.BeforeShowHand();
            Assert.IsTrue(player.HandType == Poker.HandType.ThreeOfAKind);
        }

        [Test, Combinatorial]
        public void CanEvaluateTwoPair([Values(0, 1, 2, 3, 4)] int irellevantCard, [Values(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)] int irellevantCardRank,
        [Values(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)] int rank, [Values(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)] int rank2)
        {
            Assume.That(rank != rank2);
            Assume.That(irellevantCardRank != rank);
            Assume.That(irellevantCardRank != rank2);

            Player player = new Poker.Lib.Player("", 1);

            int counter = 0;
            for (int i = 0; i < 5; ++i)
            {
                if (i == irellevantCard)
                {
                    player.Hand[i] = new Card((Suite)1, (Rank)(irellevantCardRank));
                    continue;
                }

                if (counter < 2)
                {
                    player.Hand[i] = new Card((Suite)0, (Rank)(rank));
                    counter++;
                }
                else
                {
                    player.Hand[i] = new Card((Suite)0, (Rank)(rank2));
                }
            }

            player.graveyard = new Graveyard(); //kommer returna en error om spelaren inte har en graveyard;
            player.BeforeShowHand();
            Assert.IsTrue(player.HandType == Poker.HandType.TwoPairs);
        }

        [Test, Combinatorial]
        public void CanEvaluatePair([Values(0, 1, 2, 3, 4)] int rellevantCard1, [Values(0, 1, 2, 3, 4)] int rellevantCard2,
        [Values(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)] int rank)
        {
            Assume.That(rellevantCard1 != rellevantCard2);
            Player player = new Poker.Lib.Player("", 1);

            for (int i = 0; i < 5; i++)
            {
                if (i == rellevantCard1 || i == rellevantCard2)
                {
                    player.Hand[i] = new Card((Suite)0, (Rank)rank);
                    continue;
                }

                //fyller resten av handem med kort som inte skapar några andra handtyper
                player.Hand[i] = generateCard(rank);
            }

            player.graveyard = new Graveyard(); //kommer returna en error om spelaren inte har en graveyard;
            player.BeforeShowHand();
            Assert.IsTrue(player.HandType == Poker.HandType.Pair);
        }

        private int counter;
        [Test, Combinatorial]
        private Card generateCard(int rank)
        {

            for (int j = counter; j < 1000; j++)
            {
                if (rank != 14 - j)
                {
                    counter++;
                    return new Card((Suite)1, (Rank)(14 - j));
                }

                else if (rank != 2 + j)
                {
                    counter++;
                    return new Card((Suite)3, (Rank)2 + j);
                }
            }

            throw new System.Exception();
        }

        [Test, Combinatorial]
        public void CanEvaluateHighCard()
        {
            Player player = new Poker.Lib.Player("", 1);
            Card[] cards = new Card[] { new Card(Suite.Spades, Rank.Ace), new Card(Suite.Clubs, Rank.Two),
            new Card(Suite.Diamonds, Rank.King), new Card(Suite.Hearts, Rank.Four), new Card(Suite.Clubs, Rank.Ten)};

            for (int i = 0; i < 5; i++)
            {
                player.Hand[i] = cards[i];
            }

            player.graveyard = new Graveyard(); //kommer returna en error om spelaren inte har en graveyard;
            player.BeforeShowHand();
            Assert.IsTrue(player.HandType == Poker.HandType.HighCard);
        }
    }
}