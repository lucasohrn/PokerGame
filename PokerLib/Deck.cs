using System;
using System.Collections.Generic;

namespace Poker.Lib
{
    class Deck
    {
        List<ICard> deck;
        int numberOfCards;

        public Deck()
        {
            for (int i = 0; i < 13; i++)
            {
                var rankValue = (Rank)i + 2;

                for (int j = 0; j < 4; j++)
                {
                    var suiteValue = (Suite)i;
                    ICard kort = new Card(suiteValue, rankValue);
                    deck.Add(kort);
                }
            }
        }

        private static Random rng = new Random();

        public static void Shuffle<T>(List<ICard> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                ICard value = list[k];
                list[k] = list[n];
                list[n] = value;
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
