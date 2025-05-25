using System.Data.SQLite;

public class DatabaseService : IDisposable
{
    private readonly SQLiteConnection _connection;

    public DatabaseService(string databaseFilePath)
    {
        _connection = new SQLiteConnection($"Data Source={databaseFilePath};Version=3;");
        _connection.Open();
    }

    public SQLiteConnection Connection => _connection;

    public void Dispose()
    {
        _connection?.Dispose();
    }
}
