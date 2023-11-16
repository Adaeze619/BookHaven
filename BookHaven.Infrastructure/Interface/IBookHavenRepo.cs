using BookHaven.Domain.Model;
using System.IO.Pipelines;

namespace BookHaven.Infrastructure.Interface
{
    public interface IBookHavenRepo
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<IEnumerable<Book>> GetAllAsync(string? filterOn, string? filterQuery, string? sortBy, bool isAscending, int pageNumber, int pageSize);
        Task<Book> GetISBNAsync(string ISBN);
        Task<Book> GetImageAsync(string urlHandle);
        Task<Book> AddAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task<bool> DeleteAsync(Guid isbn);
        Task<List<Book>> SearchBooksAsync(string searchQuery);

        Task<Book> GetBookByIdAsync(Guid id);
        //Task<Book> GetBookByIdAsync(Guid id);
    }
}
