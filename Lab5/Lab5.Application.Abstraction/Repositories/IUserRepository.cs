using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstraction.Repositories;

public interface IUserRepository
{
    Task<User?> FindUserByUsername(string username);
    Task AddNewUser(string username, UserRole userRole);
}