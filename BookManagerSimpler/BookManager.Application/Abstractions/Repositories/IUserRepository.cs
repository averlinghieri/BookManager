using BookManager.Core.Models;

namespace BookManager.Application.Abstractions.Repositories
{
    public interface IUserRepository : IRepository<User, UserCollection>
    {
    }
}
