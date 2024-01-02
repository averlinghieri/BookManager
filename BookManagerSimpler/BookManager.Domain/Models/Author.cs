﻿namespace BookManager.Core.Models
{
    public class Author : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }

    public class AuthorCollection : BaseEntityCollection<Author> { }
}
