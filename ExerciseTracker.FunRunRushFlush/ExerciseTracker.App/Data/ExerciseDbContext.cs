using ExerciseTracker.App.Data.DbConfiguration;
using ExerciseTracker.App.Model;
using Microsoft.EntityFrameworkCore;


namespace ExerciseTracker.App.Data;

public class ExerciseDbContext : DbContext
{
    public ExerciseDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Excercise> ExcerciseTable { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.ApplyConfiguration(new ExcerciseConfiguration());
    }
}