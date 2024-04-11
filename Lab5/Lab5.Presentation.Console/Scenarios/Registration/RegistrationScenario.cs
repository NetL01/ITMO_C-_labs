using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.OperationHistory;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Registration;

public class RegistrationScenario : IScenario
{
    private readonly IUserService _userService;

    public RegistrationScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Registration";

    public async Task Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");

        OperationResult result = await _userService.Registration(username).ConfigureAwait(false);

        string message = result switch
        {
            OperationResult.Success => "Successful registration",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("ok");
    }
}