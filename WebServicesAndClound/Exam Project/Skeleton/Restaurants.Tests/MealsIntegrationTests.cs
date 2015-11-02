using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Owin.Testing;
using Owin;
using Restaurants.Services;
using Restaurants.Data;
using Restaurants.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Restauranteur.Models;
using System.Collections.Generic;
using System.Net;

namespace Restaurants.Tests
{

    [TestClass]
    public class MealsIntegrationTests
    {
        private TestServer httpTestServer;
        private HttpClient httpClient;

        [TestInitialize]
        public void TestInit()
        {
            this.httpTestServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                appBuilder.UseWebApi(config);
            });

            this.httpClient = httpTestServer.HttpClient;

            var context = new RestaurantsContext();
            context.Database.Delete();
            context.Database.Create();
            this.SeedDatabase();
        }

        [TestMethod]
        public void EditMeal_WhenDataIsValid_ShouldReturnOkAndUpdateMeal()
        {
            var loginData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", "pesho"),
                new KeyValuePair<string, string>("password", "123456"),
                new KeyValuePair<string, string>("grant_type", "password")
            });

            var response = httpClient.PostAsync("/api/account/login", loginData).Result;

            var token = response.Content.ReadAsAsync<LoginDto>().Result.Access_Token;

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var context = new RestaurantsContext();
            int updatedTypeId = context.MealTypes.First(mt => mt.Name == "Updated Type").Id;
            int mealToEditId = context.Meals.First().Id;

            var updateMealData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "Updated Name"),
                new KeyValuePair<string, string>("Price", "11"),
                new KeyValuePair<string, string>("typeId", updatedTypeId.ToString())
            });

            var responsePost = 
                httpClient.PutAsync("api/meals/" + mealToEditId, updateMealData).Result;

            Assert.AreEqual(HttpStatusCode.OK, responsePost.StatusCode);
        }

        private void SeedDatabase()
        {
            var context = new RestaurantsContext();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            var user1 = new ApplicationUser()
            {
                UserName = "gosho",
               
                Email = "gosho@abv.bg"
            };

            var user2 = new ApplicationUser()
            {
                UserName = "gosho",
                
                Email = "gosho@abv.bg"
            };

            var result = userManager.CreateAsync(user1, "123456").Result;
            result = userManager.CreateAsync(user2, "123456").Result;

            context.SaveChanges();

            var town = new Town()
            {
                Name = "Test Town"
            };

            context.Towns.Add(town);
            context.SaveChanges();

            var restaurant = new Restaurant()
            {
                Name = "Test Restaurant",
                Owner = user1,
                OwnerId = user1.Id,
                Town = town,
                TownId = town.Id
            };

            context.Restaurants.Add(restaurant);
            context.SaveChanges();
            
            var type = new MealType()
            {
                Name = "Test Type",
                Order = 0
            };

            var typeForUpdate = new MealType()
            {
                Name = "Updated Type",
                Order = 1
            };

            context.MealTypes.Add(type);
            context.MealTypes.Add(typeForUpdate);
            context.SaveChanges();

            var meal = new Meal()
            {
                Name = "Test Meal",
                Price = 10m,
                Restaurant = restaurant,
                RestaurantId = restaurant.Id,
                Type = type,
                TypeId = type.Id
            };

            context.Meals.Add(meal);
            context.SaveChanges();
        }

        private class LoginDto
        {
            public string Access_Token { get; set; }
        }
    }
}
