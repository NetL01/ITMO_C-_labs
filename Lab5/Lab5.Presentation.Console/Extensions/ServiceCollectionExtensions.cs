using Lab5.Presentation.Console.Scenarios.CreateAccount;
using Lab5.Presentation.Console.Scenarios.DepositMoney;
using Lab5.Presentation.Console.Scenarios.Login;
using Lab5.Presentation.Console.Scenarios.LoginAccount;
using Lab5.Presentation.Console.Scenarios.Registration;
using Lab5.Presentation.Console.Scenarios.ShowHistory;
using Lab5.Presentation.Console.Scenarios.WithdrawMoney;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, RegistrationScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowHistoryScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositMoneyScenarioProvider>();

        return collection;
    }
}