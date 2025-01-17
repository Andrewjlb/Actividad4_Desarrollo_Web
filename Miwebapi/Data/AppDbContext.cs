using Microsoft.EntityFrameworkCore;
using Miwebapi.Models;

namespace Miwebapi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
