using System;
using System.Collections.Generic;

namespace FirstTry.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string AuthorsName { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
