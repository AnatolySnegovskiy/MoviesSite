using Movies.Domain.Entities;
using System.Data.Entity;

namespace Movies.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}
