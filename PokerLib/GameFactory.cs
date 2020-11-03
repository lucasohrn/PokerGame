namespace Poker.Lib
{
    public static class GameFactory
    {
        public static IPokerGame NewGame(string[] playerNames)
        { 
            IPokerGame pokergame = new PokerGame(playerNames);
            return pokergame;
        }

        public static IPokerGame LoadGame(string fileName)
        {
            return null;
        }
    }
}