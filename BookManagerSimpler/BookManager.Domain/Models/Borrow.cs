namespace BookManager.Core.Models
{
    public class Borrow : BaseEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

        public DateOnly BorrowDate { get; set; }

        public DateOnly? ReturnDate { get; set; }

        public DateOnly DueDate { get; set; }

        public virtual Book Book { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }

    public class BorrowCollection : BaseEntityCollection<Borrow> { }
}
