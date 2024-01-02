namespace BookManager.Core.Models
{
    public class MembershipCard : BaseEntity
    {
        public int Id { get; set; }

        public string CardNumber { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }

    public class MembershipCardCollection : BaseEntityCollection<MembershipCard> { }
}
