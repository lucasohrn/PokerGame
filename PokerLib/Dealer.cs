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
                Card cardToReturn = graveyard.graveYardCards[0];
                graveyard.graveYardCards.RemoveAt(0);
                deck.ReturnCard(cardToReturn);
            }
        }

        public List<Player> Declarewinner()
        {
            List<Player> winners = new List<Player>();
            int players = this.players.Length - 1;
            int highestHand = 0;
            highestHand = (int)this.players[0].HandType;
            for (int j = 0; j < players; j++)
            {
                int handValue = highestHand - (int)this.players[j + 1].HandType;
                if (handValue > 0)
                {
                    winners.Clear();
                    winners.Add(this.players[j]);
                }
                else if (handValue == 0)
                {
                    winners.Add(this.players[j]);
                }
            }
            return winners;
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