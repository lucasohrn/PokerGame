using System;

namespace Poker.Lib
{
    public class PokerGame : IPokerGame
    {
        public PokerGame(string[] players)
        {

        }



        public IPlayer[] Players => throw new NotImplementedException();

        public event OnNewDeal NewDeal;
        public event OnSelectCardsToDiscard SelectCardsToDiscard;
        public event OnRecievedReplacementCards RecievedReplacementCards;
        public event OnShowAllHands ShowAllHands;
        public event OnWinner Winner;
        public event OnDraw Draw;

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void RunGame()
        {
            throw new NotImplementedException();
        }

        public void SaveGameAndExit(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}