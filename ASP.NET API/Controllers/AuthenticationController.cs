using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using BCrypt.Net;
using ASP.NET_API.Dto;
using ASP.NET_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace t22netapi.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly AspNetApiContext _context;
        public AuthenticationController(AspNetApiContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("/register")]
        public IActionResult Register(User user)
        {
            var hashed = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _context.Users.Add(new ASP.NET_API.Entities.User { Email = user.Email, Name = user.Name, Password = hashed });
            _context.SaveChanges();
            return Ok(new UserData { Name = user.Name, Email = user.Email });
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login(string email, string passwordHash)
        {
            var user = _context.Users.Where(u=> u.Email == email).FirstOrDefault();
            if (user == null) return NotFound();
            bool verified = BCrypt.Net.BCrypt.Verify("Pa$$w0rd", passwordHash);
            if (verified)
            {
                return BadRequest();
            }
            return Ok(user);
        }

    }
}