using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TapTheDot
{
    public partial class HomePage : ContentPage
    {
        SharedResources s = new SharedResources();

        public HomePage()
        {
            InitializeComponent();
        }


        // Navigates to 'Settings' page
        void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new SettingsPage();

        }


        // Navigates to 'Leaderboard' page
        void Handle_Clicked1(object sender, EventArgs e)
        {
            App.Current.MainPage = new Leaderboard();
        }


        // New Game Button, Navigates to 'GameScreen' Page
        void GameScreen_onClicked(object sender, EventArgs e)
        {
            // Parameters: Score back to 0, Level back to 1
            s.setScore(0);
            s.setLevel(1);
            App.Current.MainPage = new GameScreen();
        }


        // Resume Game, Navigates to 'GameScreen' Page
        void Resume_onClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new GameScreen();
        }
    }
}


        
       
 
