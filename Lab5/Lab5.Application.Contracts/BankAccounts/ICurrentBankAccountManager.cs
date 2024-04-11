using Lab5.Application.Models.BankAccounts;

namespace Lab5.Application.Contracts.Shops;

public interface ICurrentBankAccountManager
{
    BankAccount? BankAccount { get; set; }
}