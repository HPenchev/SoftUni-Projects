using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Restaurants.Services.Models;
using Restaurants.Models;

namespace Restaurants.Services.Controllers
{
    [RoutePrefix("api")]
    public class RestaurantsController : BaseApiController
    {
        [HttpGet]
        [Route("restaurants")]
        public IHttpActionResult GetAllRestauransByTown([FromUri]int townId)
        {
            var town = this.Data.Towns.Find(townId);

            if (town == null)
            {
                return this.NotFound();
            }

            var townView = new TownViewModel()
            {
                Id = town.Id,
                Name = town.Name
            };

            var restaurants = town
                .Restaurants
                //.OrderByDescending(r => r.Ratings.Select(rt => rt.Stars).Average())
                //.ThenBy(r => r.Name)
                .Select(r => new RestaurantViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Rating = r.Ratings.Any() ? 
                    (float?)r.Ratings.Select(rt => rt.Stars).Average() : 
                    null,
                    Town = townView
                })
                .OrderByDescending(rv => rv.Rating)
                .ThenBy(rv => rv.Name); ;

            // To check how to sort before materialize the query by solving the empty sequence problem???

            return this.Ok(restaurants);
        }

        [HttpPost]
        [Route("restaurants")]
        public IHttpActionResult CreateNewRestaurant(
            [FromBody]RestaurantBindingModel restaurantModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var town = this.Data.Towns.Find(restaurantModel.TownId);

            if (town == null)
            {
                return this.BadRequest("Invalid town id");
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

            var restaurant = new Restaurant()
            {
                Name = restaurantModel.Name,
                TownId = restaurantModel.TownId,
                Town = town,
                OwnerId = userId,
                Owner = user
            };

            this.Data.Restaurants.Add(restaurant);
            this.Data.SaveChanges();

            var townView = new TownViewModel()
            {
                Id = town.Id,
                Name = town.Name
            };

            var restaurantView = new RestaurantViewModel()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Rating = null,
                Town = townView
            };

            //var result = new System.Web.Mvc.ContentResult
            //{
            //    ContentType = "text/plain",
            //    Content = JsonConvert.SerializeObject(restaurantView, new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() }),
            //    ContentEncoding = Encoding.UTF8
            //};

            return this.CreatedAtRoute(
                    "DefaultApi",
                    new { id = restaurant.Id, controller = "restaurants" },
                    restaurantView);
        }

        [HttpPost]
        [Route("restaurants/{id}/rate")]
        public IHttpActionResult RateARestaurant(
            [FromUri]int id, 
            [FromBody]RatingBindingModel ratingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var restaurant = this.Data.Restaurants.Find(id);

            if (restaurant == null)
            {
                return this.NotFound();
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

            if (userId == restaurant.OwnerId)
            {
                return this.BadRequest("User can't rate his own restaurant");
            }

            var rating = this.Data.Ratings.All()
                .Where(rt => rt.RestaurantId == restaurant.Id && rt.UserId == userId)
                .FirstOrDefault();

            if (rating == null)
            {
                rating = new Rating()
                {
                    Stars = ratingModel.Stars,
                    User = user,
                    UserId = userId,
                    Restaurant = restaurant,
                    RestaurantId = restaurant.Id
                };

                this.Data.Ratings.Add(rating);
            }
            else
            {
                rating.Stars = ratingModel.Stars;
                this.Data.Ratings.Update(rating);
            }

            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        [Route("restaurants/{id}/meals")]
        public IHttpActionResult GetMeals([FromUri]int id)
        {
            var restaurant = this.Data.Restaurants.Find(id);

            if (restaurant == null)
            {
                return this.NotFound();
            }

            var meals = restaurant.Meals
                .OrderBy(m => m.Type.Order)
                .ThenBy(m => m.Name)
                .Select(m => new MealViewModel()
                {
                    Id = m.Id,
                    Name = m.Name,
                    Price = m.Price,
                    Type = m.Type.Name
                });

            return this.Ok(meals);
        }        
    }
}