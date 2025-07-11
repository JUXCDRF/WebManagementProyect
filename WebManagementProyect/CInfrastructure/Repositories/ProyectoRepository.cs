using Microsoft.EntityFrameworkCore;
using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.BApplication.UseCases.ProyectoUseCases.ListaProyecto;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.CInfrastructure.Repositories
{
    public class ProyectoRepository : BaseRepository<Proyecto>, IProyectoRepository
    {
        public ProyectoRepository(Proyectos_EPSContext context) : base(context)
        {
        }

        public Task<List<ListarProyectoCommand>> GetNameProyectosByTokenAsync(Guid Idtoken)
        {
          return  _context.Set<TokenAccesoProyecto>().Where(s => s.IdToken == Idtoken && s.Eliminado == false).Include(d=>d.IdProyectoNavigation)
                .Select(s => new ListarProyectoCommand
                {
                    Id = s.IdProyectoNavigation.Id.ToString(),
                    nombre = s.IdProyectoNavigation.NombreProyecto,
                    fecha= $"{s.IdProyectoNavigation.FechaCreacion:dd/MM/yyyy}", // ISO 8601 format
                }).ToListAsync();
        }

        public Task<List<ListarProyectoCommand>> GetNameProyectosByTokenAsync(Guid Idtoken,string filtro)
        {
            return _context.Set<TokenAccesoProyecto>().Where(s => s.IdToken == Idtoken && s.Eliminado == false).Include(d => d.IdProyectoNavigation)
                .Where(f=>f.IdProyectoNavigation.NombreProyecto.Contains(filtro))
                  .Select(s => new ListarProyectoCommand
                  {
                      Id = s.IdProyectoNavigation.Id.ToString(),
                      nombre = s.IdProyectoNavigation.NombreProyecto,
                      fecha = $"{s.IdProyectoNavigation.FechaCreacion:dd/MM/yyyy}", // ISO 8601 format
                  }).ToListAsync();
        }
    }
}
