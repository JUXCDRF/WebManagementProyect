using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.BApplication.UseCases.TokenUseCases.RegisterToken;

public class RegisterTokenHandler
{
    private readonly ITokenRepository _tokenRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    public RegisterTokenHandler(ITokenRepository tokenRepository, IUsuarioRepository usuarioRepository)
    {
        _tokenRepository = tokenRepository;
        _usuarioRepository= usuarioRepository;
    }
    public async Task<bool> Handle(RegisterTokenCommand command)
    {
        var existe = await _tokenRepository.ValidarTokenHashAsync(command.Token);
        if (existe)
        {
            return false;
        }
        var usuario = new UsuariosAnonimo
        {
            FechaCreacion = DateTime.Now,
            Usuario = command.Alias,
            IdTokenNavigation = new Token
            {
                TokenHash = command.Token,
            },
        };
       return await _usuarioRepository.AddAsync(usuario);
    }
}
