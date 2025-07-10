using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebManagementProyect.ADomain.Entities;
using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.CInfrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : EntidadBase
{
    protected readonly Proyectos_EPSContext _context;

    public BaseRepository(Proyectos_EPSContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(T entity)
    {
        if (entity == null)
        {
            return false;
        }
        await _context.Set<T>().AddAsync(entity);
        return await SaveAsync();
    }

    public async Task<T?> GetByIdAsync(Guid Id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(d=>d.Id==Id && d.Eliminado==false);
    }

    public async Task<bool> DeleteAsync(Guid id,string motivo= "Eliminado por el usuario")
    {
        var entidad = await GetByIdAsync(id);
        if (entidad == null)
        {
            return false;
        }
        entidad.Eliminado = true;
        entidad.FechaEliminado = DateTime.Now;
        entidad.MotivoEliminado = motivo;
        return await SaveAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
       return await _context.Set<T>().Where(s=>s.Eliminado==false).ToListAsync();
    }

    public IQueryable<T> GetAllQueryAsync()
    {
        return _context.Set<T>().Where(s => s.Eliminado == false).AsQueryable();
    }

    public async Task<bool> SaveAsync()
    {
        try
        {
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error al guardar cambios: {ex.Message}");
            return false;
        }
    }

}
