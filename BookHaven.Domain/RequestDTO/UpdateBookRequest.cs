namespace BookHaven.Domain.RequestDTO
{
    public class UpdateBookRequest
    {
        public string BookTitle { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
    }
}
