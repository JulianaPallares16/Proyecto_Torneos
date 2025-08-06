using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_Torneos.src.Modules.Torneos.Domain.Enities;

namespace Proyecto_Torneos.src.Modules.Torneos.Application.Interfaces;

public interface ITorneoRepository
{
    Task<Torneo?> GetByIdAsync(int id);
    Task<IEnumerable<Torneo?>> GetAllAsync();
    void Add(Torneo torneo);
    void Eliminar(Torneo torneo);
    void Actualizar(Torneo torneo);
    Task SaveAsync();
}
