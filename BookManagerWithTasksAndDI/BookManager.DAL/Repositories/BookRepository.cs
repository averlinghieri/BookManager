using BookManager.Application.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Dal = BookManager.DAL.DataModels;
using Domain = BookManager.Core.Models;

namespace BookManager.DAL.Repositories
{
    public class BookRepository : BaseRepository<Domain.Book, Domain.BookCollection, Dal.Book>, IBookRepository
    {
        public BookRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Domain.Book?> GetBookAsync(int id)
        {
            using (var context = this.CreateContext())
            {
                try
                {
                    var dbBook = await context.Books
                        .Include(book => book.Author)
                        .Include(book => book.Borrows)
                        .Include(book => book.Type)
                        .FirstOrDefaultAsync(book => book.Id == id);

                    if (dbBook == null)
                        return null;

                    var domainBook = base.MapToDomainBook(dbBook);

                    return domainBook;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    return null;
                }
            }
        }

        public async Task<List<Domain.Book>?> GetBooksByAuthorIdAsync(int authorId)
        {
            using (var context = this.CreateContext())
            {
                try
                {
                    var dbBooks = await context.Books
                        .Include(book => book.Author)
                        .Include(book => book.Borrows)
                        .Include(book => book.Type)
                        .Where(book => book.AuthorId == authorId).ToListAsync();

                    if (dbBooks == null)
                        return null;

                    List<Domain.Book> domainBooks = new List<Domain.Book>();

                    foreach (var dbBook in dbBooks)
                    {
                        var domainBook = MapToDomainBook(dbBook);

                        domainBooks.Add(domainBook);
                    }

                    return domainBooks;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    return null;
                }
            }
        }

        public async Task<List<Domain.Book>?> GetBooksByAuthorNameAsync(string authorName)
        {
            using (var context = this.CreateContext())
            {
                try
                {
                    var dbBooks = await context.Books
                        .Include(book => book.Author)
                        .Include(book => book.Borrows)
                        .Include(book => book.Type)
                        .Where(book => book.Author.Name.Contains(authorName.ToLower()))
                        .ToListAsync();

                    if (dbBooks == null)
                        return null;

                    List<Domain.Book> domainBooks = new List<Domain.Book>();

                    foreach (var dbBook in dbBooks)
                    {
                        var domainBook = MapToDomainBook(dbBook);

                        domainBooks.Add(domainBook);
                    }

                    return domainBooks;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    return null;
                }
            }
        }

        public async Task<List<Domain.Book>?> GetBooksByBookTypeIdAsync(int typeId)
        {
            using (var context = this.CreateContext())
            {
                try
                {
                    var dbBooks = await context.Books
                        .Include(book => book.Author)
                        .Include(book => book.Borrows)
                        .Include(book => book.Type)
                        .Where(book => book.TypeId == typeId).ToListAsync();

                    if (dbBooks == null)
                        return null;

                    List<Domain.Book> domainBooks = new List<Domain.Book>();

                    foreach (var dbBook in dbBooks)
                    {
                        var domainBook = MapToDomainBook(dbBook);

                        domainBooks.Add(domainBook);
                    }

                    return domainBooks;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    return null;
                }
            }
        }

        public async Task<List<Domain.Book>?> GetBooksByBookTypeDescriptionAsync(string typeDescription)
        {
            using (var context = this.CreateContext())
            {
                try
                {
                    var dbBooks = await context.Books
                        .Include(book => book.Author)
                        .Include(book => book.Borrows)
                        .Include(book => book.Type)
                        .Where(book => book.Type.Description.Contains(typeDescription.ToLower())).ToListAsync();

                    if (dbBooks == null)
                        return null;

                    List<Domain.Book> domainBooks = new List<Domain.Book>();

                    foreach (var dbBook in dbBooks)
                    {
                        var domainBook = MapToDomainBook(dbBook);

                        domainBooks.Add(domainBook);
                    }

                    return domainBooks;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    return null;
                }
            }
        }

        public async Task<List<Domain.Book>?> GetBooksByTitleAsync(string title)
        {
            using (var context = this.CreateContext())
            {
                try
                {
                    var dbBooks = await context.Books
                        .Include(book => book.Author)
                        .Include(book => book.Borrows)
                        .Include(book => book.Type)
                        .Where(book => book.Title.Contains(title.ToLower())).ToListAsync();

                    if (dbBooks == null)
                        return null;

                    List<Domain.Book> domainBooks = new List<Domain.Book>();

                    foreach (var dbBook in dbBooks)
                    {
                        var domainBook = MapToDomainBook(dbBook);

                        domainBooks.Add(domainBook);
                    }

                    return domainBooks;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    return null;
                }
            }
        }
    }

}
