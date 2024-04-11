using Lab5.Application.Abstraction.Repositories;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Shops;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.BankAccounts;
using Lab5.Application.Models.OperationHistory;
using Lab5.Application.Users;

namespace Lab5.Application.BankAccounts;

internal class BankAccountsService : IBankAccountsService
{
    private readonly IUserRepository _userRepository;
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly ICurrentBankAccountManager _currentBankAccountManager;
    private readonly ICurrentUserService _currentUserService;

    public BankAccountsService(IUserRepository userRepository, IBankAccountRepository bankAccountRepository, ICurrentBankAccountManager currentBankAccountManager, ICurrentUserService currentUserService)
    {
        _userRepository = userRepository;
        _bankAccountRepository = bankAccountRepository;
        _currentBankAccountManager = currentBankAccountManager;
        _currentUserService = currentUserService;
    }

    public async Task<OperationResult> CreateAccount(string accountNumber, string pin)
    {
        if (_currentUserService.User != null)
        {
            await _bankAccountRepository.AddNewBankAccount(
                new BankAccount(
                    (int)_currentUserService.User.Id,
                    0,
                    accountNumber,
                    pin)).ConfigureAwait(false);
        }

        return new OperationResult.Success();
    }

    public async Task<OperationResult> LoginAccount(string accountNumber, string pin)
    {
        BankAccount? bankAccount = await _bankAccountRepository.FindBankAccountByNumber(accountNumber).ConfigureAwait(false);

        if (bankAccount is null || pin != bankAccount.Password)
        {
            return new OperationResult.Fail();
        }

        _currentBankAccountManager.BankAccount = bankAccount;
        return new OperationResult.Success();
    }

    public Task<OperationResult> Withdraw(decimal amount)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult> Deposit(decimal amount)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult> ViewTransactionHistory(int userId)
    {
        throw new NotImplementedException();
    }

    public BankAccount? ViewBalance()
    {
        return _currentBankAccountManager.BankAccount;
    }
}