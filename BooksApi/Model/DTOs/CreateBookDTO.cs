namespace BooksApi.Model.DTOs
{
    public class CreateBookDTO
    {
        public string Title { get; set; }

        public string? Img { get; set; }

        public string? Author { get; set; }

        public DateTime PublishDate { get; set; }

        public int CategoryId { get; set; }
    }
}
