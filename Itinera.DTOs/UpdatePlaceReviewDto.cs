using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs
{
    public class UpdatePlaceReviewDto
    {
        [Required]
        [StringLength(300, ErrorMessage = "Review is to small or to large", MinimumLength = 30)]
        public string ReviewDescription { get; set; } = string.Empty;
        public StreamContent? ReviewImageFile { get; set; }
    }
}
