using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using TapTheDot.Android;

[assembly: Dependency(typeof(SQLiteDb))]

namespace TapTheDot.Android
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            String dbName = "Users.db";
            var documentsPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, dbName);
            
            return new SQLiteAsyncConnection(path);
        }

    }
}