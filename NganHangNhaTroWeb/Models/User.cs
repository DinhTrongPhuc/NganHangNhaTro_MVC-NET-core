namespace NganHangNhaTroWeb.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }  // User, Owner, Admin
    }
}
