using System;
using System.Collections.Generic;

namespace Poker.Lib
{
    class Deck
    {
        List<Card> deck = new List<Card>(52);

        public Deck()
        {
            for (int i = 0; i < 13; i++)
            {
                Rank rankValue = (Rank)i + 2;

                for (int j = 0; j < 4; j++)
                {
                    Suite suiteValue = (Suite)j;
                    Card kort = new Card(suiteValue, rankValue);
                    deck.Add(kort);
                }
            }
        }

        private static Random rng = new Random();

        public void Shuffle()
        {
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }

        public ICard DrawTopCard()
        {
            if (deck != null || deck.Count != 0)
            {
                ICard firstCard = deck[0];
                deck.RemoveAt(0);
                return firstCard;
            }

            Console.WriteLine("Deck is empty");
            throw new Exception();
        }
        public void ReturnCard(ICard graveyardCards)
        {
            throw new NotImplementedException();
        }
    }
}
