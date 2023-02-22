using Microsoft.EntityFrameworkCore;
using TodoList.WebApi.Model;

namespace TodoList.WebApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Activity> Activities { get; set; }
    }
}
