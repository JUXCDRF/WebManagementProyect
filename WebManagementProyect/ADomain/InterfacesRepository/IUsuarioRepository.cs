using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.ADomain.InterfacesRepository;

public interface IUsuarioRepository:IBaseRepository<UsuariosAnonimo>
{
    Task<Guid> GetIdByIdtoken(Guid idtoken);
    Task<string> GetAliasByIdtoken(Guid idtoken);
}
