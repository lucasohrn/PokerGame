using System;
using System.IO;

namespace Poker.Lib
{
    public class Card : ICard
    {
        public Suite Suite { get; set; }
        public Rank Rank { get; set; }
        public Card(Suite suite, Rank rank)
        {
            this.Suite = suite;
            this.Rank = rank;
        }
    }
}