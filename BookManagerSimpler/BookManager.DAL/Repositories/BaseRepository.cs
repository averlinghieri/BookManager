using BookManager.Core.Models;
using BookManager.DAL.Context;
using BookManager.DAL.DataModels;
using Dal = BookManager.DAL.DataModels;
using Domain = BookManager.Core.Models;

namespace BookManager.DAL.Repositories
{
    public class BaseRepository<TEntity, TEntityCollection, TDalEntity>
        where TEntity : BaseEntity, new()
        where TEntityCollection : BaseEntityCollection<TEntity>, new()
        where TDalEntity : BaseDalEntity, new()
    {

        private readonly string _connectionString;

        public BaseRepository(string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException("Connection string cannot be null");
        }

        protected BookManagerDbContext CreateContext()
        {
            return new BookManagerDbContext(this._connectionString);
        }


        // Implement mapping functions for Book, Author, Type, and Borrows as needed
        internal Domain.Book MapToDomainBook(Dal.Book book)
        {
            if (book == null)
            {
                return null;
            }

            return new Domain.Book
            {
                Id = book.Id,
                Title = book.Title,
                PageCount = book.PageCount,
                AuthorId = book.AuthorId,
                TypeId = book.TypeId,
                Author = MapToDomainAuthor(book.Author),
                Borrows = MapToDomainBorrows(book.Borrows),
                Type = MapToDomainBookType(book.Type)
            };

        }

        internal Domain.Author MapToDomainAuthor(Dal.Author author)
        {
            if (author == null)
            {
                return null;
            }

            return new Domain.Author
            {
                Id = author.Id,
                Name = author.Name
            };

        }

        internal Domain.BookType MapToDomainBookType(Dal.BookType type)
        {
            if (type == null)
            {
                return null;
            }

            return new Domain.BookType
            {
                Id = type.Id,
                Description = type.Description
            };
        }

        internal ICollection<Domain.Borrow> MapToDomainBorrows(ICollection<Dal.Borrow> borrows)
        {
            if (borrows == null)
            {
                return null;
            }

            var domainBorrows = new List<Domain.Borrow>();

            foreach (var dalBorrow in borrows)
            {
                var domainBorrow = new Domain.Borrow
                {
                    Id = dalBorrow.Id,
                    UserId = dalBorrow.UserId,
                    BookId = dalBorrow.BookId,
                    BorrowDate = dalBorrow.BorrowDate,
                    ReturnDate = dalBorrow.ReturnDate,
                    DueDate = dalBorrow.DueDate,
                    Book = MapToDomainBook(dalBorrow.Book),
                    // If User is a navigation property, you may need to map it as well
                    //User = MapToDomainUser(dalBorrow.User)
                };

                domainBorrows.Add(domainBorrow);
            }

            return domainBorrows;
        }
    }
}
