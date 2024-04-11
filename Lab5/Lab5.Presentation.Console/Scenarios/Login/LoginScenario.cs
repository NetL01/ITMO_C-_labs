using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.OperationHistory;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";

    public async Task Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");

        OperationResult result = await _userService.Login(username).ConfigureAwait(false);

        string message = result switch
        {
            OperationResult.Success => "Successful login",
            OperationResult.Fail => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("ok");
    }
}