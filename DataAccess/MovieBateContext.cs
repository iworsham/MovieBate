

using Microsoft.EntityFrameworkCore;
using MovieBate.Models;

namespace MovieBate.DataAccess
{
    public class MovieBateContext : DbContext
    {

        public DbSet<MovieApiResponse> Movies { get; set; }
        //public DbSet<Review> Reviews { get; set; }

        public MovieBateContext(DbContextOptions<MovieBateContext> options) : base(options)
        {

        }
    }
}
