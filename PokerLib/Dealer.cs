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

        public Player[] Declarewinner()
        {
            Player[] winners = new Player[5];
            
               
                    int spelareKvar = players.Length - 1;
                    for (int j = 0; j < spelareKvar; j++)
                    {
                        int jämförHandType = (int)players[j].HandType - (int)players[j + 1].HandType;
                        if (jämförHandType > 0)
                        {
                            for (int k = 0; k < winners.Length; k++)
                            {
                                winners[k] = null;
                            }
                            winners[0] = players[j];
                        }
                        else if (jämförHandType == 0)
                        {
                            for (int l = 0; l < winners.Length; l++)
                            {
                                if (winners[l] == null)
                                {
                                    winners[l] = players[j];
                                    break;
                                }
                            }
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