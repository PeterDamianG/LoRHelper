using LoRHelper.Struct;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;

namespace LoRHelper
{
    //Partial class for make instances.
    public partial class MainWindow : Window
    {
         /*
         * Var to handler request web.
         */
        public static readonly HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(6)};
        /*
         * Var to handler configuration.
         */
        public static byte versionDB;
        public static byte versionAPP;
        public static byte language;
        /*
         * Var to handler game state.
         */
        //Game state on game.
        private string gameState = null;
        //Resolution screen in game.
        private ushort screenHeightGame = 0;
        //Var to ignore mulligan tracking.
        double limitHeightCardTracked;
        //Limit ratio of screen.
        double limitToCheckBoardAndHand;
        /*
         * Getting DataBase.
         */
        private DataBaseCards dataBase;
        /*
         * Var to handler opponent window.
         */
        //Check bool for opponent windows is open or not.
        public static bool isOpponentWindowOpen = true;
        //Opponent window.
        private readonly OpponentWindow windowOpponent = new OpponentWindow();
        //Check bool for opponent window is minimized or not.
        private bool isMinimized = false;
        /*
         * Vars to handler tracking card and graveyard.
         */
        //Vars for tracking deck and graveyard local player.
        private readonly List<Card> deckTrack = new List<Card>();
        private readonly List<Card> graveyardTrack = new List<Card>();
        //Vars for tracking deck and graveyard opponent player.
        public static readonly List<Card> deckTrackOpponent = new List<Card>();
        public static readonly List<Card> graveyardTrackOpponent = new List<Card>();
        /*
         * Vars to handler DeckCards list.
         */
        private readonly List<Card> deckCards = new List<Card>();
        //Var to save code deck.
        private string codeDeck;
    }
}