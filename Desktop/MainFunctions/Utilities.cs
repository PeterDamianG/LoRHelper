using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LoRHelper
{
    public partial class MainWindow : Window
    {
        //Function to make a card info window.
        private void ClickMakeCardModal(object sender, RoutedEventArgs e)
        {
            //Get URL to textblock hided.
            TextBlock txblock = ((sender as Button).Content as Grid).Children.Cast<UIElement>().FirstOrDefault(e => Grid.GetColumn(e) == 3) as TextBlock;
            //Call card info window.
            new CardModal(txblock.Text).ShowDialog();
        }
        //Function to make(change language) a link for cardmodal.
        private string MakeLink(string link) => link.Replace("en_us", GetLanguage(language));
        //Function to drag window.
        private void DragWindow(object sender, MouseButtonEventArgs e) => DragMove();
        //Function to copy deck code in clipboard.
        private void CopyClipBoard(object sender, MouseButtonEventArgs e) => Clipboard.SetText(TextDeckCode.Text);
    }
}