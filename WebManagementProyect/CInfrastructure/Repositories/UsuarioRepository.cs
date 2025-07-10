using Microsoft.EntityFrameworkCore;
using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.CInfrastructure.Repositories;

public class UsuarioRepository : BaseRepository<UsuariosAnonimo>, IUsuarioRepository
{
    public UsuarioRepository(Proyectos_EPSContext context) : base(context)
    {
    }
    public async Task<Guid> GetIdByIdtoken(Guid idtoken)
    {
        return await GetAllQueryAsync().Where(u=>u.IdToken.Equals(idtoken)).Select(s => s.Id).FirstOrDefaultAsync();
    }
    public async Task<string> GetAliasByIdtoken(Guid idtoken)
    {
        return await GetAllQueryAsync().Where(u => u.IdToken.Equals(idtoken)).Select(s => s.Usuario).FirstOrDefaultAsync()??"";
    }
}
