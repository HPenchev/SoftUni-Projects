﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Movie
{
    private ICollection<Rating> ratings;
    private ICollection<User> users;

    public Movie()
    {
        this.ratings = new HashSet<Rating>();
        this.users = new HashSet<User>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(1)]
    public string Isbn { get; set; }

    [Required]
    [MinLength(2), MaxLength(100)]
    public string Title { get; set; }

    public AgeRestriction AgeRestriction { get; set; }

    public virtual ICollection<Rating> Ratings
    {
        get
        {
            return this.ratings;
        }

        set
        {
            this.ratings = value;
        }
    }

    public virtual ICollection<User> Users
    {
        get
        {
            return this.users;
        }

        set
        {
            this.users = value;
        }
    }
}