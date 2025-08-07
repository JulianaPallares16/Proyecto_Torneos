using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_Torneos.src.Modules.Jugadores.Domain.Enities;
using Proyecto_Torneos.src.Modules.Torneos.Domain.Enities;

namespace Proyecto_Torneos.src.Modules.Equipos.Domain.Enities
{
    public class Equipo
    {
        public int Id { get; set; }
        public string? Nombre { get; set; } = string.Empty;
        public string? Tipo { get; set; } = string.Empty;
        public string? Pais { get; set; } = string.Empty;
        public Torneo? torneo { get; set; }
        public ICollection<Jugador>?  Jugadores { get; set; }
    }
}