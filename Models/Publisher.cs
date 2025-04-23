using System;
using System.Collections.Generic;

namespace FirstTry.Models;

public partial class Publisher
{
    public int PublisherId { get; set; }

    public string PublisherName { get; set; } = null!;

    public string? PublisherAddress { get; set; }

    public string Website { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
