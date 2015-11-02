using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurants.Services.Models
{
    public class OrderBindingModel
    {
        [Required]
        [Display(Name = "Quantity")]
        [Range(1d, (double)int.MaxValue)]
        public int Quantity { get; set; }
    }
}