using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Task1.Auth;
using Task1.Dtos;
using Task1.Dtos.UserDtos;
using Task1.Models;

namespace Task1.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(LoginUserDto request) 
        {
            var response = await _authRepo.Login(request.Username, request.Password);

            if(!response.Success) 
                return BadRequest(response);

            return Ok(response);
        }
        
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(RegisterUserDto user) 
        {
            var response = await _authRepo.Register(
                new User {
                    Username = user.Username,
                    FullName = user.FullName,
                    DOB = user.DOB,
                    Gender = user.Gender
                },
                user.password
            );
        
            if(!response.Success) 
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPatch("Update")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> UpdateUser(JsonPatchDocument<User> userUpdates)
        {
            var response = await _authRepo.UpdateUser(userUpdates);
            if(response.Success)
                return Ok(response);
            return BadRequest(response);
        }
    }
}