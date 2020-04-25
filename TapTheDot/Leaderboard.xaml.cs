using System;
using System.Collections.Generic;

using SQLite;
using Xamarin.Forms;

namespace TapTheDot
{
    /*
     * UserScores class
     *
     * Purpose: Gettors and Settors for items added to the database.
     */
    public class UserScores
    {
        public new int Id { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
    }

    /*
     * Leaderboard class
     *
     * Purpose: Displays the leaderboard and adds new scores and usernames to
     *          the database to be displayed.
     */
    public partial class Leaderboard : ContentPage
    {
        // Constructor
        public Leaderboard()
        {
            InitializeComponent();

            var connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            var names = new List<string> {
                "Matt",
                "Luke",
                "Gwen",
                "Khadijo"
            };
            listView.ItemsSource = names;
        }


        void ToMainPage(object sender, EventArgs e)
        {
            App.Current.MainPage = new HomePage();
        }


        void ToNewGame(object sender, EventArgs e)
        {
            App.Current.MainPage = new GameScreen();
        }


        // Adds to the database
        void add(object sender, System.EventArgs e)
        {

        }


        // Updates a line in the database
        void update(object sender, System.EventArgs e)
        {

        }


        // Deletes a line from the database
        void delete(object sender, System.EventArgs e)
        {

        }

    }
}
