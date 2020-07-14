using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LoRHelper
{
    public partial class MainWindow : Window
    {
        //Function to get backgroud color according to the region.
        private string GetBackgroudColorCard(string region) => region switch
        {
            "Demacia" => "#d4ba6e",
            "Noxus" => "#c92c26",
            "Ionia" => "#cf829b",
            "Piltover & Zaun" => "#e29f76",
            "Freljord" => "#5ab8da",
            "Shadow Isles" => "#3b7d6f",
            "Bilgewater" => "#b4563a",
            //Return white color, if region not exist.
            _ => "#FFEDECEC",
        };
        //Function to get language prefix.
        private string GetLanguage(byte lang) => lang switch
        {
            0 => "en_us",
            1 => "de_de",
            2 => "es_es",
            3 => "es_mx",
            4 => "fr_fr",
            5 => "it_it",
            6 => "ja_jp",
            7 => "ko_kr",
            8 => "pl_pl",
            9 => "pt_br",
            10 => "tr_tr",
            11 => "ru_ru",
            12 => "zh_tw",
            //Return english to default.
            _ => "en_us",
        };
        //Function to select correct image of amount.
        private string GetImageIcon(byte amount) => amount switch
        {
            1 => "/Resources/1.png",
            2 => "/Resources/2.png",
            3 => "/Resources/3.png",
            //Return english to default.
            _ => "/Resources/Error.png",
        };
        //Function overload to select correct image of type.
        private string GetImageIcon(string type) => type switch
        {
            "Unit" => "/Resources/Unit.png",
            "Spell" => "/Resources/Spell.png",
            "Ability" => "/Resources/Ability.png",
            //Return unit to default.
            _ => "/Resources/Error.png",
        };
    }
}