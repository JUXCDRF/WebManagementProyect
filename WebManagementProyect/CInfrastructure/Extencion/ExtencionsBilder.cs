using Microsoft.EntityFrameworkCore;
using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.BApplication.UseCases.TokenUseCases.ListarToken;
using WebManagementProyect.BApplication.UseCases.TokenUseCases.RegisterToken;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;
using WebManagementProyect.CInfrastructure.Repositories;

namespace WebManagementProyect.CInfrastructure.Extencion;

public static class ExtencionsBilder
{
    public static IServiceCollection AddInfraestructura(this IServiceCollection services,string? connectionString)
    {

        services.AddDbContext<Proyectos_EPSContext>(options =>
                options.UseSqlServer(connectionString));

        services.AddScoped<RegisterTokenHandler>();
        services.AddScoped<ListarTokenHandler>();
        services.AddScoped<ITokenRepository, TokenRepository>();
        return services;
    }
}
