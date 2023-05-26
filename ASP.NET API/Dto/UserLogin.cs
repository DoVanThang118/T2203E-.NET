using System.ComponentModel.DataAnnotations;

namespace ASP.NET_API.Dto
{
    public class UserLogin
    {
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
