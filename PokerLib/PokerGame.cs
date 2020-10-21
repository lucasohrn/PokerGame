using System;

namespace Poker.Lib
{
    public class Events : IPokerGame
    {
        object objectLock = new Object();        
        public IPlayer[] Players { get; }
        public void RunGame()
        {

        }

        public void Exit()
        {

        }

        public void SaveGameAndExit(string fileName)
        {

        }

        event OnNewDeal NewDeal;
        event OnNewDeal IPokerGame.NewDeal
        {
            add
            {
                lock (objectLock)
                {
                    NewDeal += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    NewDeal -= value;
                }
            }
        }

        event OnSelectCardsToDiscard SelectCardsToDiscard;
        event OnSelectCardsToDiscard IPokerGame.SelectCardsToDiscard
        {
            add
            {

            }
            remove
            {

            }
        }

        event OnRecievedReplacementCards RecievedReplacementCards;
        event OnRecievedReplacementCards IPokerGame.RecievedReplacementCards
        {
            add
            {

            }
            remove
            {

            }
        }

        event OnShowAllHands ShowAllHands;
        event OnShowAllHands IPokerGame.ShowAllHands
        {
            add
            {

            }
            remove
            {

            }
        }

        event OnWinner Winner;
        event OnWinner IPokerGame.Winner
        {
            add
            {

            }
            remove
            {

            }
        }

        event OnDraw Event;

        event OnDraw IPokerGame.Draw
        {
            add
            {
                
            }
            remove
            {

            }
        }
    }
}