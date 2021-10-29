using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Auth.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _context;

        public UserRepository(AuthDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public User Get(string username, string password)
        {
            return _context.Users
                .Include(u => u.Roles)
                .ThenInclude(r => r.Permissions)
                .FirstOrDefault(u =>
                    u.Username.Equals(username) &&
                    u.HashedPassword.Equals(password));
        }
    }
}
