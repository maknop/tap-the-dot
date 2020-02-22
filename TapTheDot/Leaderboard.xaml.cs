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
    }
    public partial class Leaderboard : ContentPage
    {
        public Leaderboard()
        {
            InitializeComponent();

            var connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }
    }
}
