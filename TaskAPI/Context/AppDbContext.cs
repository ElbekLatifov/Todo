using Microsoft.EntityFrameworkCore;

namespace TaskAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=task_db;Port=5432;Database=taskdb;User Id=postgres;Password=postgres;");
        }

        public DbSet<Entities.Task> Tasks { get; set; }
    }
}
