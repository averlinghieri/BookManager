using BookManager.Application.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using Dal = BookManager.DAL.DataModels;
using Domain = BookManager.Core.Models;

namespace BookManager.DAL.Repositories
{
    public class BookRepository : BaseRepository<Domain.Book, Domain.BookCollection, Dal.Book>, IBookRepository
    {
        public BookRepository(string connectionString) : base(connectionString)
        {
        }

        public Domain.Book? GetBook(int id)
        {
            using (var context = this.CreateContext())
            {
                try
                {
                    var dbBook = context.Books
                        .Include(book => book.Author)
                        .Include(book => book.Borrows)
                        .Include(book => book.Type)
                        .FirstOrDefault(book => book.Id == id);

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

        public List<Domain.Book>? GetBooksByAuthorId(int authorId)
        {
            using (var context = this.CreateContext())
            {
                try
                {
                    var dbBooks = context.Books
                        .Include(book => book.Author)
                        .Include(book => book.Borrows)
                        .Include(book => book.Type)
                        .Where(book => book.AuthorId == authorId).ToList();

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

        public List<Domain.Book>? GetBooksByAuthorName(string authorName)
        {
            using (var context = this.CreateContext())
            {
                try
                {
                    var dbBooks = context.Books
                        .Include(book => book.Author)
                        .Include(book => book.Borrows)
                        .Include(book => book.Type)
                        .Where(book => book.Author.Name.Contains(authorName.ToLower()))
                        .ToList();

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

        public List<Domain.Book>? GetBooksByBookTypeId(int typeId)
        {
            using (var context = this.CreateContext())
            {
                try
                {
                    var dbBooks = context.Books
                        .Include(book => book.Author)
                        .Include(book => book.Borrows)
                        .Include(book => book.Type)
                        .Where(book => book.TypeId == typeId).ToList();

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

        public List<Domain.Book>? GetBooksByBookTypeDescription(string typeDescription)
        {
            using (var context = this.CreateContext())
            {
                try
                {
                    var dbBooks = context.Books
                        .Include(book => book.Author)
                        .Include(book => book.Borrows)
                        .Include(book => book.Type)
                        .Where(book => book.Type.Description.Contains(typeDescription.ToLower())).ToList();

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

        public List<Domain.Book>? GetBooksByTitle(string title)
        {
            using (var context = this.CreateContext())
            {
                try
                {
                    var dbBooks = context.Books
                        .Include(book => book.Author)
                        .Include(book => book.Borrows)
                        .Include(book => book.Type)
                        .Where(book => book.Title.Contains(title.ToLower())).ToList();

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
