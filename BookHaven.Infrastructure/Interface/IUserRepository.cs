using Microsoft.AspNetCore.Identity;

namespace BookHaven.Infrastructure.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAllUsers();
    }
}
