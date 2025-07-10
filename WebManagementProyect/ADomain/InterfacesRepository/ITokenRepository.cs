using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;
namespace WebManagementProyect.ADomain.InterfacesRepository;

public interface ITokenRepository:IBaseRepository<Token>
{
    Task<bool> ValidarTokenHashAsync(string token);
    Task<Guid> GetTokenByHashAsync(string token);
}
