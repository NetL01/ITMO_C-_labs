using Lab5.Application.Contracts.Shops;
using Lab5.Application.Models.BankAccounts;
using Lab5.Application.Models.OperationHistory;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ViewBalance;

public class ViewBalanceScenario : IScenario
{
    private readonly IBankAccountsService _bankAccountsService;

    public ViewBalanceScenario(IBankAccountsService bankAccountsService)
    {
        _bankAccountsService = bankAccountsService;
    }

    public string Name => "View balance";

    public Task Run()
    {
        BankAccount? result = _bankAccountsService.ViewBalance();

        AnsiConsole.WriteLine($"Successful View: {result?.Amount}");
        AnsiConsole.Ask<string>("ok");
        return Task.CompletedTask;
    }
}