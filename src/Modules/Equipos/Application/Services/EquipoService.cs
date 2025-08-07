using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_Torneos.src.Modules.Equipos.Application.Interfaces;
using Proyecto_Torneos.src.Modules.Equipos.Domain.Enities;
using Proyecto_Torneos.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Torneos.src.Modules.Equipos.Application.Services;

public class EquipoService : IEquipoService
{
    private readonly IEquipoRepository _equipoRepository;
    public EquipoService(IEquipoRepository equipoRepository)
    {
        _equipoRepository = equipoRepository;
    }
    public async Task RegistrarEquipoAsync(Equipo equipo)
    {
        _equipoRepository.Add(equipo);
        await _equipoRepository.SaveAsync();
    }
    
}
