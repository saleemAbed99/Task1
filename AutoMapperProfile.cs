using AutoMapper;
using Task1.Dtos;
using Task1.Models;

namespace Task1
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterUserDto, User>();
        }
    }
}