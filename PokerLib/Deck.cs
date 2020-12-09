using System;
using System.Collections.Generic;
using PokerLib;

namespace Poker.Lib
{
    class Deck : IDeck
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

            Console.WriteLine("Deck is empty"); // Kasta exeption ej korrekt
            throw new Exception();
        }
        public void ReturnCard(Player[] players)
        {
            for (int i = 0; i < players.Length; i++)
            {
                for (int j = 0; j < players[i].graveyard.graveYardCards.Count; j++)
                {
                    deck.Add(players[i].graveyard.graveYardCards[j]);
                }
                players[i].graveyard.graveYardCards.Clear();
            }
        }
    }
}
