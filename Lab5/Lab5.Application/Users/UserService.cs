using Lab5.Application.Abstraction.Repositories;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.OperationHistory;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly ICurrentUserService _currentUserManager;

    public UserService(IUserRepository userRepository, IBankAccountRepository bankAccountRepository, CurrentUserManager currentUserManager)
    {
        _userRepository = userRepository;
        _bankAccountRepository = bankAccountRepository;
        _currentUserManager = currentUserManager;
    }

    public async Task<OperationResult> Login(string username)
    {
        User? user = await _userRepository.FindUserByUsername(username).ConfigureAwait(false);

        if (user is null)
        {
            return new OperationResult.Fail();
        }

        _currentUserManager.User = user;
        return new OperationResult.Success();
    }

    public async Task<OperationResult> Registration(string username)
    {
        await _userRepository.AddNewUser(username, UserRole.User).ConfigureAwait(false);

        return new OperationResult.Success();
    }
}