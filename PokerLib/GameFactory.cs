using System;
using System.Collections.Generic;

namespace Poker.Lib
{
    public static class GameFactory
    {
        public static IPokerGame NewGame(string[] playerNames)
        {
            var pokergame = new PokerGame(playerNames);
            Console.WriteLine(playerNames[0] + playerNames[1]);
            
            List<Card> deck = new List<Card>();
            
            Console.WriteLine(deck.Count);
            return pokergame;
        }

        public static IPokerGame LoadGame(string fileName)
        {
            return null;
        }
    }
}