using SQLite;

namespace TapTheDot
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}