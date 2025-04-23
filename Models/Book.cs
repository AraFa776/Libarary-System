using System;
using System.Collections.Generic;

namespace FirstTry.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public int AuthorId { get; set; }

    public int CategoryId { get; set; }

    public int PublisherId { get; set; }

    public string? Isbn { get; set; }

    public string? BookDescription { get; set; }

    public byte[] CoverImage { get; set; } = null!;

    public decimal Price { get; set; }

    public int? Stock { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Publisher Publisher { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
