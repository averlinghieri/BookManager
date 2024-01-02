using BookManager.Application.Abstractions.Services;
using BookManager.Core.Models;

namespace BookManager.Application
{
    public class AuthorService : IAuthorService
    {
        public Task<Book> RetrieveAuthorAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>?> RetrieveAuthorsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
