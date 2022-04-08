using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Task1.Dtos.ProfileDtos;
using Task1.Models;
using Task1.Services.ProfileServices;

namespace Task1.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileServices _profileServices;

        public ProfileController(IProfileServices profileServices)
        {
            _profileServices = profileServices;
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ServiceResponse<GetProfileDto>>> EditProfile(int id,JsonPatchDocument<Profile> profileUpdates)
        {
            var response = await _profileServices.EditProfile(id, profileUpdates);
            if(response.Success)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteProfile(int id)
        {
            var response = await _profileServices.DeleteProfile(id);
            if(response.Success)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetProfileDto>>> GetProfile(int id)
        {
            var response = await _profileServices.GetProfile(id);
            if(response.Success)
                return Ok(response);
            return BadRequest(response);
        }
    }
}