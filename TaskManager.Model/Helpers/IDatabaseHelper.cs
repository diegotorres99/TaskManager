using Microsoft.Data.Sqlite;

namespace TaskManager.Model.Helpers
{
    public interface IDatabaseHelper
    {
        SqliteConnection GetConnection();
    }
}
