using System.ComponentModel.DataAnnotations;


namespace Itinera.DTOs.AuthDtos
{
    /// <summary>
    /// Represent the response body from a sucessfull authentication from the Itineros
    /// </summary>
    public class TokenResponseDto
    {
        [Required]
        public string AccessToken { get; set; } = string.Empty;
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
