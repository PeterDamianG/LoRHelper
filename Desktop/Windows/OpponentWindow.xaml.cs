using System.Windows;

namespace LoRHelper
{
    public partial class OpponentWindow : Window
    {
        //Main Function.
        public OpponentWindow()
        {
            InitializeComponent();
            //Put opponent window on extreme left top position.
            Left = SystemParameters.PrimaryScreenWidth - Width;
            DataContext = this;
        }
    }
}