using Poker;
using Poker.Lib;

namespace PokerLib
{
    interface IDeck
    {
        ICard DrawTopCard();

        void Shuffle();

        void ReturnCard(Player[] players);
    }
}