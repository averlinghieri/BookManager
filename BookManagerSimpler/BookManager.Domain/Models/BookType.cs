namespace BookManager.Core.Models
{
    public class BookType : BaseEntity
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }

    public class BookTypeCollection : BaseEntityCollection<BookType> { }
}
