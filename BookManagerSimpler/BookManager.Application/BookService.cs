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

        public Book RetrieveBook(int id)
        {
            return _bookRepository.GetBook(id);
        }

        public List<Book>? RetrieveBooksByAuthor(string author)
        {
            return _bookRepository.GetBooksByAuthorName(author);
        }

        public List<Book>? RetrieveBooksByTitle(string title)
        {
            return _bookRepository.GetBooksByTitle(title);
        }

        public List<Book>? RetrieveBooksByType(string type)
        {
            return _bookRepository.GetBooksByBookTypeDescription(type);
        }
    }
}
