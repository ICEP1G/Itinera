using System.ComponentModel.DataAnnotations;


namespace Itinera.DTOs.AuthDtos
{
    /// <summary>
    /// Used when the AccessToken is expired in order to get a new AccessToken and a new RefreshToken 
    /// </summary>
    public class RenewAccessTokenDto
    {
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
