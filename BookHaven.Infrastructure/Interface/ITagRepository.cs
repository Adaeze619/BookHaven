using BookHaven.Domain.Model;

namespace BookHaven.Infrastructure.Interface
{

    public interface ITagRepository
        {
            Task<IEnumerable<BookHavenTag>> GetAllAsync();
            Task<BookHavenTag?> GetAsync(Guid id);
            Task<BookHavenTag> AddAsync(BookHavenTag tag);
            Task<BookHavenTag?> UpdateAsync(BookHavenTag tag);
            Task<BookHavenTag?> DeleteAsync(Guid id);
        }
    
}
