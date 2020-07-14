using System.Windows;

namespace LoRHelper
{
    public partial class OpponentWindow : Window
    {
        //Bool to check status minimized.
        private bool isMinimized = false; 
        //Function to minimized/maximized opponent window.
        public static void MinimizeWindow(OpponentWindow window, bool minimize)
        {
           if (minimize)
                {
                    window.Height = 600;
                    window.MaxHeight = window.MinHeight;
                }
                else
                {
                    window.MaxHeight = 1080;
                    window.Height = 600;
                }
        }
        //Function to check and do it.
        private void CollapseButton(object sender, RoutedEventArgs e)
        {
            if (!isMinimized)
            {
                MinimizeWindow(this, true);
                isMinimized = true;
            }
            else
            {
                MinimizeWindow(this, false);
                isMinimized = false;
            }
        }
        //Function to close window. Really just hide and show.
        private void CloseButton(object sender, RoutedEventArgs e) 
        {
            Visibility = Visibility.Collapsed;
            MainWindow.isOpponentWindowOpen = false;
        }
    }
}