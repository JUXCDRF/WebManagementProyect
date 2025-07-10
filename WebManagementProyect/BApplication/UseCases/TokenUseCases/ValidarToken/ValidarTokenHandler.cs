using Microsoft.IdentityModel.Tokens;
using WebManagementProyect.ADomain.InterfacesRepository;

namespace WebManagementProyect.BApplication.UseCases.TokenUseCases.ValidarToken;

public class ValidarTokenHandler
{
    private readonly ITokenRepository _tokenRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public ValidarTokenHandler(ITokenRepository tokenRepository, IUsuarioRepository usuarioRepository)
    {
        _tokenRepository = tokenRepository;
        _usuarioRepository = usuarioRepository;
    }
    public async Task<string> Handle(ValidarTokenCommand request)
    {
        var guid = await _tokenRepository.ValidarTokenToAliasAsync(request.Token);
        if (guid==null)
        {
            return ""; // Si el alias es nulo o vacío no hay alias asociado al token
        }

        return await _usuarioRepository.GetAliasByIdtoken((Guid)guid);
    }
}
