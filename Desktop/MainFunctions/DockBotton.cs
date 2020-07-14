using LoRHelper.Struct;
using System.Windows;

namespace LoRHelper
{
    public partial class MainWindow : Window
    {
        //Function to set info in main window about number cards on board and hand.
        private void SetCardsOnBoardAndHand(StateGame list)
        {
            //Temps vars.
            int numCardsInHand = 0;
            int numCardsInTable = 0;
            //Foreach to set number of cards.
            foreach (PlaceCard elem in list.Rectangles)
                if (elem.CardCode != "face")
                    if (elem.LocalPlayer)
                        if (elem.TopLeftY > limitToCheckBoardAndHand) numCardsInTable++;
                        else numCardsInHand++;
            //Show in local window.
            CardsInTable.Text = $"Board: {numCardsInTable}";
            CardsInHand.Text = $"Hand: {numCardsInHand}";
        }
    }
}