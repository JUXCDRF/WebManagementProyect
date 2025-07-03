using Microsoft.EntityFrameworkCore;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.CInfrastructure.Extencion;

public static class ExtencionsBilder
{
    public static IServiceCollection AddInfraestructura(this IServiceCollection services,string? connectionString)
    {

        services.AddDbContext<Proyectos_EPSContext>(options =>
                options.UseSqlServer(connectionString));


        return services;
    }
}
