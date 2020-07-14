using LoRHelper.Struct;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace LoRHelper
{
    public partial class MainWindow : Window
    {
        //Function to set database.
        private async void SetDataBase()
        {
            //Var to check situation.
            bool exist = DataBaseCards.ExisteFileDB();
            //Var to check version web.
            Config configWeb = await Config.GetConfigWeb();
            byte version = (configWeb.VersionDB == 0) ? versionDB : configWeb.VersionDB;
            //Conditional exist true & version true.
            if (exist && (version == versionDB))
            {
                var jsonDataBase = File.ReadAllText("cardsdatabase.json");
                dataBase = JsonSerializer.Deserialize<DataBaseCards>(jsonDataBase);
            }
            //Conditional exist true & version false.
            else if (exist && (version != versionDB))
            {
                Config.MakeConfigFile(configWeb.VersionDB, versionAPP, language);
                dataBase = await DataBaseCards.GetMakeDataBase();
            }
            //Conditional exist false & version true.
            else if (!exist && (version == versionDB)) 
                dataBase = await DataBaseCards.GetMakeDataBase();
            //Conditional exist false & version false.
            else
            {
                Config.MakeConfigFile(configWeb.VersionDB, versionAPP, language);
                dataBase = await DataBaseCards.GetMakeDataBase();
            }
        }
    }
}