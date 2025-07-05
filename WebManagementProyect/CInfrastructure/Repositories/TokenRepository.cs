using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.CInfrastructure.Repositories;

public class TokenRepository : BaseRepository<Token>, ITokenRepository
{
    public TokenRepository(Proyectos_EPSContext context) : base(context)
    {
    }
}
