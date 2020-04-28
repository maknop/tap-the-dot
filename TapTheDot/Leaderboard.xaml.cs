using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;
using Xamarin.Forms;
using System.Linq;
using System.ComponentModel;

namespace TapTheDot
{
    /*
     * UserScores class
     *
     * Purpose: Gettors and Settors for items added to the database.
     */
    public class Users : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement, Column("ID")]
        public int Id { get; set; }
        
        [Column("Username")]
        public String Username { get; set; }

        
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
        private ObservableCollection<Users> allUsers;

        // Constructor
        public Leaderboard()
        {
            InitializeComponent();
            //UserInput.Text = "Username: " + EndScreen.userInput;

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }


        protected override async void OnAppearing()
        //protected new async void OnAppearing()
        {
            //_connection.DropTableAsync<Players>();
            await _connection.CreateTableAsync<Users>();


            // This was printing something to listview.
            /*
            userListView.ItemsSource = new List<Players>
            {
                new Players {
                    Username = EndScreen.userInput,
                    Score = GameScreen.score,
                    LevelAchieved = GameScreen.level
                }
            };
            */



            var users = await _connection.Table<Users>().ToListAsync();
            allUsers = new ObservableCollection<Users>(users);
            userListView.ItemsSource = allUsers;

            base.OnAppearing();
        }


        // Adds to the database
        async void AddPlayer(object sender, EventArgs e)
        {
            var userList = new Users
            {
                Username = EndScreen.userInput,
                Score = GameScreen.score,
                LevelAchieved = GameScreen.level
            };

            await _connection.InsertAsync(userList);

            allUsers.Add(userList);
        }


        // 'Main Page' button functionality.
        void ToMainPage(object sender, EventArgs e)
        {
            App.Current.MainPage = new HomePage();
        }


        // 'New Game' button functionality
        void ToNewGame(object sender, EventArgs e)
        {
            GameScreen.reverse = false;
            GameScreen.score = 0;
            GameScreen.tracker = 0;
            GameScreen.level = 1;
            GameScreen.speed = 1;
            GameScreen.lives = 10;
            App.Current.MainPage = new GameScreen();
        }
        
    }
}
