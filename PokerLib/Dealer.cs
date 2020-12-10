using System;
using System.Collections.Generic;
using PokerLib;

namespace Poker.Lib
{
    class Dealer
    {
        IDeck deck = new Deck();
        private Player[] players;
        Graveyard graveyard = new Graveyard();

        public Dealer(Player[] players)
        {
            this.players = players;

            foreach (Player player in players)
            {
                player.graveyard = graveyard;
            }
        }

        public Dealer(Deck deck)
        {
            this.deck = deck;
        }

        public void OnNewDeal()
        {
            Returncards();
            deck.Shuffle();
            FirstDeal(players); // la till players som argument
        }
        void Returncards()
        {
            deck.ReturnCard(players);

            graveyard.graveYardCards.Clear();
        }

        public List<Player> Declarewinner()
        {
            List<Player> winners = new List<Player>();

            int highestHand = (int)this.players[0].HandType;
            winners.Add(this.players[0]);

            for (int j = 1; j < players.Length; j++)
            {
                int handValue = (int)this.players[j].HandType - highestHand;
                if (handValue > 0)
                {
                    winners.Clear();
                    winners.Add(this.players[j]);
                    highestHand = (int)this.players[j].HandType;
                }
                else if (handValue == 0)
                {
                    winners.Add(this.players[j]);
                }
            }
            return winners;
        }

        public void FirstDeal(Player[] players) // La till players som parameter
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < players.Length; j++)
                {
                    players[j].Hand[i] = deck.DrawTopCard();
                }
            }
        }

        public ICard GiveNewCard()
        {
            return deck.DrawTopCard();
        }
    }
}