using System;

namespace Poker.Lib
{
    class Dealer
    {
        Deck deck = new Deck();
        public Hand[] playerHands;

        public Dealer(IPlayer[] players)
        {
           
        }
        void OnNewDeal()
        {
            DealCards();
        }

        public void DealCards()
        {
            
            for (int i = 0; i < 1; i++)
            {
                deck.DrawTopCard();
            }
            // Dela ut kort
        }

        public void GiveNewCard()
        {
            deck.DrawTopCard();
        }
    }
}