using Microsoft.AspNetCore.Http;

namespace BookHaven.Infrastructure.Interface
{
    public interface IImageRepository
    {
        Task<string> UploadAsync(IFormFile file);
    }
}