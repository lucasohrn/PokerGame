using System;

namespace Poker.Lib
{
    public class PokerGame : IPokerGame
    {
        public PokerGame(string[] players)
        {

        }

        public IPlayer[] Players => throw new NotImplementedException();

        public event OnNewDeal NewDeal;
        public event OnSelectCardsToDiscard SelectCardsToDiscard;
        public event OnRecievedReplacementCards RecievedReplacementCards;
        public event OnShowAllHands ShowAllHands;
        public event OnWinner Winner;
        public event OnDraw Draw;

        public void Exit()
        {
            while (true)
            {
                Console.WriteLine("Vill du spara spelet? J/N");
                string input = Console.ReadLine().ToLower();

                if (input == "j")
                {
                    while (true)
                    {
                        Console.WriteLine("Vad ska din sparfil heta?");
                        string input2 = Console.ReadLine().ToLower();

                        if (input2 != null)
                        {
                            SaveGameAndExit(input2);
                        }
                    }
                }
                else if (input == "n")
                {
                    Environment.Exit(0);
                }
            }
        }

        public void RunGame()
        {
            throw new NotImplementedException();
        }

        public void SaveGameAndExit(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}