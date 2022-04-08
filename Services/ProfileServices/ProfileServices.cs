using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Task1.Data;
using Task1.Dtos.ProfileDtos;
using Task1.Models;

namespace Task1.Services.ProfileServices
{
    public class ProfileServices : IProfileServices
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;


        public ProfileServices(DataContext context, IHttpContextAccessor httpContext, IMapper mapper)
        {
            _context = context;
            _httpContext = httpContext;
            _mapper = mapper;
        }

        private int GetUserID() => int.Parse(_httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<string>> DeleteProfile(int id)
        {
            var response = new ServiceResponse<string>();
            try
            {
                var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id == id);

                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == profile.UserId);

                if(profile == null)
                {
                    response.Success = false;
                    response.Message = "profile not found";
                    return response;
                }


                profile.IsDeleted = true;
                // _context.Profiles.Remove(profile);
                // _context.Users.Remove(user);

                await _context.SaveChangesAsync();
                response.Message = "Profile deleted successfully";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetProfileDto>> EditProfile(int id, JsonPatchDocument<Models.Profile> profileUpdates)
        {
            var response = new ServiceResponse<GetProfileDto>();
            
            try
            {
                var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id == id);

                if(profile == null || profile.IsDeleted)
                {
                    response.Success = false;
                    response.Message = "profile not found";
                    return response;
                }

                profileUpdates.ApplyTo(profile);

                await _context.SaveChangesAsync();
                
                response.Data = _mapper.Map<GetProfileDto>(profile);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            

            return response;
        }

        public async Task<ServiceResponse<GetProfileDto>> GetProfile(int id)
        {
             var response = new ServiceResponse<GetProfileDto>();

            try
            {
                var profile = await _context.Profiles.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);

                if(profile == null || profile.IsDeleted)
                {
                    response.Success = false;
                    response.Message = "profile not found";
                    return response;
                }

                response.Data = _mapper.Map<GetProfileDto>(profile);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            
            return response;
        }
    }
}