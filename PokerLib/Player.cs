using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Lib
{
    class Player : IPlayer
    {
        public string Name => name;
        private string name;

        public int Wins => wins;
        private int wins;

        public Player(string playerName, int playerWins)
        {
            name = playerName;
            wins = playerWins;
            hand = new ICard[5];
        }

        public ICard[] Hand => hand;
        private ICard[] hand;

        public HandType HandType => handType;
        private HandType handType;

        bool IsStraight(ICard[] hand)
        {
            for (int i = 0; i < 4; i++)
            {
                if (hand[i].Rank == hand[i + 1].Rank)
                {
                    return true;
                }
            }
            return false;
        }

        public bool SortCards() // inte testad ska kunna sortera men stor möjlighet att den sorterar fel, jag kan inte linq
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

        List<int> FindSetsOfCardsWithSameValue_Helper(ICard[] pokerHand_ArrangedCorrectly, ref int index)
        {
            List<int> sameCardSet = new List<int>();
            for (; index < 4; index++)
            {
                int currentCard_intValue = (int)pokerHand_ArrangedCorrectly[index].Rank;
                int nextCard_intValue = (int)pokerHand_ArrangedCorrectly[index + 1].Rank;
                if (currentCard_intValue == nextCard_intValue)
                {
                    if (sameCardSet.Count == 0)
                        sameCardSet.Add(currentCard_intValue);
                    sameCardSet.Add(currentCard_intValue);
                }
                else if (sameCardSet.Count > 0)
                {
                    index++;
                    break;
                }
            }
            return sameCardSet;
        }
        private ICard[] HandAfterDiscard(ICard[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                for (int j = 0; j < hand.Length; j++)
                {
                    if (value[i] == hand[j])
                    {
                        hand[j] = null;
                    }
                }
            }
            return hand;
        }

        public ICard[] Discard { set => HandAfterDiscard(value); }
    }
}