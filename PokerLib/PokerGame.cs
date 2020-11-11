using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Poker.Lib
{
    public class PokerGame : IPokerGame
    {
        private IPlayer[] players;
        public IPlayer[] Players => players;

        public PokerGame(string[] players) //skapar ett nytt spelar object för varje namn angivet
        {
            this.players = new IPlayer[players.Length];
            for (int i = 0; i < players.Length; i++)
            {
                this.players[i] = new Player(players[i], 0);
            }
        }

        public PokerGame(string fileName) //laddar ett gammalt spel
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                List<IPlayer> players = JsonConvert.DeserializeObject<List<IPlayer>>(json);
                this.players = new IPlayer[players.Count];
                this.players = players.ToArray();
            }
            else
            {
                Console.Write($"The file \"{fileName}\" does not exist");
                //implomentera så man kan testa en annan fil eller starta nytt spel
            }
        }

        public event OnNewDeal NewDeal;
        public event OnSelectCardsToDiscard SelectCardsToDiscard;
        public event OnRecievedReplacementCards RecievedReplacementCards;
        public event OnShowAllHands ShowAllHands;
        public event OnWinner Winner;
        public event OnDraw Draw;

        private Dealer dealer;
        private bool gameIsOver = false;
        public void RunGame()
        {
            dealer = new Dealer(players);
            while (!gameIsOver)
            {
                if (NewDeal != null)
                    NewDeal();

                dealer.OnNewDeal();
                for (int i = 0; i < Players.Length; i++)
                {
                    if (SelectCardsToDiscard != null)
                        SelectCardsToDiscard(Players[i]);

                    for (int j = 0; j < 5; j++)
                    {
                        if (Players[i].Hand[j] == null)
                            Players[i].Hand[j] = dealer.GiveNewCard();
                    }
                    if (RecievedReplacementCards != null)
                        RecievedReplacementCards(Players[i]);
                }

                if (ShowAllHands != null)
                {
                    ShowAllHands();
                }

                gameIsOver = true;
            }
        }
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
                        string fileName = Console.ReadLine().ToLower();

                        if (fileName != null)
                        {
                            SaveGameAndExit(fileName);
                        }
                    }
                }
                else if (input == "n")
                {
                    Environment.Exit(0);
                }
            }
        }
        public void SaveGameAndExit(string fileName)
        {
            string json = JsonConvert.SerializeObject(players);
            File.WriteAllText(fileName, json);
            Environment.Exit(0);
        }
    }
}