using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.CInfrastructure.Repositories;

public class UsuarioRepository : BaseRepository<UsuariosAnonimo>, IUsuarioRepository
{
    public UsuarioRepository(Proyectos_EPSContext context) : base(context)
    {
    }
}
