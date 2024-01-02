using BookManager.Core.Models;

namespace BookManager.Application.Abstractions.Repositories
{
    public interface IBookRepository : IRepository<Book, BookCollection>
    {
        Book? GetBook(int id);

        List<Book>? GetBooksByTitle(string title);

        List<Book>? GetBooksByAuthorId(int authorId);

        List<Book>? GetBooksByBookTypeId(int typeId);

        List<Book>? GetBooksByAuthorName(string authorName);

        List<Book>? GetBooksByBookTypeDescription(string typeDescription);
    }
}
