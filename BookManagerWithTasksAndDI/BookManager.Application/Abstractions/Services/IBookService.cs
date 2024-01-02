using BookManager.Core.Models;

namespace BookManager.Application.Abstractions.Services
{
    public interface IBookService : IService<Book, BookCollection>
    {
        Task<Book> RetrieveBookAsync(int id);

        Task<List<Book>?> RetrieveBooksByTitleAsync(string title);

        Task<List<Book>?> RetrieveBooksByAuthorAsync(string author);

        Task<List<Book>?> RetrieveBooksByTypeAsync(string type);
    }
}
