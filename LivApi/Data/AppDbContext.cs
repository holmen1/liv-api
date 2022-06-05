using Microsoft.EntityFrameworkCore;
using LivApi.Models;

namespace LivApi.Data
{    
    class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Insurance> Insurances { get; set; }
    }
}