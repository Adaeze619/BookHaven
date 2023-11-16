using BookHaven.Domain.Model;
using BookHaven.Infrastructure.DbContextFolder;
using BookHaven.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookHaven.Infrastructure.Repository
{
    public class TagRepository : ITagRepository
	{
		private readonly BookHavenDbContext _bookHavenDbContext;

		public TagRepository(BookHavenDbContext bookHavenDbContext)
		{
			_bookHavenDbContext = bookHavenDbContext;
		}
		public async Task<BookHavenTag> AddAsync(BookHavenTag tag)
		{

			await _bookHavenDbContext.BookHavenTags.AddAsync(tag);
			await _bookHavenDbContext.SaveChangesAsync();
			return tag;
		}

		public async Task<BookHavenTag?> DeleteAsync(Guid id)
		{
			var existingTag = await _bookHavenDbContext.BookHavenTags.FindAsync(id);
			if (existingTag != null)
			{
				_bookHavenDbContext.BookHavenTags.Remove(existingTag);
				await _bookHavenDbContext.SaveChangesAsync();
				return existingTag;
			}
			return null;
		}

		public async Task<IEnumerable<BookHavenTag>> GetAllAsync()
		{
			return await _bookHavenDbContext.BookHavenTags.ToListAsync();
		}

		public Task<BookHavenTag?> GetAsync(Guid id)
		{
			return _bookHavenDbContext.BookHavenTags.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<BookHavenTag?> UpdateAsync(BookHavenTag tag)
		{
			var existingTag = await _bookHavenDbContext.BookHavenTags.FindAsync(tag.Id);
			if (existingTag != null)
			{
				existingTag.Name = tag.Name;
				existingTag.DisplayName = tag.DisplayName;

				await _bookHavenDbContext.SaveChangesAsync();
				return existingTag;
			}

			return null;
		}
	}
}
