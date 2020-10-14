using System;

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
        }

        private static void OnDraw(IPlayer[] tiedPlayers)
        {
            UserInterface.DeclareDraw(tiedPlayers);
        }

        static void Main(string[] args)
        {
            game = args.Length == 1
                ? Lib.GameFactory.LoadGame(args[0])
                : Lib.GameFactory.NewGame(UserInterface.RegisterPlayers());
            
            game.NewDeal += OnNewDeal;
            game.SelectCardsToDiscard += OnSelectCardsToDiscard;
            game.RecievedReplacementCards += OnRecievedReplacementCards;
            game.ShowAllHands += OnShowAllHands;
            game.Winner += OnWinner;
            game.Draw += OnDraw;

            game.StartGame();   
        }

    }
}
