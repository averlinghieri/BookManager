using BookManager.Core.Models;

namespace BookManager.Application.Abstractions.Repositories
{
    public interface IBookRepository : IRepository<Book, BookCollection>
    {
        Task<Book?> GetBookAsync(int id);

        Task<List<Book>?> GetBooksByTitleAsync(string title);

        Task<List<Book>?> GetBooksByAuthorIdAsync(int authorId);

        Task<List<Book>?> GetBooksByBookTypeIdAsync(int typeId);

        Task<List<Book>?> GetBooksByAuthorNameAsync(string authorName);

        Task<List<Book>?> GetBooksByBookTypeDescriptionAsync(string typeDescription);
    }
}
