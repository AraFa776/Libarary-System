using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FirstTry.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string AuthorsName { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
