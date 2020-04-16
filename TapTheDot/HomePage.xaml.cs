using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TapTheDot
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            
        }


        // Navigates to 'Settings' page
        void Settings(object sender, EventArgs e)
        {
            App.Current.MainPage = new SettingsPage();

        }

        // Navigates to 'Leaderboard' page
        void Leaderboard(object sender, EventArgs e)
        {
            App.Current.MainPage = new Leaderboard();
        }

        // Navigates to 'GameScreen' Page
        void New_Game(object sender, EventArgs e)
        {
            GameScreen.reverse = false;
            GameScreen.score = 0;
            GameScreen.tracker = 0;
            GameScreen.level = 1;
            GameScreen.speed = 1;
            GameScreen.lives = 10;
            App.Current.MainPage = new GameScreen();
            
        }

        
        
        void Resume(object sender, EventArgs e)
        {
            App.Current.MainPage = new GameScreen();
        }
    }
}


        
       
 
