using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_Torneos.src.Modules.Jugadores.Domain.Enities;

namespace Proyecto_Torneos.src.Modules.Jugadores.Application.Interfaces;

public interface IJugadorRepository
{
    Task<Jugador?> GetByIdAsync(int id);
    Task<IEnumerable<Jugador?>> GetAllAsync();
    void Add(Jugador jugador);
    void Eliminar(Jugador jugador);
    void Actualizar(Jugador jugador);
    Task SaveAsync();
}
