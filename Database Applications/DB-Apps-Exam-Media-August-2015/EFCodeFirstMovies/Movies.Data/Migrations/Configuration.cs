using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public sealed class Configuration : DbMigrationsConfiguration<MoviesEntity>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = true;
        ContextKey = "MoviesEntity";
    }

    protected override void Seed(MoviesEntity context)
    {
        // We save changes after adding each entity to make sure some entities are added even if rest of them fail.
        SeedCountries(context);
        SeedUsers(context);
        SeedMovies(context);
        SeedUsersFavouriteMovies(context);
        SeedRatings(context);
    }

    private static void SeedCountries(MoviesEntity context)
    {
        var jsonCountries = File.ReadAllText("..//..//..//..//data//countries.json");

        var countries = JsonConvert.DeserializeObject<HashSet<Country>>(jsonCountries);

        foreach (var country in countries)
        {
            context.Countries.AddOrUpdate(c => c.Name, country);
            context.SaveChanges();
        }
    }

    private static void SeedUsers(MoviesEntity context)
    {
        var jsonUsers = File.ReadAllText("..//..//..//..//data//users.json");
        JArray jsonUsersArr = JsonConvert.DeserializeObject<JArray>(jsonUsers);

        foreach (var jsonUser in jsonUsersArr)
        {
            User user = new User()
            {
                Username = (string)jsonUser["username"],
                //Age = (string)jsonUser["age"] != null ? (byte?)byte.Parse((string)jsonUser["age"]) : null,
                Email = (string)jsonUser["email"] != null ? (string)jsonUser["username"] : null,
                //Country = (string)jsonUser["country"] != null ?
                //context.Countries.Where(c => c.Name == (string)jsonUser["country"]).FirstOrDefault() :
                //null
            };
            
            if ((string)jsonUser["age"] != null)
            {
                user.Age = (byte?)byte.Parse((string)jsonUser["age"]);
            }

            string countryName = (string)jsonUser["country"];
            if ((string)jsonUser["country"] != null)
            {
                user.Country = context.Countries.Where(c => c.Name == countryName).FirstOrDefault();
            }

            context.Users.Add(user);
            context.SaveChanges();
        }
    }

    private static void SeedMovies(MoviesEntity context)
    {
        var jsonMovies = File.ReadAllText("..//..//..//..//data//movies.json");

        var movies = JsonConvert.DeserializeObject<HashSet<Movie>>(jsonMovies);

        foreach (var movie in movies)
        {
            context.Movies.AddOrUpdate(m => m.Title, movie);
            context.SaveChanges();
        }
    }

    private static void SeedUsersFavouriteMovies(MoviesEntity context)
    {
        var jsonFavouriteMovies = File.ReadAllText("..//..//..//..//data//users-and-favourite-movies.json");
        JArray jsonUsersFavouriteMoviesArr = JsonConvert.DeserializeObject<JArray>(jsonFavouriteMovies);

        foreach (JObject jsonUser in jsonUsersFavouriteMoviesArr)
        {
            string username = (string)jsonUser["username"];
            var user = context.Users.Where(u => u.Username == username).First();

            var jsonMoviesArr = jsonUser["favouriteMovies"].ToArray();

            foreach (var movieIsbn in jsonMoviesArr)
            {
                var movieIsbnString = (string)movieIsbn;
                user.FavouriteMovies.Add(context.Movies.Where(m => m.Isbn == movieIsbnString).First());
            }

            context.SaveChanges();
        }
    }

    private static void SeedRatings(MoviesEntity context)
    {
        var jsonRatings = File.ReadAllText("..//..//..//..//data//movie-ratings.json");
        JArray jsonRatingsArr = JsonConvert.DeserializeObject<JArray>(jsonRatings);

        foreach (JObject movieRating in jsonRatingsArr)
        {
            string username = (string)movieRating["user"];
            string isbn = (string)movieRating["movie"];
            int stars = int.Parse((string)movieRating["rating"]);

            int userId = context.Users.Where(u => u.Username == username).Select(u => u.Id).First();
            int movieId = context.Movies.Where(m => m.Isbn == isbn).Select(m => m.Id).First();

            Rating rating = new Rating()
            {
                UserId = userId,
                MovieId = movieId,
                Stars = stars
            };

            context.Ratings.AddOrUpdate(rating);
            context.SaveChanges();
        }
    }
}