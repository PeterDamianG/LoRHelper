using LoRHelper.Struct;
using System.Windows;
using System;

namespace LoRHelper
{
    public partial class MainWindow : Window
    {
        //Function handler APP flow.
        private async void AppFlow(object sender, EventArgs e)
        {
            //Get game state.
            StateGame game = await StateGame.GetState();
            gameState = game.GameState;
            //If game is matching do this.
            if (gameState == "InProgress")
            {
                //Set limits, only one time.
                if (screenHeightGame == 0) SetLimits(game);
                //Get deck and game state with currentgame.
                DeckList deck = await DeckList.GetDeckList();
                //Show deck code in player window.
                TextDeckCode.Text = (deck.DeckCode != null) ? TextDeckCode.Text = deck.DeckCode : TextDeckCode.Text = "No Deck Code";
                //Set deck list.
                if ((deck.CardsInDeck != null) && (deck.DeckCode != codeDeck))
                    SetDeckCards(deck);
                //Set trackings.
                if ((game.Rectangles.Count > 0) && (game.Rectangles != null))
                {
                    //Set/Show deck and graveyard in window player local. TrackDeckGraveyard.cs
                    GetDeckTrack(game);
                    //Set/Show deck and graveyard in window opponent player.
                    windowOpponent.SetOpponentTracking();
                }

            }
            //If to clean list and show state menus.
            else if (gameState == "Menus")
            {
                CleanLists();
                TextDeckCode.Text = game.GameState;
            }
            //Not game matching.
            else
            {
                //Show state in player local window.
                TextDeckCode.Text = (gameState != null) ? game.GameState : "Deck Code";
            }
        }
        //Function to clean all lists.
        private void CleanLists()
        {
            //Clean local player lists.
            deckTrack.Clear();
            graveyardTrack.Clear();
            //Clean opponent player lists.
            deckTrackOpponent.Clear();
            graveyardTrackOpponent.Clear();
        }
        //Function to set screen resolution and limits.
        private void SetLimits(StateGame game)
        {
            //Setting resolution game and limits.
            screenHeightGame = (ushort)((game.Screen == null) ? 0 : game.Screen["ScreenHeight"]);
            limitHeightCardTracked = screenHeightGame * 0.34;
            limitToCheckBoardAndHand = screenHeightGame * 0.121;
        }
    }
}