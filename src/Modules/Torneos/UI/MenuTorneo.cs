using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_Torneos.src.Modules.Torneos.Infrastructure.Repositories;
using Proyecto_Torneos.src.Modules.Torneos.Application.Services;
using Proyecto_Torneos.src.Modules.Torneos.Domain.Enities;
using Proyecto_Torneos.src.Shared.Context;

namespace Proyecto_Torneos.src.Modules.Torneos.UI;

public class MenuTorneo
{
    private readonly AppDbContext _context;
    readonly TorneoRepository repo = null!;
    readonly TorneoService service = null!;
    public MenuTorneo(AppDbContext context)
    {
        _context = context;
        repo = new TorneoRepository(context);
        service = new TorneoService(repo);
    }
    public async Task RenderMenu()
    {
        bool regresar = false;
        while (!regresar)
        {
            Console.Clear();
            Console.WriteLine(new string('*', 25));
            Console.WriteLine(" 🏆 Gestor De Torneos 🏆");
            Console.WriteLine(new string('*', 25));
            Console.WriteLine("1. Crear Torneo");
            Console.WriteLine("2. Buscar Torneo");
            Console.WriteLine("3. Eliminar Torneo");
            Console.WriteLine("4. Actualizar Torneo");
            Console.WriteLine("5. Regresar");
            Console.WriteLine("Ingrese el número de la acción que desea realizar:");
            string? opt = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(opt))
            {
                continue;
            }
            else
            {
                switch (opt)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("== Crear Torneo ==");
                        while (true)
                        {
                            Console.WriteLine("¿Desea crear un nuevo torneo? (si/no)");
                            string? respuesta = Console.ReadLine()?.ToLower();
                            if (respuesta?.ToLower() != "si")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Ingrese el nombre del torneo:");
                                string? nombre = Console.ReadLine();
                                Console.WriteLine("¿Qué tipo de torneo es? (Liga/Torneo Internacional)");
                                string? tipo = Console.ReadLine();
                                DateTime fechaInicio;
                                while (true)
                                {
                                    Console.WriteLine("Ingrese la fecha de inicio (dd/mm/aaaa): ");
                                    string? fechaTexto = Console.ReadLine();

                                    if (DateTime.TryParseExact(fechaTexto, "dd/mm/aaaa", null, System.Globalization.DateTimeStyles.None, out fechaInicio))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("⚠️ Fecha inválida, intente de nuevo (formato: dd/mm/aaaa).");
                                    }
                                }
                                DateTime fechaFin;
                                while (true)
                                {
                                    Console.WriteLine("Ingrese la fecha de inicio (dd/mm/aaaa): ");
                                    string? fechaText = Console.ReadLine();

                                    if (DateTime.TryParseExact(fechaText, "dd/mm/aaaa", null, System.Globalization.DateTimeStyles.None, out fechaFin))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("⚠️ Fecha inválida, intente de nuevo (formato: dd/mm/aaaa).");
                                    }
                                }
                                await service.RegistrarTorneo(nombre!, tipo!, fechaInicio, fechaFin);
                                Console.WriteLine("✅ Torneo creado con exito.");
                            }
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("== Buscar Torneo ==");
                        Console.WriteLine("Ingrese el Id del torneo que desea buscar: ");
                        int id = int.Parse(Console.ReadLine()!);
                        Torneo? torneo = await service.ObtenerTorneoPorIdAsync(id);
                        if (torneo != null)
                        {
                            Console.WriteLine("⭐ Torneo encontrado:");
                            Console.WriteLine($"Torneo: {torneo.Nombre}, Tipo: {torneo.Tipo}, Fecha de inicio: {torneo.FechaInicio}, Fecha de fin: {torneo.FechaFin} ");
                        }
                        else
                        {
                            Console.WriteLine("⚠️ Id no encontrado.");
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("== Eliminar Torneo ==");
                        Console.WriteLine("Ingrese el Id del torneo que desea eliminar: ");
                        int eliminarId = int.Parse(Console.ReadLine()!);
                        while (true)
                        {
                            Console.WriteLine("¿Está seguro de eliminarlo? (si/no)");
                            string? eliminar = Console.ReadLine();
                            if (eliminar?.ToLower() != "si")
                            {
                                break;
                            }
                            else
                            {
                                await service.EliminarTorneo(eliminarId);
                                Console.WriteLine("🗑️ Torneo eliminado exitosamente.");
                                break;
                            }
                        }
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("== Actualizar Torneo ==");
                        Console.WriteLine("Ingrese el Id del torneo que desea Actualizar: ");
                        int idActualizar = int.Parse(Console.ReadLine()!);
                        Console.WriteLine("Ingrese el nuevo nombre del torneo");
                        string? nuevoNombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el nuevo tipo del torneo");
                        string? nuevoTipo = Console.ReadLine();
                        DateTime nuevoInicio;
                        while (true)
                        {
                            Console.WriteLine("Ingrese la nueva fecha de inicio dd/mm/aaaa");
                            string? fechaI = Console.ReadLine();

                            if (DateTime.TryParseExact(fechaI, "dd/mm/aaaa", null, System.Globalization.DateTimeStyles.None, out nuevoInicio))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("⚠️ Fecha inválida, intente de nuevo (formato: dd/mm/aaaa).");
                            }
                        }
                        DateTime nuevoFin;
                        while (true)
                        {
                            Console.WriteLine("Ingrese la fecha de inicio (dd/mm/aaaa): ");
                            string? fechaF = Console.ReadLine();

                            if (DateTime.TryParseExact(fechaF, "dd/mm/aaaa", null, System.Globalization.DateTimeStyles.None, out nuevoFin))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("⚠️ Fecha inválida, intente de nuevo (formato: dd/mm/aaaa).");
                            }
                        }
                        Console.WriteLine("¿Está seguro de realizar la actualización? si/no");
                        string? answer = Console.ReadLine();
                        if (answer?.ToLower() != "si")
                        {
                            break;
                        }
                        else
                        {
                            await service.ActualizarTorneo(idActualizar, nuevoNombre!, nuevoTipo!, nuevoInicio, nuevoFin);
                            Console.WriteLine("✅ Torneo actualizado con éxito. ");
                        }
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Adios...");
                        regresar = true;
                        break;
                    default:
                        Console.WriteLine("Opción no valida");
                        break;
                }       
            }
        }
    }
}