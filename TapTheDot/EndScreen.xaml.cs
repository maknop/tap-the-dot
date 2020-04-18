using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TapTheDot
{
    public partial class EndScreen : ContentPage
    {
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
        void Leaderboard_Clicked(object sender, EventArgs e)
        {
            
                App.Current.MainPage = new Leaderboard();

            
        }
    }
}
