using System;
using System.Collections.Generic;
namespace Poker.Lib
{
    class Dealer
    {
        Deck deck = new Deck();
        private IPlayer[] players;

        public Dealer(IPlayer[] players)
        {
            this.players = players;
        }

        public void OnNewDeal()
        {
            //returncards
            //shuffle
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

        public void GiveNewCard()
        {
            deck.DrawTopCard();
        }
    }
}