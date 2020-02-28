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


        // Navigates to the settings page
        void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new SettingsPage();
        }


        // Navigates to the leaderboard page
        void Handle_Clicked1(object sender, EventArgs e)
        {
            App.Current.MainPage = new Leaderboard();
        }


        // Navigates to the 'New Game' screen
        void NewGame_OnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new GameScreen();
        }


        public void ButtonSettings()
        {
            _ = new Button
            {
                Text = "Settings",
            };
        }
    }
}


        
       
 
