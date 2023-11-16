using BookHaven.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookHaven.Infrastructure.DbContextFolder
{
    public class BookHavenDbContext : DbContext
    {
        public BookHavenDbContext(DbContextOptions<BookHavenDbContext> options) : base(options)
        {
        }


        public DbSet<Book> Books { get; set; }
        public DbSet<BookHavenComment> BookHavenComments { get; set; }
        public DbSet<BookHavenLike> BookHavenLikes { get; set; }
        public DbSet<BookHavenTag> BookHavenTags { get; set; }

    }
}