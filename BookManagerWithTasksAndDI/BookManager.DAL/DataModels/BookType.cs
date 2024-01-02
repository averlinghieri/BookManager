namespace BookManager.DAL.DataModels;

public partial class BookType : BaseDalEntity
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
