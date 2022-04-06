namespace Task1.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public byte[] Picture { get; set; }
        public string Address { get; set; }
        public string Bio { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}