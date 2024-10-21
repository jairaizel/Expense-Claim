// Models/Claim.cs
using System;

namespace ExpenseClaimAPI.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Status { get; set; } = "Pending";  // Default status
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public string Department { get; set; } = string.Empty;
        public User? User { get; set; }

        // New field for storing PDF documents as BLOB
        public byte[]? Document { get; set; } 
    }
}
