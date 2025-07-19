using WebManagementProyect.BApplication.Dtos.Response;
using WebManagementProyect.BApplication.UseCases.TareaUseCases.ObtenerTarea;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.ADomain.InterfacesRepository;

public interface ITareaRepository:IBaseRepository<Tarea>
{
    Task<ProyectoPrincipalDtoResponse?> ListarTareaByIdProyectoAync(Guid idProyecto, int PageSize, int PageNumber);
    Task<ObtenerTareaCommand?> ObtenerTareaByIdAsync(Guid id);
}
