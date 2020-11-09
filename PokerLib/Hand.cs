using System;
using System.Linq;

namespace Poker.Lib
{
    class Hand
    {
        ICard[] hand;

        private HandType GetHandType()
        {
            throw new NotImplementedException();
        }

        void SortCards() // inte testad ska kunna sortera men stor möjlighet att den sorterar fel, jag kan inte linq
        {
            var sorted = hand.GroupBy(x => x.Suite).Select(x => new
            {
                Cards = x.OrderByDescending(c => c.Rank),
                Count = x.Count(),
            }
            ).OrderByDescending(x => x.Count).SelectMany(x => x.Cards);
        }

        void DiscardCards(Graveyard graveyard)
        {

        }

        void RecieveCard(Card card)
        {

        }
    }
}