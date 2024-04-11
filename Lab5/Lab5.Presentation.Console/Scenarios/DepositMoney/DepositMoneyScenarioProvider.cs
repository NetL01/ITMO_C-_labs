using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Shops;
using Lab5.Application.Contracts.Users;
using Lab5.Presentation.Console.Scenarios.CreateAccount;

namespace Lab5.Presentation.Console.Scenarios.DepositMoney;

public class DepositMoneyScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountsService _bankAccountsService;
    private readonly ICurrentBankAccountManager _currentBankAccountManager;
    private readonly ICurrentUserService _currentUser;

    public DepositMoneyScenarioProvider(ICurrentUserService currentUser, ICurrentBankAccountManager currentBankAccountManager, IBankAccountsService bankAccountsService)
    {
        _currentUser = currentUser;
        _currentBankAccountManager = currentBankAccountManager;
        _bankAccountsService = bankAccountsService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new DepositMoneyScenario(_bankAccountsService);
        return true;
    }
}