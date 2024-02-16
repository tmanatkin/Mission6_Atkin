using Microsoft.EntityFrameworkCore;

namespace Mission6.Models
{
    public class FilmContext : DbContext
    {
        // constructor
        public FilmContext(DbContextOptions<FilmContext> options) :base(options)
        {
        }

        public DbSet<Film> films { get; set; }
    }
}
