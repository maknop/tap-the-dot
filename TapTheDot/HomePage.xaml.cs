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
        void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new SettingsPage();

        }

        // Navigates to 'Leaderboard' page
        void Handle_Clicked1(object sender, EventArgs e)
        {
            App.Current.MainPage = new Leaderboard();
        }

        // Navigates to 'GameScreen' Page
        void GameScreen_onClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new GameScreen();
        }

    }
}


        
       
 
