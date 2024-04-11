using Lab5.Application.Models.BankAccounts;
using Lab5.Application.Models.OperationHistory;

namespace Lab5.Application.Abstractions.Repositories;

public interface IBankAccountRepository
{
    Task<BankAccount?> FindBankAccountByNumber(string number);
    Task AddNewBankAccount(BankAccount bankAccount);
    Task UpdateAmount(int id, int amount);
    Task WriteOperation(Operation operation);
    Task<List<Operation>> GetHistoryOperation(int userId);
}