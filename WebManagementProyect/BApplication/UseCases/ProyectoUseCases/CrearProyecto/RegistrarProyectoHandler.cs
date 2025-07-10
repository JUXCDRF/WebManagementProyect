using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;
namespace WebManagementProyect.BApplication.UseCases.ProyectoUseCases.CrearProyecto;

public class RegistrarProyectoHandler
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IAccesoProyectoRepository _accesoProyectoRepository;
    private readonly ITokenRepository _tokenRepository;

    public RegistrarProyectoHandler(IUsuarioRepository usuarioRepository, ITokenRepository tokenRepository, IAccesoProyectoRepository accesoProyectoRepository)
    {
        _usuarioRepository = usuarioRepository;
        _tokenRepository = tokenRepository;
        _accesoProyectoRepository = accesoProyectoRepository;
    }

    public async Task<bool> Handle(RegistrarProyectoCommand request)
    {
        var exiteToken = await _tokenRepository.ValidarTokenHashAsync(request.Token); //token
        if (!exiteToken)
        {
            return false; // Si el token no es válido, no se crea el proyecto
        }
        var tokenId = await _tokenRepository.GetIdnByHashAsync(request.Token); //token
        var autorId = await _usuarioRepository.GetIdByIdtoken(tokenId); // ID del creador
        var tokenAccesoProyecto = new TokenAccesoProyecto
        {
            FechaCreacion = DateTime.UtcNow,
            IdProyectoNavigation=new Proyecto()
            {
                NombreProyecto = request.Nombre,
                FechaCreacion = DateTime.UtcNow,
            },
            Lectura = false, // Asignar permisos de lectura
            Editar = true, // Asignar permisos de edición
            TipoToken = "Proyecto", // Asignar el tipo de token
            IdToken = tokenId, // Asignar el ID del token
            IdCreador = autorId, // Asignar el ID del creador
        };
        if (request.Permiso == 2)
        {
            tokenAccesoProyecto.Lectura = true;
            tokenAccesoProyecto.Editar = false;
        }

        return await _accesoProyectoRepository.AddAsync(tokenAccesoProyecto);
    }
}
