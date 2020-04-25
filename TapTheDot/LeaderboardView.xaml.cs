using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace TapTheDot
{
    /*
     * UserScores class
     *
     * Purpose: Gettors and Settors for items added to the database.
     */
    public class Players
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int Id { get; set; }

        [Column("Username")]
        public string Username { get; set; }

        [Column("Score")]
        public int Score { get; set; }

        [Column("Level")]
        public int LevelAchieved { get; set; }
    }

    /*
     * Leaderboard class
     *
     * Purpose: Displays the leaderboard and adds new scores and usernames to
     *          the database to be displayed.
     */
    public partial class Leaderboard : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Players> allUsers;

        // Constructor
        public Leaderboard()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Players>();

            var users = await _connection.Table<Players>().ToListAsync();
            allUsers = new ObservableCollection<Players>(users);
            userListView.ItemsSource = allUsers;
            base.OnAppearing();
        }


        // Adds to the database
        async void addPlayer(object sender, EventArgs e)
        {
            Players p = new Players();
            var userList = new Players { Username = "Matt", Score = p.Score, LevelAchieved = p.LevelAchieved };

            await _connection.InsertAsync(userList);

            allUsers.Add(userList);
        }


        void ToMainPage(object sender, EventArgs e)
        {
            App.Current.MainPage = new HomePage();
        }


        void ToNewGame(object sender, EventArgs e)
        {
            App.Current.MainPage = new GameScreen();
        }

    }
}
