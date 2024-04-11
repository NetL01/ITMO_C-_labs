using Lab5.Application.Contracts.Shops;
using Lab5.Application.Models.OperationHistory;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ShowHistory;

public class ShowHistoryScenario : IScenario
{
    private readonly IBankAccountsService _bankAccountsService;

    public ShowHistoryScenario(IBankAccountsService bankAccountsService)
    {
        _bankAccountsService = bankAccountsService;
    }

    public string Name => "Show history operation";

    public async Task Run()
    {
        int id = AnsiConsole.Ask<int>("Enter user id");

        // string action = $"+{number}";
        OperationResult result = await _bankAccountsService.ViewTransactionHistory(id).ConfigureAwait(false);

        string message = result switch
        {
            OperationResult.Success => "Successful Show",
            OperationResult.Fail => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("ok");
    }
}