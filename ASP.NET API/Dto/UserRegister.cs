using System.ComponentModel.DataAnnotations;

namespace ASP.NET_API.Dto
{
    public class UserRegister
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
