using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurants.Services.Models
{
    public class RestaurantViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float? Rating { get; set; }

        public TownViewModel Town { get; set; }
    }
}