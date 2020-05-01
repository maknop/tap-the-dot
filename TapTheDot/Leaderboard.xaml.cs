using System;
using System.Collections.ObjectModel;
using SQLite;
using Xamarin.Forms;

namespace TapTheDot
{
    /*
     * UserScores class
     *
     * Purpose: Gettors and Settors for items added to the database.
     */
    public class Users
    { 
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

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }


        protected override async void OnAppearing()
        {
            //username.Text = inputName.ToString();
            //score.Text = GameScreen.score.ToString();
            //Level.Text = GameScreen.level.ToString();


            //_connection.DropTableAsync<Users>();
            await _connection.CreateTableAsync<Users>();

            var usersList = await _connection.Table<Users>().ToListAsync();
            allUsers = new ObservableCollection<Users>(usersList);

            userListView.ItemsSource = allUsers;
            base.OnAppearing();
           
        }


        // Adds to the database
        async void AddPlayer(object sender, System.EventArgs e)
        {
            if (GameScreen.score > 0)
            {
                var userList = new Users
                {
                    Username = inputName.ToString(),
                    Score = GameScreen.score,
                    LevelAchieved = GameScreen.level
                };

              

                await _connection.InsertAsync(userList);
                //await _connection.UpdateAsync(userList);

                allUsers.Add(userList);

            
                GameScreen.reverse = false;
                GameScreen.score = 0;
                GameScreen.tracker = 0;
                GameScreen.level = 1;
                GameScreen.speed = 1;
                GameScreen.lives = 10;
                App.Current.MainPage = new HomePage();
            }
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


        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            String userInput = ((Entry)sender).Text;
        }
    }
}
