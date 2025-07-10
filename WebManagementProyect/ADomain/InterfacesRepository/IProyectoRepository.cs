using WebManagementProyect.BApplication.UseCases.ProyectoUseCases.ListaProyecto;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.ADomain.InterfacesRepository;

public interface IProyectoRepository:IBaseRepository<Proyecto>
{
    Task<List<ListarProyectoCommand>> GetNameProyectosByTokenAsync(Guid Idtoken, Guid Idproyecto);
}
