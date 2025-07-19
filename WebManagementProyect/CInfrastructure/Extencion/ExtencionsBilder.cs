using Microsoft.EntityFrameworkCore;
using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.BApplication.UseCases.ProyectoUseCases.ListaProyecto;
using WebManagementProyect.BApplication.UseCases.TokenUseCases.ListarToken;
using WebManagementProyect.BApplication.UseCases.TokenUseCases.CrearToken;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;
using WebManagementProyect.CInfrastructure.Repositories;
using WebManagementProyect.BApplication.UseCases.ProyectoUseCases.CrearProyecto;
using WebManagementProyect.BApplication.UseCases.TokenUseCases.ValidarToken;
using WebManagementProyect.BApplication.UseCases.TareaUseCases.ListarTarea;
using WebManagementProyect.BApplication.UseCases.TareaUseCases.CrearTarea;
using WebManagementProyect.BApplication.UseCases.TareaUseCases.ActualizarTarea;
using WebManagementProyect.BApplication.UseCases.TareaUseCases.ObtenerTarea;
using WebManagementProyect.BApplication.UseCases.TareaUseCases.CambiarEstadoTarea;

namespace WebManagementProyect.CInfrastructure.Extencion;

public static class ExtencionsBilder
{
    public static IServiceCollection AddInfraestructura(this IServiceCollection services,string? connectionString)
    {

        services.AddDbContext<Proyectos_EPSContext>(options =>
                options.UseSqlServer(connectionString));

        services.AddScoped<RegistrarTokenHandler>();
        services.AddScoped<ListarTokenHandler>();
        services.AddScoped<ITokenRepository, TokenRepository>();
        services.AddScoped<IProyectoRepository, ProyectoRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IAccesoProyectoRepository, AccesoProyectoRepository>();
        services.AddScoped<ITareaRepository, TareaRepository>();
        services.AddScoped<ListarProyectoHandler>();
        services.AddScoped<RegistrarProyectoHandler>();
        services.AddScoped<ValidarTokenHandler>();
        services.AddScoped<ListarTareaHandler>();
        services.AddScoped<CrearTareaHandler>();
        services.AddScoped<ActualizarTareaHandler>();
        services.AddScoped<ObtenerTareaHandler>();
        services.AddScoped<EstadoTareaHandler>();
        return services;
    }
}
