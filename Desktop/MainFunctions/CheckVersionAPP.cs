using LoRHelper.Struct;
using System.Windows;

namespace LoRHelper
{
    public partial class MainWindow : Window
    {   
        //Function to check version APP.
        private async void CheckVersionAPP()
        {   //Get actual version of app in web.
            Config confile = await Config.GetConfigWeb();
            //Check version and show a message when not match.
            if(versionAPP != confile.VersionAPP)
                MessageBox.Show($"The application is not update!\n " +
                    $"Please update it on the official website.\n" +
                    $"Your app version is: '{versionAPP}' and version in web is: '{confile.VersionAPP}'", 
                    "LoR Helper Updater", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}