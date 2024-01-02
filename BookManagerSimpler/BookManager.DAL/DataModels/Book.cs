namespace BookManager.DAL.DataModels;

public partial class Book : BaseDalEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? PageCount { get; set; }

    public int AuthorId { get; set; }

    public int TypeId { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();

    public virtual BookType Type { get; set; } = null!;
}
