using System;
using System.Collections.Generic;
namespace Poker.Lib
{
    class Dealer
    {
        Deck deck = new Deck();
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

        public void OnNewDeal()
        {
            Returncards();
            deck.Shuffle();
            FirstDeal();
        }
        void Returncards()
        {
            foreach (Card card in graveyard.graveYardCards)
            {
                Card drawnCard = graveyard.graveYardCards[0];
                graveyard.graveYardCards.RemoveAt(0);
                // return drawnCard;
            }
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