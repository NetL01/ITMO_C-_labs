using Lab5.Application.Contracts.Shops;
using Lab5.Application.Models.OperationHistory;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.WithdrawMoney;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IBankAccountsService _bankAccountsService;

    public WithdrawMoneyScenario(IBankAccountsService bankAccountsService)
    {
        _bankAccountsService = bankAccountsService;
    }

    public string Name => "Withdraw money";

    public async Task Run()
    {
        int number = AnsiConsole.Ask<int>("Enter amount");

        // string action = $"+{number}";
        OperationResult result = await _bankAccountsService.Withdraw(number).ConfigureAwait(false);

        string message = result switch
        {
            OperationResult.Success => "Successful Withdraw",
            OperationResult.Fail => "Not enough money",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("ok");
    }
}