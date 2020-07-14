using LoRHelper.Struct;
using System;
using System.Windows;
using System.Windows.Threading;

namespace LoRHelper
{
    //Class partial main, main window.
    public partial class MainWindow : Window
    {
        //Principal Function.
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            //Set config.
            SetConfigMain();
            //Set database.
            SetDataBase();
            //Check version app.
            CheckVersionAPP();
            //Call to opponent window.
            windowOpponent.Show();
            //Set timer events.
            SetTimerEvents();
        }
        //Function to set configs app.
        private void SetConfigMain()
        {
            //Get config.
            Config config = Config.GetConfig();
            //Show config in window.
            VersionDataBase.Text = $"VersionDB : {config.VersionDB}";
            VersionAppication.Text = $"VersionAPP : {config.VersionAPP}";
            //Set config in static vars.
            versionDB = config.VersionDB;
            versionAPP = config.VersionAPP;
            language = config.Language;
        }
        //Function to set timer events.
        private void SetTimerEvents()
        {
            //Timer event set to 2 seconds. Is possible change.
            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            timer.Tick += AppFlow;
            timer.Start();
        }
    }
}

