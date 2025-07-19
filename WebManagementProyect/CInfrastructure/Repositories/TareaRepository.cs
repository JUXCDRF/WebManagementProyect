using Microsoft.EntityFrameworkCore;
using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.BApplication.Dtos.Response;
using WebManagementProyect.BApplication.UseCases.TareaUseCases.ObtenerTarea;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.CInfrastructure.Repositories;

public class TareaRepository : BaseRepository<Tarea>, ITareaRepository
{
    public TareaRepository(Proyectos_EPSContext context) : base(context)
    {
    }

    public async Task<ProyectoPrincipalDtoResponse?> ListarTareaByIdProyectoAync(Guid idProyecto,int PageSize,int PageNumber)
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
                   id = x.Id.ToString(),
                   fecha = $"{x.FechaTarea:dd/MM/yyyy}",
                   horainicio = $"{x.HoraInicio:HH:mm}",
                   horafin = $"{x.HoraFin:HH:mm}",
                   titulo = x.Titulo,
                   descripcion = x.Descripcion,
                   estado=x.Estado
               }).Skip((PageNumber-1)*PageSize).Take(PageSize).ToList(),
               totalcount = t.Count(),
               pagenumber=PageNumber,
               pagesize=PageSize,
            }).FirstOrDefaultAsync();

    }

    public async Task<ObtenerTareaCommand?> ObtenerTareaByIdAsync(Guid id)
    {
        return await GetAllQueryAsync()
            .Where(t => t.Id == id).Select(s=>new ObtenerTareaCommand
            {
                Success = true,
                Titulo = s.Titulo,
                Descripcion = s.Descripcion,
                Fecha = $"{s.FechaTarea:yyyy-MM-dd}",
                Horainicio = $"{s.HoraInicio:HH:mm}",
                Horafin = $"{s.HoraFin:HH:mm}",
                Message = "Tarea encontrada"
            })
            .FirstOrDefaultAsync();
    }
}
