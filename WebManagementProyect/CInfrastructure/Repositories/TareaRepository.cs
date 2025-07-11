using Microsoft.EntityFrameworkCore;
using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.BApplication.Dtos.Response;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.CInfrastructure.Repositories;

public class TareaRepository : BaseRepository<Tarea>, ITareaRepository
{
    public TareaRepository(Proyectos_EPSContext context) : base(context)
    {
    }

    public async Task<ProyectoPrincipalDtoResponse?> ListarTareaByIdProyectoAync(Guid idProyecto)
    {
        return await GetAllQueryAsync()
            .Where(t => t.IdProyecto == idProyecto)
            .Include(t => t.IdProyectoNavigation)
            .GroupBy(t => new { t.IdProyectoNavigation.Id, t.IdProyectoNavigation.NombreProyecto })
            .Select(t => new ProyectoPrincipalDtoResponse
            {
               tituloprincipal=t.Key.NombreProyecto,
               tareas= t.Select(x => new ListarTareaDtoResponse
               {
                   Id = x.Id.ToString(),
                   fecha = $"{x.FechaTarea:dd/MM/yyyy}",
                   horainicio = $"{x.HoraInicio:HH:mm}",
                   horafin = $"{x.HoraFin:HH:mm}",
                   titulo = x.Titulo,
                   descripcion = x.Descripcion
               }).ToList()
            }).FirstOrDefaultAsync();

    }
}
