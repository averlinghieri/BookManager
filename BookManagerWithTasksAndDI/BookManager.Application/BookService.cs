using BookManager.Application.Abstractions.Repositories;
using BookManager.Application.Abstractions.Services;
using BookManager.Core.Models;

namespace BookManager.Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> RetrieveBookAsync(int id)
        {
            return await _bookRepository.GetBookAsync(id);
        }

        public async Task<List<Book>?> RetrieveBooksByAuthorAsync(string author)
        {
            return await _bookRepository.GetBooksByAuthorNameAsync(author);
        }

        public async Task<List<Book>?> RetrieveBooksByTitleAsync(string title)
        {
            return await _bookRepository.GetBooksByTitleAsync(title);
        }

        public async Task<List<Book>?> RetrieveBooksByTypeAsync(string type)
        {
            return await _bookRepository.GetBooksByBookTypeDescriptionAsync(type);
        }
    }
}
