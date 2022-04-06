using System;

namespace Task1.Dtos
{
    public class RegisterUserDto
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; } = DateTime.MinValue;
        public string Gender { get; set; }
        public string password { get; set; }
    }
}