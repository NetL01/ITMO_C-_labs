using Lab5.Application.Models.BankAccounts;
using Lab5.Application.Models.OperationHistory;

namespace Lab5.Application.Contracts.Shops;

public interface IBankAccountsService
{
    Task<OperationResult> CreateAccount(string accountNumber, string pin);
    Task<OperationResult> LoginAccount(string accountNumber, string pin);
    Task<OperationResult> Withdraw(decimal amount);
    Task<OperationResult> Deposit(decimal amount);
    Task<OperationResult> ViewTransactionHistory(int userId);
    public BankAccount? ViewBalance();
}