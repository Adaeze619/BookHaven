using BookHaven.Infrastructure.DbContextFolder;
using BookHaven.Infrastructure.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookHaven.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;

        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public async Task<IEnumerable<IdentityUser>> GetAllUsers()
        {
            var users = await _userDbContext.Users.ToListAsync();
            //Checking for the superAdmin, but wont display it in the ui
            var superAdminUser = await _userDbContext.Users.FirstOrDefaultAsync(
                x => x.Email == "superadmin@library.com");

            if (superAdminUser is not null)
            {
                users.Remove(superAdminUser);
            }
            return users;
        }
    }
}
