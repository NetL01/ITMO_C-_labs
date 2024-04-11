using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Shops;
using Lab5.Application.Contracts.Users;
using Lab5.Presentation.Console.Scenarios.WithdrawMoney;

namespace Lab5.Presentation.Console.Scenarios.ShowHistory;

public class ShowHistoryScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountsService _bankAccountsService;
    private readonly ICurrentBankAccountManager _currentBankAccountManager;
    private readonly ICurrentUserService _currentUser;

    public ShowHistoryScenarioProvider(IBankAccountsService bankAccountsService, ICurrentBankAccountManager currentBankAccountManager, ICurrentUserService currentUser)
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

        scenario = new ShowHistoryScenario(_bankAccountsService);
        return true;
    }
}