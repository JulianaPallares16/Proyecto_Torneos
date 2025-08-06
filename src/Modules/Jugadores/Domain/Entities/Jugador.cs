using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Torneos.src.Modules.Jugadores.Domain.Enities;

public class Jugador
{
    public int Id { get; set; }
    public string? Nombre { get; set; } = string.Empty;
    public string? Apellido { get; set; } = string.Empty;
    public int Dorsal { get; set; }
    public string? Posicion { get; set; } = string.Empty;

}
