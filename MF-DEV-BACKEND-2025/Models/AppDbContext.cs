using Microsoft.EntityFrameworkCore;

namespace MF_DEV_BACKEND_2025.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext>options) : base(options) { }

        public DbSet <Veículo> Veículos { get; set; }
    }
}
