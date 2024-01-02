using BookManager.Application.Abstractions.Repositories;
using BookManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Dal = BookManager.DAL.DataModels;
using Domain = BookManager.Core.Models;

namespace BookManager.DAL.Repositories
{
    public class AuthorRepository : BaseRepository<Domain.Author, Domain.AuthorCollection, Dal.Author>, IAuthorRepository
    {
        public AuthorRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<Author>> GetAuthorsByNameAsync(string name)
        {
            using (var context = this.CreateContext())
            {
                try
                {
                    var dbAuthors = await context.Authors
                        .Where(author => author.Name.Contains(name.ToLower())).ToListAsync();

                    if (dbAuthors == null)
                        return null;

                    List<Domain.Author> domainAuthors = new List<Domain.Author>();

                    foreach (var dbAuthor in dbAuthors)
                    {
                        var domainAuthor = base.MapToDomainAuthor(dbAuthor);

                        domainAuthors.Add(domainAuthor);
                    }

                    return domainAuthors;
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
