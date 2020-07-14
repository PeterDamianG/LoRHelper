using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoRHelper.Struct
{
    //Struct to handler config.
    struct Config
    {
        //Json vars.
        public byte VersionDB { get; set; }
        public byte VersionAPP { get; set; }
        public byte Language { get; set; }
        //Static function to set configuration in app.
        public static Config GetConfig()
        {
            //If file exist.
            if (File.Exists("config.json"))
            {
                //Getting existing file.
                var jsonConfigFile = File.ReadAllText("config.json");
                Config configFile = JsonSerializer.Deserialize<Config>(jsonConfigFile);
                return configFile;
            }
            //if doesn't exist
            else
            {
                //Make a default file for this version app.
                MakeConfigFile(1, 1, 0);
                //And return default file.
                return new Config
                {
                    VersionDB = 1,
                    VersionAPP = 1,
                    Language = 0
                };
            }
        }
        //Static function to write/make a config file.
        public static void MakeConfigFile(byte versionDB, byte versionAPP, byte language)
        {
            using StreamWriter sw = File.CreateText("config.json");
            sw.WriteLine($"{{\"VersionDB\": { versionDB }, \"VersionAPP\": { versionAPP }, \"Language\": { language }}}");
        }
        //Static function to get configuration file from web.
        public static async Task<Config> GetConfigWeb()
        {
            //Try get gamestate to API game.
            try
            {
                string jsonConfigWeb = await MainWindow.client.GetStringAsync("https://raw.githubusercontent.com/PeterDamianG/LoRHelper/master/Backend/config.json");
                Config conf = JsonSerializer.Deserialize<Config>(jsonConfigWeb);
                return conf;
            }
            //If not work, set null to retry.
            catch
            {
                return new Config()
                {
                    VersionDB = 0,
                    VersionAPP = 1,
                    Language = 0
                };
            }
        }
    }
}
