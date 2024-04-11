using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.BankAccounts;
using Lab5.Application.Models.OperationHistory;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public BankAccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<BankAccount?> FindBankAccountByNumber(string number)
    {
        const string sql = """
                           SELECT user_id, amount, number, password
                           FROM bank_account
                           WHERE number = @number;
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("number", number);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false))
        {
            return new BankAccount(
                UserId: reader.GetInt32(0),
                Amount: reader.GetInt32(1),
                Number: reader.GetString(2),
                Password: reader.GetString(3));
        }

        return null;
    }

    public async Task AddNewBankAccount(BankAccount bankAccount)
    {
        const string sql = """
                           INSERT INTO bank_account (user_id, amount, number, password)
                           VALUES (@user_id, @amount, @number, @password
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connection);

        if (bankAccount is not null)
        {
            command.Parameters.AddWithValue("user_id", bankAccount.UserId);
            command.Parameters.AddWithValue("amount", bankAccount.Amount);
            command.Parameters.AddWithValue("number", bankAccount.Number);
            command.Parameters.AddWithValue("password", bankAccount.Number);
        }

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task UpdateAmount(int id, int amount)
    {
        const string sql = """
                           UPDATE bank_account
                           SET amount = @amount
                           WHERE bank_account_id = @id
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("amount", amount);
        command.Parameters.AddWithValue("id", id);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task WriteOperation(Operation operation)
    {
        const string sql = """
                           INSERT INTO history (user_id, bank_account_id, action, result)
                           VALUES (@user_id, @bank_account_id, @action, @result)
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connection);
        if (operation is not null)
        {
            command.Parameters.AddWithValue("user_id", operation.UserId);
            command.Parameters.AddWithValue("bank_account_id", operation.BankAccountId);
            command.Parameters.AddWithValue("action", operation.Action);
            command.Parameters.AddWithValue("result", operation.Result);
        }

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task<List<Operation>> GetHistoryOperation(int userId)
    {
        const string sql = """
                           SELECT operation_id, user_id, bank_account_id, action, result
                           FROM history
                           WHERE user_id = @userId
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("userId", userId);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        var history = new List<Operation>();

        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            OperationResult result =
                await reader.GetFieldValueAsync<OperationResult>(4).ConfigureAwait(false);

            history.Add(new Operation(
                UserId: reader.GetInt32(1),
                BankAccountId: reader.GetInt32(2),
                Action: reader.GetString(3),
                Result: result));
        }

        return history;
    }
}