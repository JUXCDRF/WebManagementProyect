using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.CInfrastructure.Repositories
{
    public class AccesoProyectoRepository : BaseRepository<TokenAccesoProyecto>, IAccesoProyectoRepository
    {
        public AccesoProyectoRepository(Proyectos_EPSContext context) : base(context)
        {
        }
    }
}
