using BookManager.Core.Models;

namespace BookManager.Application.Abstractions.Repositories
{
    public interface IBorrowRepository : IRepository<Borrow, BorrowCollection>
    {
    }
}
