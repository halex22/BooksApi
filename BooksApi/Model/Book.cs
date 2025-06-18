using System;
using System.Collections.Generic;

namespace BooksApi.Model;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Img { get; set; }

    public string? Author { get; set; }

    public DateTime PublishDate { get; set; }

    public bool IsAvailable { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
