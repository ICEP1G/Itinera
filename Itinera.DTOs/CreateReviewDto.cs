using System.ComponentModel.DataAnnotations;


namespace Itinera.DTOs
{
    public class CreateReviewDto
    {
        [Required]
        public string ItinerosId { get; set; } = string.Empty;
        [Required]
        [StringLength(300, ErrorMessage = "Review is to small or to large", MinimumLength = 30)]
        public string ReviewDescription { get; set; } = string.Empty;
        public StreamContent? ReviewImageFile { get; set; }
    }
}
