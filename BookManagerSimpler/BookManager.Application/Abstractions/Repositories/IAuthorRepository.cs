using BookManager.Core.Models;

namespace BookManager.Application.Abstractions.Repositories
{
    public interface IAuthorRepository : IRepository<Author, AuthorCollection>
    {
        Task<List<Author>> GetAuthorsByNameAsync(string name);
    }
}
