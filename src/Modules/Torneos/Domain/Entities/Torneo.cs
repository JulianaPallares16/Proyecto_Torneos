using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Torneos.src.Modules.Torneos.Domain.Enities
{
    public class Torneo
    {
        public int Id { get; set; }
        public string? Nombre { get; set; } = string.Empty;
        public string? Tipo { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}