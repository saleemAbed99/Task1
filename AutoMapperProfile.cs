using AutoMapper;
using Task1.Dtos;
using Task1.Dtos.ProfileDtos;
using Task1.Dtos.UserDtos;
using Task1.Models;

namespace Task1
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterUserDto, User>();
            CreateMap<Models.Profile, GetProfileDto>();
            CreateMap<GetProfileDto, Models.Profile>();
            CreateMap<User, GetUserDto>();
            CreateMap<GetUserDto, User>();
        }
    }
}