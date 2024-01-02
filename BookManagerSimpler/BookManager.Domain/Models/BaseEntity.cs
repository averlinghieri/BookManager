namespace BookManager.Core.Models
{
    public abstract class BaseEntity
    { 
        public int Id { get; set; }
    }

    public abstract class BaseEntityCollection<TEntity> : List<TEntity>
    {
        public int Page { get; set; }
        
        public int PageSize { get; set; }

        public int TotalItems { get; set; }
    }
}
