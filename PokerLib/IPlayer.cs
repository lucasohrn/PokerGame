namespace Poker
{
    public interface IPlayer
    {
        string Name { get; }
        int Wins { get; }

        HandType HandType { get; }
        ICard[] Hand { get; }
        ICard[] Discard { set; }
    }
}