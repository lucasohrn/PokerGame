using System;

namespace Poker.Lib
{
    class Dealer
    {
        public event EventHandler Events;

        Deck deck = new Deck();

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