using Lab5.Application.Models.OperationHistory;

namespace Lab5.Application.Contracts.Users;

public interface IUserService
{
    Task<OperationResult> Login(string username);
    Task<OperationResult> Registration(string username);
}