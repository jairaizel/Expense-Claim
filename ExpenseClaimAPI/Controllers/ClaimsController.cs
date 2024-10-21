// Controllers/ClaimsController.cs
using Microsoft.AspNetCore.Mvc;
using ExpenseClaimAPI.Models;
using ExpenseClaimAPI.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;  // To handle file uploads
using System.IO;
using System.Linq;
using System;

namespace ExpenseClaimAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly ClaimService _claimService;
        private readonly UserService _userService;

        public ClaimsController(ClaimService claimService, UserService userService)
        {
            _claimService = claimService;
            _userService = userService;
        }

        // GET: api/claims
        [HttpGet]
        public ActionResult<IEnumerable<Claim>> GetAll()
        {
            return Ok(_claimService.GetAll());
        }

        // POST: api/claims
        [HttpPost]
        public IActionResult Create([FromForm] string description, [FromForm] decimal amount, [FromForm] int userId, [FromForm] IFormFile document)
        {
            // Check if user exists
            var user = _userService.GetById(userId);
            if (user == null)
            {
                return BadRequest(new { message = "Invalid user" });
            }

            // Convert the uploaded document to a byte array for storing as BLOB
            byte[] documentData = null;
            if (document != null)
            {
                using (var ms = new MemoryStream())
                {
                    document.CopyTo(ms);
                    documentData = ms.ToArray();
                }
            }

            // Create a new claim
            var claim = new Claim
            {
                Description = description,
                Amount = amount,
                UserId = userId,
                Document = documentData,
                Department = user.Department,
                Status = "Pending",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };

            // Save the claim
            var newClaim = _claimService.Create(claim);

            return CreatedAtAction(nameof(GetById), new { id = newClaim.Id }, newClaim);
        }

        // GET: api/claims/{id}
        [HttpGet("{id}")]
        public ActionResult<Claim> GetById(int id)
        {
            var claim = _claimService.GetById(id);
            if (claim == null)
                return NotFound();

            return Ok(claim);
        }
    }
}
