using System;
using System.Collections.Generic;

namespace Poker
{
    class Deck
    {
        List<Card> deck;

        public Deck()
        {
            for (int i = 0; i < 13; i++)
            {
                var rankValue = (Rank)i + 2;

                for (int j = 0; j < 4; j++)
                {
                    var suiteValue = (Suite)i;
                    Card kort = new Card(suiteValue, rankValue);
                    deck.Add(kort);
                }
            }
        }

        int numberOfCards;

        private static Random rng = new Random();

        public static void Shuffle<T>(List<Card> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public Card DrawTopCard()
        {
            if (deck != null || deck.Count != 0)
            {
                Card firstCard = deck[0];
                deck.RemoveAt(0);
                return firstCard;
            }

            throw new Exception();
        }
        public void ReturnCard(Card graveyardCards)
        {
            throw new NotImplementedException();
        }
    }
}
