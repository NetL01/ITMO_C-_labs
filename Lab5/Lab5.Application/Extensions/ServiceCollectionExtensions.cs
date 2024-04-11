using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.BankAccounts;
using Lab5.Application.Contracts.Shops;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IBankAccountsService, BankAccountsService>();

        collection.AddScoped<CurrentUserManager>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserManager>());

        collection.AddScoped<CurrentBankAccountManager>();
        collection.AddScoped<ICurrentBankAccountManager>(
            p => p.GetRequiredService<CurrentBankAccountManager>());

        return collection;
    }
}