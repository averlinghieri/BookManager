using BookManager.Core.Models;

namespace BookManager.Application.Abstractions.Services
{
    public interface IBookService : IService<Book, BookCollection>
    {
        Book RetrieveBook(int id);

        List<Book>? RetrieveBooksByTitle(string title);

        List<Book>? RetrieveBooksByAuthor(string author);

        List<Book>? RetrieveBooksByType(string type);
    }
}
