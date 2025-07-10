using Microsoft.EntityFrameworkCore;
using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.CInfrastructure.Repositories;

public class TokenRepository : BaseRepository<Token>, ITokenRepository
{
    public TokenRepository(Proyectos_EPSContext context) : base(context)
    {
    }  
    public async Task<bool> ValidarTokenHashAsync(string token)
    {
      return await GetAllQueryAsync().Where(t => t.TokenHash.Equals(token)).AnyAsync();
    }
    public async Task<Guid?> ValidarTokenToAliasAsync(string token)
    {
        var existe = await ValidarTokenHashAsync(token);
        if (!existe)
        {
            return null; // Retorna cadena vacía si el token no existe
        }
        return await GetIdnByHashAsync(token);
    }
    public async Task<Guid> GetIdnByHashAsync(string token)
    {
        return await GetAllQueryAsync().Where(t => t.TokenHash.Equals(token)).Select(t => t.Id).FirstOrDefaultAsync();
    }

}
