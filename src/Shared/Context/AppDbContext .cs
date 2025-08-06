using Proyecto_Torneos.src.Modules.Torneos.Domain.Enities;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Torneos.src.Shared.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Torneo> Torneos => Set<Torneo>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
    }
}
