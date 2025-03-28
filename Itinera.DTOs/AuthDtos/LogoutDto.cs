using System.ComponentModel.DataAnnotations;


namespace Itinera.DTOs.AuthDtos
{
    /// <summary>
    /// Used when the Itineros want to be disconnected in order to revoke the RefreshToken
    /// </summary>
    public class LogoutDto
    {
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
