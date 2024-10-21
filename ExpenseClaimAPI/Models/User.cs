//Models/User.cs

using System.Collections.Generic;

namespace ExpenseClaimAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Claim> Claims { get; set; } = new List<Claim>();
    }
}