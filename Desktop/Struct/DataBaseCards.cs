using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoRHelper.Struct
{
    //Struct to handler database cards.
    struct DataBaseCards
    {
        //Json var.
        public Dictionary<string, Card> CardsDataBase { get; set; }
        //Function to check if existe file.
        public static bool ExisteFileDB() => File.Exists("cardsdatabase.json");
        //Fuction to get database web and save in local pc.
        public static async Task<DataBaseCards> GetMakeDataBase()
        {
            //Try get database from web.
            try
            {
                string jsonDataBaseURL = await MainWindow.client.GetStringAsync("https://raw.githubusercontent.com/PeterDamianG/LoRHelper/master/Backend/cardsdatabase.json");
                DataBaseCards database = JsonSerializer.Deserialize<DataBaseCards>(jsonDataBaseURL);
                //Write and save database.
                using StreamWriter sw = File.CreateText("cardsdatabase.json");
                    sw.WriteLine(jsonDataBaseURL);
                return database;
            }
            //Need check this, is a problem. We need fix in case don't get a database.
            catch{ return new DataBaseCards() { CardsDataBase = null }; }
        }
    }
}
