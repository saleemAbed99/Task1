using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Task1.Dtos.ProfileDtos;
using Task1.Models;

namespace Task1.Services.ProfileServices
{
    public interface IProfileServices
    {
         Task<ServiceResponse<GetProfileDto>> EditProfile(int id, JsonPatchDocument<Profile> profileUpdates);
         Task<ServiceResponse<GetProfileDto>> GetProfile(int id);
         Task<ServiceResponse<string>> DeleteProfile(int id);
    }
}