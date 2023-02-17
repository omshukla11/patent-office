using Microsoft.EntityFrameworkCore;

namespace PatentProj.Models;

public class DesignFormContext : DbContext
{
    public DesignFormContext(DbContextOptions<DesignFormContext> options)
        : base(options)
    {
    }

    public DbSet<DesignForm> DesignForms { get; set; } = null!;
}
