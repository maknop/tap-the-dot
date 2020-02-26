using System;
using System.Collections.Generic;

using SQLite;
using Xamarin.Forms;

namespace TapTheDot
{
    public partial class Leaderboard : ContentPage
    {
        public Leaderboard(int id, string username, int score)
        {
            this.Id = id;
            this.Username = username;
            this.Score = score;
        }

        public new int Id { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }

        public Leaderboard()
        {
            InitializeComponent();

            //var connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }
    }
}
