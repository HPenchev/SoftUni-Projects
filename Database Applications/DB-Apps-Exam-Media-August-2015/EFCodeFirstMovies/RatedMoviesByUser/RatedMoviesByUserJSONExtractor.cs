using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

public class RatedMoviesByUserJSONExtractor
{
    static void Main()
    {
        Console.WriteLine("Please enter a username to export rated movies: ");

        string username = Console.ReadLine();
        var context = new MoviesEntity();

        if (!context.Users.Any(u => u.Username == username))
        {
            Console.WriteLine("No such user in database");
            return;
        }

        var ratedMovies = context.Movies
            .Where(m => m.Ratings.Any(r => r.User.Username == username))
            .Select(m => new
            {
                m.Title,
                UserRating = m.Ratings.Where(r => r.User.Username == username).Select(r => r.Stars).FirstOrDefault(),
                AverageRating = m.Ratings.Select(r => r.Stars).Average()
            });

        JObject jsonRatedMovies = new JObject(new JProperty("username", username));        
        JArray jsonRatedMoviesArray = new JArray();

        foreach (var movie in ratedMovies)
        {
            JObject jsonMovie =
                new JObject(
                    new JProperty("title", movie.Title),
                    new JProperty("userRating", movie.UserRating),
                    new JProperty("averageRating", movie.AverageRating));
            jsonRatedMoviesArray.Add(jsonMovie);
        }

        jsonRatedMovies.Add(new JProperty("ratedMovies", jsonRatedMoviesArray));

        var jsonRatedMoviesText = JsonConvert.SerializeObject(jsonRatedMovies, Formatting.Indented);

        File.WriteAllText("..//..//" + username + "-rated-movies.json", jsonRatedMoviesText);
    }
}