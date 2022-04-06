using System.Threading.Tasks;
using Task1.Dtos;
using Task1.Models;

namespace Task1.Auth
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}