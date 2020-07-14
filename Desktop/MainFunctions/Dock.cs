using System.Windows;

namespace LoRHelper
{
    public partial class MainWindow : Window
    {
        //Function check to minimized main window.
        public void MinimizeWindow(MainWindow window, bool minimize)
        {
            Application.Current.Dispatcher.Invoke(() =>
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
            });
        }

        //Function APP minimized.
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
        //Function to closed app.
        private void CloseButton(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        //Function to show/hide opponent window.
        private void OpponentWindowButton(object sender, RoutedEventArgs e) 
        {
            if (isOpponentWindowOpen)
            {
                windowOpponent.Visibility = Visibility.Collapsed;
                isOpponentWindowOpen = false;
            } 
            else
            {
                windowOpponent.Visibility = Visibility.Visible;
                isOpponentWindowOpen = true;
            }
        }
    }
}