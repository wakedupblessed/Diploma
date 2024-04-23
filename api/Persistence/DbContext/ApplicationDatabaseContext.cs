using FeedbackAnalyzer.Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DbContext;

public class ApplicationDatabaseContext: Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigurePrimaryKeys(modelBuilder);
        ConfigureRelationships(modelBuilder);
    }
    
    private static void ConfigurePrimaryKeys(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(e => e.Id);
    }

    private static void ConfigureRelationships(ModelBuilder modelBuilder)
    {
        
    }
}