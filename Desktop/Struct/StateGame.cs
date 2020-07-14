using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoRHelper.Struct
{
    //Struct to handler game state.
    struct StateGame
    {
        //Json vars.
        public string GameState { get; set; }
        public Dictionary<string, ushort> Screen { get; set; }
        public List<PlaceCard> Rectangles { get; set; }
        //Static Function to get state.
        public static async Task<StateGame> GetState()
        {
            //Try get gamestate to API game.
            try
            {
                string jsonStaticGameState = await MainWindow.client.GetStringAsync("http://localhost:21337/positional-rectangles");
                StateGame state = JsonSerializer.Deserialize<StateGame>(jsonStaticGameState);
                return state;
            }
            //If not work, set null to retry.
            catch
            {
                return new StateGame()
                {
                    GameState = null,
                    Rectangles = null
                };
            }
        }
    }
}
