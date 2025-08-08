using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_Torneos.src.Modules.Jugadores.Domain.Enities;

namespace Proyecto_Torneos.src.Modules.Jugadores.Application.Interfaces;

public interface IJugadorService
{
    Task RegistrarJugadorAsync(string nombre, string apellido, int dorsal, string posicion);
    Task EditarJugadorAsync(int id, string nombre, string apellido, int dorsal, string posicion);
    Task EliminarJugadorAsync(int id);
    Task<Jugador?> ObtenerJugadorPorIdAsync(int id);
    Task<IEnumerable<Jugador>> ConsultarJugadoresAsync();

}
