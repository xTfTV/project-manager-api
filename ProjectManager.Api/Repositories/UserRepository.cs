using System.Data;
using MySqlConnector;
using ProjectManager.Api.Data;
using ProjectManager.Api.Models;

namespace ProjectManager.Api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public UserRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<User?> GetByEmailAsync(string emailAddress)
    {
        await using var connection = _dbConnectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using var command = new MySqlCommand("SP_User_GetForLogin", connection);

        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("p_email_address", emailAddress);

        await using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
        {
            return null;
        }

        return new User
        {
            UserId = reader.GetInt32("user_id"),

            FirstName = reader.IsDBNull("first_name") ? null : reader.GetString("first_name"),

            LastName = reader.IsDBNull("last_name") ? null : reader.GetString("last_name"),

            EmailAddress = reader.GetString("email_address"),

            PasswordHash = reader.GetString("password_hash"),

            UserRoleId = reader.IsDBNull("user_id") ? null : reader.GetInt32("user_id"),

            LogicalCancelValue = reader.IsDBNull("logical_cancel_value") ? null : reader.GetInt32("logical_cancel_value"),

            CreatedDate = reader.IsDBNull("created_date") ? null : reader.GetDateTime("created_date")
        };
    }
}
