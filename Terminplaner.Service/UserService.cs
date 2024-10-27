using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminplaner.Model.Entities;

namespace Terminplaner.Service
{
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
    }
}
