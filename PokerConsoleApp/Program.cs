using System;
using System.IO;
using System.Text;

namespace Poker.ConsoleApp
{
    class Program
    {
        private static Lib.IPokerGame game;

        private static void OnNewDeal()
        {
            UserInterface.AnnounceNewDeal();
        }

        private static void OnSelectCardsToDiscard(IPlayer player)
        {
            player.Discard = UserInterface.SelectCardsToDiscard(player);
        }

        private static void OnRecievedReplacementCards(IPlayer player)
        {
            UserInterface.InspectReplacementCards(player);
        }

        private static void OnShowAllHands()
        {
            foreach(var player in game.Players)
            {
                UserInterface.ShowHand(player);
            }
        }

        private static void OnWinner(IPlayer player)
        {
            UserInterface.PresentWinner(player);
            PresentStats();
        }

        private static void OnDraw(IPlayer[] tiedPlayers)
        {
            UserInterface.DeclareDraw(tiedPlayers);
            PresentStats();
        }

        private static void PresentStats()
        {
            if (!UserInterface.PresentStats(game.Players))
            {
                if (Char.ToLower(
                        UserInterface.WaitForKey("Spara spelet? [J/N]").KeyChar) 
                    == 'j')
                {
                    game.SaveGame("savedgame.txt");
                    game.Exit();
                }
                else 
                {
                    game.Exit();
                }
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            game = (File.Exists("savedgame.txt") //kollar om sparat spel existerar
                && Char.ToLower(UserInterface.WaitForKey //kollar efter spelar-input
                ("Ladda sparat spel? [J/N]").KeyChar) == 'j') // om input lika med j ladda spel. om input = n starta ett nytt 
                ? Lib.GameFactory.LoadGame("savedgame.txt") // Kör sparat spel
                : Lib.GameFactory.NewGame(UserInterface.RegisterPlayers()); // Starta nytt spel  
            
            // Assignar lyssnare till alla event
            game.NewDeal += OnNewDeal; // Dela ut kort
            game.SelectCardsToDiscard += OnSelectCardsToDiscard; // Välj kort att kasta
            game.RecievedReplacementCards += OnRecievedReplacementCards; // Få nya/nytt kort
            game.ShowAllHands += OnShowAllHands; // Visa alla händer
            game.Winner += OnWinner; // Kora vinnaren
            game.Draw += OnDraw; // Spelarna kom lika

            game.RunGame();   
        }
    }
}
