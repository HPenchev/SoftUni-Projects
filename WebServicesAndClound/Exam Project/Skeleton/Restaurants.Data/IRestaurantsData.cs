using Restauranteur.Models;
using Restaurants.Data.Repositories;
using Restaurants.Models;

namespace Restaurants.Data
{
    public interface IRestaurantsData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Meal> Meals { get; }

        IRepository<MealType> MealTypes { get; }

        IRepository<Order> Orders { get; }

        IRepository<Rating> Ratings { get; }

        IRepository<Restaurant> Restaurants{ get; }

        IRepository<Town> Towns { get; }

        int SaveChanges();
    }
}