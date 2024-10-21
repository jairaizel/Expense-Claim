// Services/ClaimService.cs
using ExpenseClaimAPI.Models;
using ExpenseClaimAPI.Data;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseClaimAPI.Services
{
    public class ClaimService
    {
        private readonly ApplicationDbContext _context;

        public ClaimService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Claim> GetAll()
        {
            return _context.Claims.ToList();
        }

        public Claim? GetById(int id)
        {
            return _context.Claims.Find(id);
        }

        public Claim Create(Claim claim)
        {
            _context.Claims.Add(claim);
            _context.SaveChanges();
            return claim;
        }

        public void Update(Claim claim)
        {
            _context.Claims.Update(claim);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim != null)
            {
                _context.Claims.Remove(claim);
                _context.SaveChanges();
            }
        }
    }
}
