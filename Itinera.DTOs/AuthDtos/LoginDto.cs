using System.ComponentModel.DataAnnotations;


namespace Itinera.DTOs.AuthDtos
{
    public class LoginDto
    {
        [Required]
        public string Login { get; set; } = string.Empty; // Can be Email or Phone number
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
