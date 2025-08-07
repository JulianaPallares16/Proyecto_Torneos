using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_Torneos.src.Modules.Equipos.Application.Interfaces;
using Proyecto_Torneos.src.Modules.Equipos.Domain.Enities;
using Proyecto_Torneos.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Torneos.src.Modules.Equipos.Infrastructure;

public class EquipoRepository 
{
    private readonly AppDbContext _context;
    public EquipoRepository(AppDbContext context)
    {
        _context = context;
    }
    public void Add(Equipo equipo)
    {
        _context.Equipos.Add(equipo);
    }
    public async Task<IEnumerable<Equipo?>> GetAllAsync() =>
        await _context.Equipos.ToListAsync();
    public async Task<Equipo?> GetByIdAsync(int id)
    {
        return await _context.Equipos.FirstOrDefaultAsync(e => e.Id == id);
    }
    public async Task SaveAsync() => await _context.SaveChangesAsync();
}
