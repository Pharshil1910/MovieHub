using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class FilmIndustryDBContext : DbContext
    {
        public FilmIndustryDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<MovieActor> MovieActor { get; set; }
    }
}
