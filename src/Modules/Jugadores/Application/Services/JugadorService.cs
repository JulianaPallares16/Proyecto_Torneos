using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_Torneos.src.Modules.Jugadores.Application.Interfaces;
using Proyecto_Torneos.src.Modules.Jugadores.Domain.Enities;

namespace Proyecto_Torneos.src.Modules.Jugadores.Application.Services;

public class JugadorService : IJugadorService
{
    private readonly IJugadorRepository _repo;
    public JugadorService(IJugadorRepository repo)
    {
        _repo = repo;
    }
    public Task<IEnumerable<Jugador>> ConsultarJugadoresAsync()
    {
        return _repo.GetAllAsync()!;
    }
    public async Task RegistrarJugadorAsync(string nombre, string apellido, int dorsal, string posicion)
    {
        var existentes = await _repo.GetAllAsync();
        if (existentes.Any(j => j.Nombre == nombre && j.Apellido == apellido))
            throw new Exception("El jugador ya existe.");

        var jugador = new Jugador
        {
            Nombre = nombre,
            Apellido = apellido,
            Dorsal = dorsal,
            Posicion = posicion,
        };
        _repo.Add(jugador);
    }
    public async Task EditarJugador(int id, string nuevoNombre, string nuevoApellido, int nuevoDorsal, string nuevaPosicion)
    {
        var jugador = await _repo.GetByIdAsync(id);

        if (jugador == null)
            throw new Exception($"⚠️ Id no encontrado.");

        jugador.Nombre = nuevoNombre;
        jugador.Apellido = nuevoApellido;
        jugador.Dorsal = nuevoDorsal;
        jugador.Posicion = nuevaPosicion;

        _repo.Editar(jugador);
        await _repo.SaveAsync();
    }
    public async Task EliminarJugadorAsync(int id)
    {
        var jugador = await _repo.GetByIdAsync(id);
        if (jugador == null)
            throw new Exception($"⚠️ Id no encontrado.");
        _repo.Eliminar(jugador);
        await _repo.SaveAsync();
    }
    public async Task<Jugador?> ObtenerJugadorPorIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }
}

