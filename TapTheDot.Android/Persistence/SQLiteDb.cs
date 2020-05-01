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
            String documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //var documentsPath = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, dbName);

            if (File.Exists(dbName))
            {
                Console.WriteLine("The file exists.");
            }

            return new SQLiteAsyncConnection(path);
        }

    }
}