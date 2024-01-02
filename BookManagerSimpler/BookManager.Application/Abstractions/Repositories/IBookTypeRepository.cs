using BookManager.Core.Models;

namespace BookManager.Application.Abstractions.Repositories
{
    public interface IBookTypeRepository : IRepository<BookType, BookTypeCollection>
    {
    }
}
