using BookHaven.Infrastructure.Interface;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace BookHaven.Infrastructure.Repository
{
    public class ImageRepository : IImageRepository
    {

        private readonly Account _account;
        private readonly IConfiguration _configuration;

        public ImageRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _account = new Account(
                configuration.GetSection("Cloudinary")["CloudName"],
                configuration.GetSection("Cloudinary")["ApiKey"],
                configuration.GetSection("Cloudinary")["ApiSecret"]);

        }
        public async Task<string> UploadAsync(IFormFile file)
        {
            var client = new Cloudinary(_account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DisplayName = file.FileName
            };
            var uploadResult = await client.UploadAsync(uploadParams);

            if (uploadResult != null && uploadResult.StatusCode == HttpStatusCode.OK)
            {
                return uploadResult.SecureUri.ToString();
            }
            return null;
        }
    }
}

