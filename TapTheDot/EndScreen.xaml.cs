using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace TapTheDot
{
    public partial class EndScreen : ContentPage
    {
        public static string userInput = "";

        public EndScreen()
        {
            InitializeComponent();
            Score.Text = "Score: " + GameScreen.score.ToString();
        }


        void Restart_clicked(object sender, EventArgs e)
        {
            GameScreen.reverse = false;
            GameScreen.score = 0;
            GameScreen.tracker = 0;
            GameScreen.level = 1;
            GameScreen.speed = 1;
            GameScreen.lives = 10;
            App.Current.MainPage = new GameScreen();
        }


        void Home_Clicked(object sender, EventArgs e)
        {
            GameScreen.reverse = false;
            GameScreen.score = 0;
            GameScreen.tracker = 0;
            GameScreen.level = 1;
            GameScreen.speed = 1;
            GameScreen.lives = 10;
            App.Current.MainPage = new HomePage();
        }

        
        void SaveButton(object sender, System.EventArgs e)
        {
            Users users = new Users()
            {
                //Username = Username.Text,
                Score = GameScreen.score
            };
        }


        void Leaderboard_Clicked(object sender, EventArgs e)
        {       
                App.Current.MainPage = new Leaderboard();
        }


        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            userInput = ((Entry)sender).Text;
        }
    }
}
