namespace BookHaven.Domain.Model
{
    public class Book
    {
        public Guid Id { get; set; }
        public string BookTitle { get; set; } = string.Empty;
     
        public string Description { get; set; } = string.Empty;
        public string ImageUrlHandle { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; } = string.Empty;
        public bool Visible { get; set; }

        // Navigation Property
        public ICollection<BookHavenTag> Tags { get; set; } = new List<BookHavenTag>();
        public ICollection<BookHavenLike> Likes { get; set; } = new List<BookHavenLike>();
        public ICollection<BookHavenComment> Comments { get; set; } = new List<BookHavenComment>();
    }
}
