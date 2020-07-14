using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace LoRHelper
{
    public partial class CardModal : Window
    {
        //Main Function of cardmodal/cardinfo window.
        public CardModal(string URL) { 
            InitializeComponent();
            DataContext = this;
            //Make a imagen to set in modal.
            BitmapImage ImagenxUrl = new BitmapImage();
            ImagenxUrl.BeginInit();
            ImagenxUrl.UriSource = new Uri(URL);
            ImagenxUrl.EndInit();
            CardImage.Source = ImagenxUrl;
        }
        //Function to drag window.
        private void DragWindowCard(object sender, MouseButtonEventArgs e) => DragMove();
        //Function to close window..
        private void CloseButton(object sender, RoutedEventArgs e) 
        {
            DialogResult = false;
            Close();
        }
    }
}

