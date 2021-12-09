using System;
using System.Collections.Generic;
using PokerLib;

namespace Poker.Lib
{
    public class Deck : IDeck
    {
        public List<Card> deck = new List<Card>(52);
        
        public Deck()
        {
            for (int i = 0; i < 13; i++)
            {
                Poker.Rank rankValue = (Poker.Rank)i + 2;

                for (int j = 0; j < 4; j++)
                {
                    Poker.Suite suiteValue = (Poker.Suite)j;
                    
                    deck.Add(new Card(suiteValue, rankValue));
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
            ICard firstCard = deck[0];
            deck.RemoveAt(0);
            return firstCard;
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
