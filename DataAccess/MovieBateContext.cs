﻿

using Microsoft.EntityFrameworkCore;
using MovieBate.Models;

namespace MovieBate.DataAccess
{
    public class MovieBateContext : DbContext
    {

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        public MovieBateContext(DbContextOptions<MovieBateContext> options) : base(options)
        {

        }
    }
}
