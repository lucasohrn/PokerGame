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
        
        void OnNewDeal()
        {
            //returncards
            //shuffle
            //Deck.Shuffle(deck.deck);   
            DealCards();
        }

        public void DealCards()
        {
            foreach (IPlayer player in players)
            {
                for (int i = 0; i < 5; i++)
                {
                  player.Hand[i] = deck.DrawTopCard();
                }
            }
        }

        public void GiveNewCard()
        {
            deck.DrawTopCard();
        }
    }
}