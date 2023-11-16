using BookHaven.Domain.Model;
using BookHaven.Infrastructure.DbContextFolder;
using BookHaven.Infrastructure.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookHaven.Infrastructure.Repository
{
    public class BookHavenRepo : IBookHavenRepo
    {
        private readonly BookHavenDbContext _bookHavenDbContext;

        public BookHavenRepo(BookHavenDbContext bookHavenDbContext)
        {
            _bookHavenDbContext = bookHavenDbContext;
        }


        public async Task<Book> AddAsync(Book book)
        {
            await _bookHavenDbContext.Books.AddAsync(book);
            await _bookHavenDbContext.SaveChangesAsync();
            return book;
        }

        public async Task<IEnumerable<Book>> SearchBooksAysnc(string searchQuery)
        {
            return _bookHavenDbContext.Books.Where(p => p.BookTitle.Contains(searchQuery));
        }

        public async Task<bool> DeleteAsync(Guid isbn)
        {
            var isExisting = await _bookHavenDbContext.Books.FindAsync(isbn);

            if (isExisting != null)
            {
                _bookHavenDbContext.Books.Remove(isExisting);
                await _bookHavenDbContext.SaveChangesAsync();
                return true;

            }
            return false;


        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookHavenDbContext.Books.Include(nameof(Book.Tags)).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var allpurposeget = _bookHavenDbContext.Books.AsQueryable();

            //filtering
            if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
            {
                switch (filterOn.ToLowerInvariant())
                {
                    case "booktitle":
                        allpurposeget = allpurposeget.Where(book => EF.Functions.Like(book.BookTitle, "%" + filterQuery + "%"));
                        break;
                    case "Author":
                        allpurposeget = allpurposeget.Where(book => EF.Functions.Like(book.Author, "%" + filterQuery + "%"));
                        break;
                    case "isbn":
                        allpurposeget = allpurposeget.Where(book => EF.Functions.Like(book.ISBN, "%" + filterQuery + "%"));
                        break;
                }
            }



            //sorting

            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("booktitle", StringComparison.OrdinalIgnoreCase))
                {
                    allpurposeget = isAscending ? allpurposeget.OrderBy(item => item.BookTitle) : allpurposeget.OrderByDescending(item => item.BookTitle);
                }
            }



            //pagination
            var skipResult = (pageNumber - 1) * pageSize;

            return await allpurposeget.Skip(pageNumber).Take(pageSize).ToListAsync();
        }

        public async Task<Book> GetISBNAsync(string ISBN)
        {
            return await _bookHavenDbContext.Books.Include(nameof(Book.Tags))
                .FirstOrDefaultAsync(x => x.ISBN == ISBN);
        }

        public async Task<Book> GetImageAsync(string imageUrlHandle)
        {
            return await _bookHavenDbContext.Books.Include(nameof(Book.Tags))
               .FirstOrDefaultAsync(x => x.ImageUrlHandle == imageUrlHandle);
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            var existingbook = await _bookHavenDbContext.Books.Include(nameof(Book.Tags))
                .FirstOrDefaultAsync(item => item.Id == book.Id);

            if (existingbook != null)
            {

                existingbook.BookTitle = book.BookTitle;

                existingbook.Description = book.Description;
                existingbook.ISBN = book.ISBN;
                existingbook.ImageUrlHandle = book.ImageUrlHandle;
                existingbook.PublishedDate = book.PublishedDate;
                existingbook.Author = book.Author;
                existingbook.Visible = book.Visible;

                if (book.Tags != null && book.Tags.Any())
                {
                    // Delete the existing tags
                    _bookHavenDbContext.BookHavenTags.RemoveRange(existingbook.Tags);

                    // Add new tags
                    book.Tags.ToList().ForEach(x => x.Id = existingbook.Id);
                    await _bookHavenDbContext.BookHavenTags.AddRangeAsync(book.Tags);
                }
            }

            await _bookHavenDbContext.SaveChangesAsync();
            return existingbook;
        }

        public async Task<List<Book>> SearchBooksAsync(string searchQuery)
        {
            try
            {
                var result = await _bookHavenDbContext.Books
                    .Where(u => u.Author.Contains(searchQuery) || u.BookTitle.Contains(searchQuery) || u.ISBN.Contains(searchQuery) || u.Id.ToString().Contains(searchQuery))
                    .Select(u => new Book
                    {
                        Id = u.Id,
                        ISBN = u.ISBN,
                        BookTitle = u.BookTitle,
                        Author = u.Author,

                    })
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            return await _bookHavenDbContext.Books.FindAsync(id);
        }


    }
}

