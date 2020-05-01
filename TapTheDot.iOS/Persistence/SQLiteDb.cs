using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using TapTheDot.iOS;

[assembly: Dependency(typeof(SQLiteDb))]

namespace TapTheDot.iOS
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            //var documentsPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            String documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            //string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //string libFolder = Path.Combine(documentsPath, "..", "Library", "Databases");
            var path = Path.Combine(documentsPath, "Users.db");

            return new SQLiteAsyncConnection(path);
        }
    }
}