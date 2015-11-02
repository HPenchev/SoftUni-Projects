using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Restaurants.Models;
using Restaurants.Services.Models;

namespace Restaurants.Services.Controllers
{
    [RoutePrefix("api")]
    public class OrdersController : BaseApiController
    {
        [HttpGet]
        [Route("orders")]
        public IHttpActionResult GetPendingOrders(
            [FromUri]int startPage,
            [FromUri]int limit,
            [FromUri]int? mealId = null)
        {
            var userId = this.User.Identity.GetUserId();
            ApplicationUser user = null;

            if (userId != null)
            {
                user = this.Data.Users.Find(userId);
            }

            if (user == null)
            {
                return this.Unauthorized();
            }

            var orders = this.Data.Orders.All()
                .Where(o => o.UserId == userId && o.OrderStatus == OrderStatus.Pending)
                .OrderByDescending(o => o.CreatedOn);

            if (mealId != null)
            {
                orders = orders
                    .Where(o => o.MealId == mealId)
                    .OrderByDescending(o => o.CreatedOn);
            }

            int skippedOrders = startPage * limit;

            var resultOrders = orders
                .Skip(skippedOrders)
                .Take(limit)
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    Meal = new MealViewModel()
                    {
                        Id = o.MealId,
                        Name = o.Meal.Name,
                        Price = o.Meal.Price,
                        Type = o.Meal.Type.Name
                    },
                    Quantity = o.Quantity,
                    Status = o.OrderStatus,
                    CreatedOn = o.CreatedOn
                });

            return this.Ok(resultOrders);
        }
    }
}