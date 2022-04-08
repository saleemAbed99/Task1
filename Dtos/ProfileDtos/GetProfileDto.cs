using Task1.Dtos.UserDtos;
using Task1.Models;

namespace Task1.Dtos.ProfileDtos
{
    public class GetProfileDto
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Address { get; set; }
        public string Bio { get; set; }
        public GetUserDto User { get; set; }
    }
}