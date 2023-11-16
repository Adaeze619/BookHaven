namespace BookHaven.Domain.Model
{
    public class BookHavenLike
    {
        public Guid Id { get; set; }
        public Guid BookPostId { get; set; }
        public Guid UserId { get; set; }
    }
}
