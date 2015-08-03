using System;
using System.Data.Entity;
using System.Linq;

public class MoviesEntity : DbContext
{
    public MoviesEntity()
        : base("name=MoviesEntity")
    {
    }

    public IDbSet<User> Users { get; set; }

    public IDbSet<Rating> Ratings { get; set; }

    public IDbSet<Country> Countries { get; set; }

    public IDbSet<Movie> Movies { get; set; }
}