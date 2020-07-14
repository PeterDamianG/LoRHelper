using LoRHelper.Struct;
using System.Windows;
using System.Windows.Controls;

namespace LoRHelper
{
    public partial class MainWindow : Window
    {   
        //Function to set language in app.
        private void LanguageSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Set language in config file and app.
            Config.MakeConfigFile(versionDB, versionAPP, (byte)(sender as ComboBox).SelectedIndex);
            language = (byte)(sender as ComboBox).SelectedIndex;
        }
    }
}