using System.Configuration;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TourPlanner_Project.MVVM.Model;

public class ApplicationContext : DbContext
{
    public DbSet<Tour> Tours { get; set; }
    public DbSet<Log> Logs { get; set; }

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
