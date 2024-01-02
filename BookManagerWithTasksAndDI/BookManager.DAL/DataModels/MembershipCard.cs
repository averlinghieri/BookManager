namespace BookManager.DAL.DataModels;

public partial class MembershipCard : BaseDalEntity
{
    public int Id { get; set; }

    public string CardNumber { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
