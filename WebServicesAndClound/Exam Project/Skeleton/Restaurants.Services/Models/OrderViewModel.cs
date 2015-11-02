using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurants.Models;

namespace Restaurants.Services.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public MealViewModel  Meal { get; set; }

        public int Quantity { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}