using System;

namespace Poker
{
    class Player : IPlayer
    {
        private string name;
        private int wins;

        public Player(string playerName, int playerWins)
        {
            name = playerName;
            wins = playerWins;
        }

        private ICard[] hand;
    
        private HandType handType;
        public HandType HandType => handType;
        
        public string Name => name;

        public ICard[] Hand => hand;


        public int Wins => wins;

        public ICard[] Discard { set => throw new NotImplementedException(); }
    }
}