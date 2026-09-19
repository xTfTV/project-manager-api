using ProjectManager.Api.Models;

namespace ProjectManager.Api.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string emailAddress);
}
