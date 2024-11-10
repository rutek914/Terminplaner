using Microsoft.EntityFrameworkCore;
using Terminplaner.Model.Entities;

namespace Terminplaner.Service {
    public class UserService
    {
        private readonly TerminplanerDbContext _context;

        public UserService(TerminplanerDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task CreateNewUserAsync(User user) {
            await _context.Users.AddAsync(user);
        }

        public async Task DeleteUserAsync(User user) {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
