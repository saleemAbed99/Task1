using System;

namespace Task1.Dtos.UserDtos
{
    public class GetUserDto
    {
        
        public string Username { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; } = DateTime.MinValue;
        public string Gender { get; set; }
    }
}