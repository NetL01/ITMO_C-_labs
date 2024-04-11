using Lab5.Application.Contracts.Shops;
using Lab5.Application.Models.BankAccounts;

namespace Lab5.Application.BankAccounts;

public class CurrentBankAccountManager : ICurrentBankAccountManager
{
    public BankAccount? BankAccount { get; set; }
}