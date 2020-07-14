using LoRHelper.Struct;
using System.Windows;

namespace LoRHelper
{
    public partial class MainWindow : Window
    {
        //Function to set deck track list.
        private void GetDeckTrack(StateGame currentGame)
        {   
            //Loop of all cards getting.
            foreach (PlaceCard element in currentGame.Rectangles)
            {
                if (element.CardCode != "face")
                {
                    //If for local player.
                    if (element.LocalPlayer)
                    {
                        //If to ignore mulligan track.
                        if (element.Height < limitHeightCardTracked)
                        {
                            if (!deckTrack.Exists(x => x.CardID == element.CardID))
                            {
                                deckTrack.Add(new Card() {
                                    Type = GetImageIcon(dataBase.CardsDataBase[element.CardCode].Type),
                                    CardID = element.CardID,
                                    Cost = dataBase.CardsDataBase[element.CardCode].Cost,
                                    Link = MakeLink(dataBase.CardsDataBase[element.CardCode].Link),
                                    Name = dataBase.CardsDataBase[element.CardCode].Name,
                                    Region = GetBackgroudColorCard(dataBase.CardsDataBase[element.CardCode].Region)
                                });
                            }
                        }
                    }
                    //Else for opponent player.
                    else
                    {
                        if (!deckTrackOpponent.Exists(x => x.CardID == element.CardID))
                        {
                            deckTrackOpponent.Add(new Card(){
                                Type = GetImageIcon(dataBase.CardsDataBase[element.CardCode].Type),
                                CardID = element.CardID,
                                Cost = dataBase.CardsDataBase[element.CardCode].Cost,
                                Link = MakeLink(dataBase.CardsDataBase[element.CardCode].Link),
                                Name = dataBase.CardsDataBase[element.CardCode].Name,
                                Region = GetBackgroudColorCard(dataBase.CardsDataBase[element.CardCode].Region)
                            });
                        }
                    }
                }
            }                                                                                                                                                                 
            //Set both graveyars.
            SetGraveyards(currentGame);
            //Show trackings.
            ShowTrackingInWindow();
            //Set and show info in dock botton. DockBotton.cs
            SetCardsOnBoardAndHand(currentGame);
        }
        //Function to set graveyards.
        private void SetGraveyards(StateGame currentGame)
        {
            //Loop to add card in graveyard local player.
            foreach (Card card in deckTrack)
                if (!currentGame.Rectangles.Exists(x => x.CardID == card.CardID))
                    if (!graveyardTrack.Exists(x => x.CardID == card.CardID))
                        graveyardTrack.Add(card);
            //Loop to add card in graveyard opponent player.
            foreach (Card card in deckTrackOpponent)
                if (!currentGame.Rectangles.Exists(x => x.CardID == card.CardID))
                    if (!graveyardTrackOpponent.Exists(x => x.CardID == card.CardID))
                        graveyardTrackOpponent.Add(card);
        }
        //Function to show cards and graveyards tracking local player.
        private void ShowTrackingInWindow()
        {
            //Set list to ListBox in wpf.
            TrackDeck.ItemsSource = deckTrack;
            Graveyard.ItemsSource = graveyardTrack;
            //Refresh.
            TrackDeck.Items.Refresh();
            Graveyard.Items.Refresh();
        }
    }
}