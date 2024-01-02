namespace BookManager.DAL.DataModels;

public partial class User : BaseDalEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public string? Gender { get; set; }

    public int MembershipId { get; set; }

    public DateOnly SignupDate { get; set; }

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();

    public virtual MembershipCard Membership { get; set; } = null!;
}
