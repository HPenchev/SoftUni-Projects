using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurants.Services.Models
{
    public class CreateMealBindingModel : MealBindingModel
    {
        [Required]
        [Display(Name = "RestaurantId")]
        public int RestaurantId { get; set; }
    }
}