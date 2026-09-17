using MySqlConnector;
using ProjectManager.Api.Configuration;
using Microsoft.Extensions.Options;

namespace ProjectManager.Api.Data;

public class DbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(IOptions<DatabaseOptions> databaseOptions)
    {
        _connectionString = databaseOptions.Value.ConnectionString;

        if (string.IsNullOrEmpty(_connectionString))
        {
            throw new InvalidOperationException("DB Connection String is not Configured");
        }
    }

    public MySqlConnection CreateConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}
