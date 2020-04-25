using SQLite;
using System.ComponentModel;
namespace LocalDataAccess
{
    [Table("Players")]
   
 public class Players : INotifyPropertyChanged
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private string _username;
        [NotNull]
        public string playerUsername
        {
            get
            {
                return _username;
            }
            set
            {
                this._username = value;
                OnPropertyChanged(nameof(_username));
            }
        }
        private string _score;
        [MaxLength(50)]
        public string playerScore
        {
            get
            {
                return _score;
            }
            set
            {
                this._score = value;
                OnPropertyChanged(nameof(_score));
            }
        }
        private string _levelAchieved;
        public string playerLevel
        {
            get
            {
                return _levelAchieved;
            }
            set
            {
                _levelAchieved = value;
                OnPropertyChanged(nameof(_levelAchieved));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }
    }
}