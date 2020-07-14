using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LoRHelper
{
    public partial class OpponentWindow : Window
    {
        //Function to draw window.
        private void DragWindowOpponent(object sender, MouseButtonEventArgs e) => DragMove();
        //Function to show cardmodal/cardinfo with source in opponent window.
        private void ClickMakeCardModal(object sender, RoutedEventArgs e)
        {
            //Get URL to textblock hided.
            Button btn = sender as Button;
            Grid grd = btn.Content as Grid;
            var element = grd.Children.Cast<UIElement>().FirstOrDefault(e => Grid.GetColumn(e) == 3);
            TextBlock txblock = element as TextBlock;
            string URL = txblock.Text;
            //Call card info window.
            CardModal CardModal = new CardModal(URL);
            CardModal.ShowDialog();
        }
        //Function to set opponent deck and graveyard tracking.
        public void SetOpponentTracking()
        {
            //Set list in opponent window.
            TrackDeck.ItemsSource = MainWindow.deckTrackOpponent;
            Graveyard.ItemsSource = MainWindow.graveyardTrackOpponent;
            //Refresh.
            TrackDeck.Items.Refresh();
            Graveyard.Items.Refresh();
        }
    }
}