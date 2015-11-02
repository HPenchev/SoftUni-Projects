using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Restaurants.Services.Models;
using Restaurants.Models;

namespace Restaurants.Services.Controllers
{
    [RoutePrefix("api")]
    public class MealsController : BaseApiController
    {
        [HttpPost]
        [Route("meals")]
        public IHttpActionResult CreateMeal([FromBody]CreateMealBindingModel mealModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var type = this.Data.MealTypes.Find(mealModel.TypeId);
            var restaurant = this.Data.Restaurants.Find(mealModel.RestaurantId);

            if (type == null || restaurant == null)
            {
                return this.BadRequest("Invalid type or restaurant id.");
            }

            var userId = this.User.Identity.GetUserId();
            ApplicationUser user = null;

            if (userId != null)
            {
                user = this.Data.Users.Find(userId);
            }

            if (user == null || userId != restaurant.OwnerId)
            {
                return this.Unauthorized();
            }

            var meal = new Meal()
            {
                Name = mealModel.Name,
                Price = mealModel.Price,
                RestaurantId = mealModel.RestaurantId,
                Restaurant = restaurant,
                TypeId = mealModel.TypeId,
                Type = type
            };

            this.Data.Meals.Add(meal);
            this.Data.SaveChanges();

            var mealView = new MealViewModel()
            {
                Id = meal.Id,
                Name = meal.Name,
                Price = meal.Price,
                Type = meal.Type.Name
            };

            return this.CreatedAtRoute(
                    "DefaultApi",
                    new { id = meal.Id, controller = "meals" },
                    mealView);
        }

        [HttpPut]
        [Route("meals/{id}")]
        public IHttpActionResult EditMeal([FromUri]int id, [FromBody]MealBindingModel mealModel)
        {
            var meal = this.Data.Meals.Find(id);

            if (meal == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var type = this.Data.MealTypes.Find(mealModel.TypeId);

            if (type == null)
            {
                return this.BadRequest("Invalid type id");
            }

            var userId = this.User.Identity.GetUserId();
            ApplicationUser user = null;

            if (userId != null)
            {
                user = this.Data.Users.Find(userId);
            }

            if (user == null || userId != meal.Restaurant.OwnerId)
            {
                return this.Unauthorized();
            }

            meal.Name = mealModel.Name;
            meal.Price = mealModel.Price;
            meal.TypeId = mealModel.TypeId;
            meal.Type = type;

            this.Data.Meals.Update(meal);
            this.Data.SaveChanges();

            var mealView = new MealViewModel()
            {
                Id = meal.Id,
                Name = meal.Name,
                Price = meal.Price,
                Type = meal.Type.Name
            };

            return this.Ok(mealView);
        }

        [HttpDelete]
        [Route("meals/{id}")]
        public IHttpActionResult DeleteMeal([FromUri]int id)
        {
            var meal = this.Data.Meals.Find(id);

            if (meal == null)
            {
                return this.NotFound();
            }

            var userId = this.User.Identity.GetUserId();
            ApplicationUser user = null;

            if (userId != null)
            {
                user = this.Data.Users.Find(userId);
            }

            if (user == null || userId != meal.Restaurant.OwnerId)
            {
                return this.Unauthorized();
            }

            this.Data.Meals.Delete(meal);
            this.Data.SaveChanges();

            return this.Ok(new
                {
                    Message = "Meal #" + meal.Id + " deleted."
                });
        }

        [HttpPost]
        [Route("meals/{id}/order")]
        public IHttpActionResult OrderMeal(
            [FromUri]int id, 
            [FromBody]OrderBindingModel orderModel)
        {
            var meal = this.Data.Meals.Find(id);

            if (meal == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

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

            var order = new Order()
            {
                MealId = id,
                Meal = meal,
                Quantity = orderModel.Quantity,
                UserId = userId,
                User = user,
                OrderStatus = OrderStatus.Pending,
                CreatedOn = DateTime.Now
            };

            this.Data.Orders.Add(order);
            this.Data.SaveChanges();

            return this.Ok();
            }
    }
}