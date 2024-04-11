using Lab5.Application.Contracts.Shops;
using Lab5.Application.Models.OperationHistory;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.DepositMoney;

public class DepositMoneyScenario : IScenario
{
    private readonly IBankAccountsService _bankAccountsService;

    public DepositMoneyScenario(IBankAccountsService bankAccountsService)
    {
        _bankAccountsService = bankAccountsService;
    }

    public string Name => "Deposit money";

    public async Task Run()
    {
        int number = AnsiConsole.Ask<int>("Enter amount");

        // string action = $"+{number}";
        OperationResult result = await _bankAccountsService.Deposit(number).ConfigureAwait(false);

        string message = result switch
        {
            OperationResult.Success => "Successful Deposit",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("ok");
    }
}