using Personal_Finance_Manager.Models;
using Personal_Finance_Manager.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidUserDataException("Username and password are required");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                throw new InvalidCredentialsException();
            }

            return user;
        }

        public async Task<User> RegisterAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidUserDataException("Username and password are required");
            }

            if (await _context.Users.AnyAsync(u => u.Username == username))
            {
                throw new UserAlreadyExistsException(username);
            }

            var user = new User { Username = username, Password = password };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
