// Services/UserService.cs
using ExpenseClaimAPI.Models;
using ExpenseClaimAPI.Data;
using System.Linq;

namespace ExpenseClaimAPI.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User? GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public User? Authenticate(string username, string password)
        {
            return _context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
