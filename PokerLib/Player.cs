using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    class Player : IPlayer
    {
        public string Name => name;
        private string name;

        public int Wins => wins;
        private int wins;

        public Player(string playerName, int playerWins)
        {
            name = playerName;
            wins = playerWins;
            hand = new ICard[5];
        }

        public ICard[] Hand => hand;
        private ICard[] hand;

        public HandType HandType => handType;
        private HandType handType;
        void RecieveCard(ICard card)
        {
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i] == null)
                {
                    hand[i] = card;
                    return;
                }
            }
        }

        void GetHandType()
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

        
        List<ICard[]> graveYardCards = new List<ICard[]>();

        public ICard[] Discard { set => graveYardCards.Add(value); }

    }
}