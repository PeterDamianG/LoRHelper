using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoRHelper.Struct
{
    //Struct to handler deck list.
    struct DeckList
    {
        //Json vars.
        public string DeckCode { get; set; }
        public Dictionary<string, byte> CardsInDeck { get; set; }
        //Function to get deck list.
        public static async Task<DeckList> GetDeckList()
        {
            //Try get deck list to API game.
            try
            {
                string jsonStaticDeckList = await MainWindow.client.GetStringAsync("http://localhost:21337/static-decklist");
                DeckList deck = JsonSerializer.Deserialize<DeckList>(jsonStaticDeckList);
                return deck;
            }
            //If not work, set null to retry.
            catch
            {
                return new DeckList()
                {
                    DeckCode = null,
                    CardsInDeck = null
                };
            }
        }
    }
}
