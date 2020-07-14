using LoRHelper.Struct;
using System.Collections.Generic;
using System.Windows;

namespace LoRHelper
{
    public partial class MainWindow : Window
    {
        //Function to set deck list.
        private void SetDeckCards(DeckList deck)
        {
            //Clear deck list.
            deckCards.Clear();
            //Bucle to set cards in list.
            foreach (KeyValuePair<string, byte> entry in deck.CardsInDeck)
                deckCards.Add(new Card()
                {
                    Cost = dataBase.CardsDataBase[entry.Key].Cost,
                    Icon = GetImageIcon(entry.Value),
                    Link = MakeLink(dataBase.CardsDataBase[entry.Key].Link),
                    Name = dataBase.CardsDataBase[entry.Key].Name,
                    Region = GetBackgroudColorCard(dataBase.CardsDataBase[entry.Key].Region)
                });
            //Sort deck list.
            deckCards.Sort((x, y) => x.Cost.CompareTo(y.Cost));
            //Set deck list in player local window.
            ListDeck.ItemsSource = deckCards;
            //Refresh list.
            ListDeck.Items.Refresh();
            //Set deck code to var, for refresh or not.
            codeDeck = deck.DeckCode;
        }
    }
}