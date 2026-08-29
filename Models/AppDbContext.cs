using Microsoft.EntityFrameworkCore;

namespace evaluacion20262.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<SolicitudServicio> Solicitudes { get; set; }
    }
}