using Poker;
using Poker.Lib;

namespace PokerLib
{
    public interface IDeck
    {
        ICard DrawTopCard();

        void Shuffle();

        void ReturnCard(Player[] players);
    }
}