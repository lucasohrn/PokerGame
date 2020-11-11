using System;
using System.Collections.Generic;

namespace Poker.Lib
{
    class Dealer : Graveyard
    {
        Deck deck = new Deck();
        private IPlayer[] players;
        Graveyard graveyard = new Graveyard();
        
        public Dealer(IPlayer[] players)
        {
            this.players = players;
        }

        public void OnNewDeal()
        {
            deck.Shuffle();
            FirstDeal();
        }

        public void FirstDeal()
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