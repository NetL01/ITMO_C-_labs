using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstraction.Repositories;
using Lab5.Application.Models.Users;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User?> FindUserByUsername(string username)
    {
        const string sql = """
                           SELECT user_id, user_name, user_role
                           FROM users
                           WHERE user_name = @userName;
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("userName", username);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false))
        {
            UserRole userRole = await reader.GetFieldValueAsync<UserRole>(2).ConfigureAwait(false);

            return new User(
                Id: reader.GetInt64(0),
                Username: reader.GetString(1),
                Role: userRole);
        }

        return null;
    }

    public async Task AddNewUser(string username, UserRole userRole)
    {
        const string sql = """
                           INSERT INTO users (user_name, user_role)
                           VALUES (@username, @userrole)
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("username", username);
        command.Parameters.AddWithValue("userrole", userRole);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}
