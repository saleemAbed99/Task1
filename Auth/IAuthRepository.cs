using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Task1.Dtos;
using Task1.Dtos.UserDtos;
using Task1.Models;

namespace Task1.Auth
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<ServiceResponse<GetUserDto>> UpdateUser(JsonPatchDocument<User> userUpdates);
        Task<bool> UserExists(string username);
    }
}