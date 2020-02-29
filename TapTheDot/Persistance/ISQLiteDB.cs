using SQLite;

namespace HelloWorld
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}