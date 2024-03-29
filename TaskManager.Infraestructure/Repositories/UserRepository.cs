using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Infraestructure.Data;

namespace TaskManager.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApiDbContext _context;

        public UserRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task Create(User user)
        {
               _context.Users.Add(user);
            await _context.SaveChangesAsync();

             
        }


    }
}
