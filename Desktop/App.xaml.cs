using System.Windows;
using System.Windows.Threading;

namespace LoRHelper
{
    public partial class App : Application
    {
        //Function to show a popup error, for all issues.
        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message + "Try contact with developer.", "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}
