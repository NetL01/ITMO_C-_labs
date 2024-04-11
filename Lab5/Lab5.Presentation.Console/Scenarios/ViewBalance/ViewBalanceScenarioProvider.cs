using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Shops;
using Lab5.Application.Contracts.Users;
using Lab5.Presentation.Console.Scenarios.LoginAccount;

namespace Lab5.Presentation.Console.Scenarios.ViewBalance;

public class ViewBalanceScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountsService _bankAccountsService;
    private readonly ICurrentBankAccountManager _currentBankAccountManager;
    private readonly ICurrentUserService _currentUser;

    public ViewBalanceScenarioProvider(IBankAccountsService bankAccountsService, ICurrentBankAccountManager currentBankAccountManager, ICurrentUserService currentUser)
    {
        _bankAccountsService = bankAccountsService;
        _currentBankAccountManager = currentBankAccountManager;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new ViewBalanceScenario(_bankAccountsService);
        return true;
    }
}