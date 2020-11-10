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
            this.suite = suite;
            this.rank = rank;
        }
        
        public Suite Suite => suite;
        public Rank Rank => rank;
    }
}