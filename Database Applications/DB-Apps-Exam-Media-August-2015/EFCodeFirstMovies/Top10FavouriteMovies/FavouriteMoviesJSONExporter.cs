using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class FavouriteMoviesJSONExporter
{
    public static void Main()
    {
        var context = new MoviesEntity();

        var favouriteMovies = context.Movies
            .Where(m => m.AgeRestriction == AgeRestriction.Teen)
            .OrderByDescending(m => m.Users.Count())
            .ThenBy(m => m.Title)
            .Select(m => new
            {
                m.Isbn,
                m.Title,
                FavouritedBy = m.Users.Select(u => u.Username)
            })
            .Take(10);
        JArray jsonFavouriteMoviesArr = new JArray();

        foreach (var movie in favouriteMovies)
        {
            JObject jsonMovie = new JObject(
                new JProperty("isbn", movie.Isbn),
                new JProperty("title", movie.Title),
                new JProperty("favouritedBy", JsonConvert.SerializeObject(movie.FavouritedBy, Formatting.Indented)));

            jsonFavouriteMoviesArr.Add(jsonMovie);
        }

        var jsonFavouriteMovies = JsonConvert.SerializeObject(jsonFavouriteMoviesArr, Formatting.Indented);

        File.WriteAllText("..//..//top10-teen-movies.json", jsonFavouriteMovies);
    }
}