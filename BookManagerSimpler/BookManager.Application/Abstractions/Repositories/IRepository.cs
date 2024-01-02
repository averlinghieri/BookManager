using BookManager.Core.Models;

namespace BookManager.Application.Abstractions.Repositories
{
    public interface IRepository<TEntity, TEntityCollection>
        where TEntity : BaseEntity, new()
        where TEntityCollection : BaseEntityCollection<TEntity>, new()
    {
    }
}
