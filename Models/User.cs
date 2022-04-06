using System;

namespace Task1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; } = DateTime.MinValue;
        public string Gender { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Profile Profile { get; set; }
    }
}