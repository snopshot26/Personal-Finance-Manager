using Personal_Finance_Manager.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Personal_Finance_Manager.Service
{
    public class UserService : IUserService
    {
        private readonly FinanceContext _context;

        public UserService(FinanceContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        public async Task<User> RegisterAsync(string username, string password)
        {
            var user = new User { Username = username, Password = password };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
