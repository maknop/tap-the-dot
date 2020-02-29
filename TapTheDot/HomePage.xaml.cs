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


        // Navigates to the 'Settings' screen
        void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new SettingsPage();

        }

        // Navigates to the 'Leaderboard' screen
        void Handle_Clicked1(object sender, EventArgs e)
        {
            App.Current.MainPage = new Leaderboard();
        }

        // Navigates to the 'GameScreen' page
        void GameScreen_onClicked(object sender, EventArgs e)
        {
<<<<<<< HEAD
            InitializeComponent();
                
        }


        // Navigates to the 'Settings' screen
        void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new SettingsPage();

        }

        // Navigates to the 'Leaderboard' screen
        void Handle_Clicked1(object sender, EventArgs e)
        {
            App.Current.MainPage = new Leaderboard();
        }

        // Navigates to the 'GameScreen' page
        void GameScreen_onClicked(object sender, EventArgs e)
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


        
       
 
=======
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


        
       
 
>>>>>>> ed1f3543fc8a95f6573c61854b3df29c81cbfc0f
