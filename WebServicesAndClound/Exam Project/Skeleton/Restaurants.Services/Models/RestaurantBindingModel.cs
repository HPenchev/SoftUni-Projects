using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurants.Services.Models
{
    public class RestaurantBindingModel
    {
        [Required]
        [MinLength(1)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "TownId")]
        public int TownId { get; set; }
    }
}