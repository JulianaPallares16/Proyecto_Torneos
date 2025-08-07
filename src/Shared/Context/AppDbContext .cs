using Proyecto_Torneos.src.Modules.Torneos.Domain.Enities;
using Microsoft.EntityFrameworkCore;
using Proyecto_Torneos.src.Modules.Equipos.Domain.Enities;

namespace Proyecto_Torneos.src.Shared.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Torneo> Torneos => Set<Torneo>();
    public DbSet<Equipo> Equipos => Set<Equipo>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
    }
}
