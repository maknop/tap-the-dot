using System;
using System.Collections.Generic;

using SQLite;
using Xamarin.Forms;

namespace TapTheDot
{
    public class Leaderboard
    {
        public new int Id { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }

        public Leaderboard(int id, string username, int score)
        {
            this.Id = id;
            this.Username = username;
            this.Score = score;
        }

        
    }
    public partial class Leaderboard : ContentPage
    {
        public Leaderboard()
        {
            InitializeComponent();

            //var connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }
    }
}
