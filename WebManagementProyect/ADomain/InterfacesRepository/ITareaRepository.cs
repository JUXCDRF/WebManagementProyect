using WebManagementProyect.BApplication.Dtos.Response;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.ADomain.InterfacesRepository;

public interface ITareaRepository:IBaseRepository<Tarea>
{
    Task<ProyectoPrincipalDtoResponse?> ListarTareaByIdProyectoAync(Guid idProyecto);
}
