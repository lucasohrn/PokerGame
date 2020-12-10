using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("PokerLib.UnitTest")]

namespace Poker.Lib
{
    public class PokerGame : IPokerGame
    {
        private Player[] players;
        public IPlayer[] Players => players;

        public PokerGame(string[] players) //skapar ett nytt spelar object för varje namn angivet
        {
            this.players = new Player[players.Length];
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
                string[] data = json.Split(' ');
                string[] names = JsonConvert.DeserializeObject<String[]>(data[0]);
                int[] wins = JsonConvert.DeserializeObject<int[]>(data[1]);

                this.players = new Player[names.Length];
                for (int i = 0; i < names.Length; i++)
                {
                    this.players[i] = new Player(names[i], wins[i]);
                }
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
                    players[i].SortCards();

                    if (SelectCardsToDiscard != null)
                        SelectCardsToDiscard(Players[i]);

                    for (int j = 0; j < 5; j++)
                    {
                        if (Players[i].Hand[j] == null)
                            Players[i].Hand[j] = dealer.GiveNewCard();
                    }
                    players[i].BeforeShowHand();

                    if (RecievedReplacementCards != null)
                        RecievedReplacementCards(Players[i]);
                }

                if (ShowAllHands != null)
                {
                    ShowAllHands();
                }

                List<Player> winners = dealer.Declarewinner();
                if (winners.Count == 1)
                {
                    if (Winner != null)
                    {
                        winners[0].Wins += 1;
                        Winner(winners[0]);
                    }
                }
                else
                {
                    if (Draw != null)
                    {
                        Draw(winners.ToArray());
                    }
                }
            }
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
        public void SaveGame(string fileName)
        {
            string[] names;
            int[] wins;

            names = new string[players.Length];
            wins = new int[players.Length];

            for (int i = 0; i < players.Length; i++)
            {
                names[i] = players[i].Name;
                wins[i] = players[i].Wins;
            }

            string json = JsonConvert.SerializeObject(names);
            json += (" " + JsonConvert.SerializeObject(wins));
            File.WriteAllText(fileName, json);
            Console.WriteLine("Spelet har sparats");
        }
    }
}