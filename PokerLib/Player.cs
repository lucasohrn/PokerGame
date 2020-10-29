using System;

namespace Poker
{
    class Player : IPlayer
    {
        public string Name => throw new NotImplementedException();

        public ICard[] Hand => throw new NotImplementedException();

        public HandType HandType => throw new NotImplementedException();

        public int Wins => throw new NotImplementedException();

        public ICard[] Discard { set => throw new NotImplementedException(); }
    }
}