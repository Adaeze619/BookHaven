namespace BookHaven.Domain.Model
{
    public class BookHavenTag
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public ICollection<Book> Books { get; set; } = new List<Book>();

       // public Guid BookPostId { get; set; }
    }
}