using Microsoft.EntityFrameworkCore;

namespace PatentProj.Models;

public class DesignFormContext : DbContext
{
    public DesignFormContext(DbContextOptions<DesignFormContext> options)
        : base(options)
    {
    }

    public DbSet<DesignForm> DesignForms { get; set; } = null!;
    public DbSet<Owner> Owners { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DesignForm>()
            .HasOne(p => p.Owner)
            .WithMany(p => p.DesignForms)
            .HasForeignKey(p => p.OwnerId);
    }
}
