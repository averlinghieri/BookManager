using BookManager.Core.Models;

namespace BookManager.Application.Abstractions.Services
{
    public interface IAuthorService : IService<Author, AuthorCollection>
    {
        Task<Book> RetrieveAuthorAsync(int id);

        Task<List<Book>?> RetrieveAuthorsByNameAsync(string name);
    }
}
