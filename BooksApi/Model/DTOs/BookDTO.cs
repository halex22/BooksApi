using BooksApi.Model.ViewModel;

namespace BooksApi.Model.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Img { get; set; }

        public string? Author { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsAvailable { get; set; }

        public virtual CategoryDTO Category { get; set; }
    }
}
