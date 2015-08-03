using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class AdultMoviesExporter
{
    public static void Main()
    {
        var migrationStrategy = new MigrateDatabaseToLatestVersion<MoviesEntity, Configuration>();
        Database.SetInitializer(migrationStrategy);

        var context = new MoviesEntity();

        var adultMovies = context.Movies
            .Where(m => m.AgeRestriction == AgeRestriction.Adult)
            .OrderBy(m => m.Title)
            .ThenBy(m => m.Ratings.Count())
            .Select(m => new
            {
                m.Title,
                RatingsGiven = m.Ratings.Count()
            });

        JArray jsonMoviesArray = new JArray();
        foreach (var movie in adultMovies)
        {
            JObject jsonMovie =
                new JObject(new JProperty("title", movie.Title), new JProperty("ratingsGiven", movie.RatingsGiven));
            jsonMoviesArray.Add(jsonMovie);
        }

        var jsonMovies = JsonConvert.SerializeObject(jsonMoviesArray, Formatting.Indented);      

        File.WriteAllText("..//..//adult-movies.json", jsonMovies);
    }
}