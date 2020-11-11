using System;
using System.Collections.Generic;
namespace Poker.Lib
{
    class Dealer
    {
        Deck deck = new Deck();
        private IPlayer[] players;
<<<<<<< HEAD
        private Player player;
        Graveyard graveyard = new Graveyard();
=======
>>>>>>> 3e0e54afd828fd8b5889103be46687163e7af2a3

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