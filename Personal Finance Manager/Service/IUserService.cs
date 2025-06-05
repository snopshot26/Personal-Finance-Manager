using System.Threading.Tasks;
using Personal_Finance_Manager.Models;

namespace Personal_Finance_Manager.Service
{
    public interface IUserService
    {
        Task<User?> AuthenticateAsync(string username, string password);
        Task<User> RegisterAsync(string username, string password);
    }
}
