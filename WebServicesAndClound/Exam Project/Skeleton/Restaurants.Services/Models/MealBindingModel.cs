using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurants.Services.Models
{
    public class MealBindingModel
    {

        [Required]
        [MinLength(1)]
        [Display(Name = "name")]
        public string Name { get; set; }

        [Required]
        [Range(0, (double)decimal.MaxValue)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "TypeId")]
        public int TypeId { get; set; }
    }
}