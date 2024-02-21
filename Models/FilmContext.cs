using Microsoft.EntityFrameworkCore;

namespace Mission6.Models
{
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options) :base(options) { } // constructor

        public DbSet<Film> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
