using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;
namespace WebManagementProyect.BApplication.UseCases.ProyectoUseCases.CrearProyecto;

public class CrearPoyectoHandler
{
    private readonly IProyectoRepository _proyectoRepository;
    private readonly IAccesoProyectoRepository _accesoProyectoRepository;
    private readonly ITokenRepository _tokenRepository;

    public CrearPoyectoHandler(IProyectoRepository proyectoRepository, ITokenRepository tokenRepository, IAccesoProyectoRepository accesoProyectoRepository)
    {
        _proyectoRepository = proyectoRepository;
        _tokenRepository = tokenRepository;
        _accesoProyectoRepository = accesoProyectoRepository;
    }

    public async Task<bool> Handle()
    {
        var exiteToken = await _tokenRepository.ValidarTokenHashAsync(""); //token
        if (!exiteToken)
        {
            return false; // Si el token no es válido, no se crea el proyecto
        }
        var tokenId = await _tokenRepository.GetTokenByHashAsync(""); //token
        var tokenAccesoProyecto = new TokenAccesoProyecto
        {
            FechaCreacion = DateTime.UtcNow,
            IdProyectoNavigation=new Proyecto()
            {
                NombreProyecto = "",
                FechaCreacion = DateTime.UtcNow,
            },
            TipoToken = "Proyecto", // Asignar el tipo de token
            Lectura = false, // Asignar permisos de lectura
            Editar= true, // Asignar permisos de edición
            IdToken = tokenId, // Asignar el ID del token
            IdCreador = Guid.NewGuid(), // Asignar el ID del creador
        };

        await _accesoProyectoRepository.AddAsync(tokenAccesoProyecto);
        return true;
    }
}
