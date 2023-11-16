namespace BookHaven.Domain.Model
{
    public class BookHavenComment
    {

        public Guid Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public Guid BookPostId { get; set; }

        public Guid UserId { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
