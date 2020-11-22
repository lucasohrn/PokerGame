using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Poker.Lib
{
    class Player : IPlayer
    {
        public string Name => name;
        private string name;

        public int Wins { get; set; }

        public Player(string playerName, int playerWins)
        {
            name = playerName;
            Wins = playerWins;
            hand = new Card[5];
        }

        public ICard[] Hand => hand;
        private Card[] hand;

        public HandType HandType => handType;
        private HandType handType;

        public Graveyard graveyard;

        public void BeforeShowHand()
        {
            SortCards();
            handType = GetHandType();
        }

        public void SortCards()
        {
            for (int i = 0; i < hand.Length; i++)
            {
                // Skapar variablen [kortKvar] som tilldelas värdet på antalet kort som INTE är färdigsorterade i handen
                int kortKvar = hand.Length - 1;

                for (int j = 0; j < kortKvar; j++)   // Loopar igenom alla kort som är kvar i handen
                {
                    int jämförRank = (int)hand[j].Rank - (int)hand[j + 1].Rank;
                    // Skapar variabeln [jämförKort] som tilldelas ett värde på avståndet mellan korten
                    if (jämförRank == 0)
                    {
                        int jämförSuit = (int)hand[j].Suite - (int)hand[j + 1].Suite;

                        if (jämförSuit > 0)
                        {
                            Card temporär = hand[j];
                            hand[j] = hand[j + 1];
                            hand[j + 1] = temporär;
                        }
                    }
                    else if (jämförRank > 0)  // OM [jämförKort] är större än 0 ska ett platsbyte ske mellan korten
                    {
                        Card temporär = hand[j];   // variabeln [temporär] tilldelas samma värde som hand[j]
                        hand[j] = hand[j + 1];      // hand[j] tilldelas samma värde som hand[j + 1]
                        hand[j + 1] = temporär;     // hand[j+1] tilldelas samma värde som [temporär]
                    }
                }
            }
        }

        HandType GetHandType()
        {
            bool allSameSuit = IsAllSameSuit(hand);
            bool straight = IsStraight(hand);

            if (straight && allSameSuit)
            {
                if ((int)hand[0].Rank == 10)
                {
                    return HandType.RoyalStraightFlush;
                }
                else
                    return HandType.StraightFlush;
            }

            List<int> sameCardSet1, sameCardSet2;
            FindSetsOfCardsWithSameValue(hand, out sameCardSet1, out sameCardSet2);

            if (sameCardSet1.Count == 4)
                return HandType.FourOfAKind;

            if (sameCardSet1.Count + sameCardSet2.Count == 5)
                return HandType.FullHouse;

            if (allSameSuit)
                return HandType.Flush;

            if (straight)
                return HandType.Straight;

            if (sameCardSet1.Count == 3)
                return HandType.ThreeOfAKind;

            if (sameCardSet1.Count + sameCardSet2.Count == 4)
                return HandType.TwoPairs;

            if (sameCardSet1.Count == 2)
                return HandType.Pair;

            return HandType.HighCard;
        }

        bool IsStraight(ICard[] hand)
        {
            int rankValue = (int)hand[0].Rank;
            for (int i = 0; i < 4; i++)
            {
                if (rankValue + 1 != (int)hand[i + 1].Rank)
                {
                    return false;
                }
                rankValue++;
            }
            return true;
        }

        bool IsAllSameSuit(ICard[] hand)
        {
            Suite suite = hand[0].Suite;
            for (int i = 1; i < hand.Length; i++)
            {
                if (suite != hand[i].Suite)
                {
                    return false;
                }
            }
            return true;
        }

        void FindSetsOfCardsWithSameValue(ICard[] pokerHand, out List<int> sameValueSet1, out List<int> sameValueSet2)
        {
            //Find sets of cards with the same value.
            int index = 0;
            sameValueSet1 = FindSetsOfCardsWithSameValue_Helper(pokerHand, ref index);
            sameValueSet2 = FindSetsOfCardsWithSameValue_Helper(pokerHand, ref index);
        }

        List<int> FindSetsOfCardsWithSameValue_Helper(ICard[] pokerHand, ref int index)
        {
            List<int> sameCardSet = new List<int>();
            for (; index < 4; index++)
            {
                int intCard = (int)pokerHand[index].Rank;
                int intNextCard = (int)pokerHand[index + 1].Rank;
                if (intCard == intNextCard)
                {
                    if (sameCardSet.Count == 0)
                        sameCardSet.Add(intCard);
                    sameCardSet.Add(intCard);
                }
                else if (sameCardSet.Count > 0)
                {
                    index++;
                    break;
                }
            }
            return sameCardSet;
        }

        public ICard[] Discard { set => HandAfterDiscard(value); }
        private ICard[] HandAfterDiscard(ICard[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                for (int j = 0; j < hand.Length; j++)
                {
                    if (value[i] == hand[j])
                    {
                        graveyard.graveYardCards.Add(hand[j]);
                        hand[j] = null;
                    }
                }
            }
            foreach (Card card in hand) // lägger till en kopia av handen som overwritas i slutet av ens tur till graveyarden
            {
                graveyard.graveYardCards.Add(card);
            }
            return hand;
        }
    }
}