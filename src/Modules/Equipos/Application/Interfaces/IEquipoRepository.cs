using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_Torneos.src.Modules.Equipos.Domain.Enities;

namespace Proyecto_Torneos.src.Modules.Equipos.Application.Interfaces;

public interface IEquipoRepository
{
    Task<Equipo?> GetByIdAsync(int id);
    Task<IEnumerable<Equipo?>> GetAllAsync();
    void Add(Equipo equipo);
    Task SaveAsync();
    Task<IEnumerable<Equipo?>> GetAllWithTorneoAsync();
}
