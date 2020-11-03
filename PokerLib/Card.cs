using System;
using System.IO;

namespace Poker.Lib
{
    public class Card : ICard
    {
        private Suite suite;
        private Rank rank;
        public Card(Suite suite, Rank rank)
        {
            suite = this.suite;
            rank = this.rank;
        }
        
        public Suite Suite => suite;
        public Rank Rank => rank;
    }
}