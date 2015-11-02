using System.ComponentModel.DataAnnotations;

namespace Restaurants.Services.Models
{
    public class RatingBindingModel
    {
        [Required]
        [Range(1, 10)]
        [Display(Name = "Stars")]
        public int Stars { get; set; }
    }
}