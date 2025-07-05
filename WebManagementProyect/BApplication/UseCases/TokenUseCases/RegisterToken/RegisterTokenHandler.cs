using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;

namespace WebManagementProyect.BApplication.UseCases.TokenUseCases.RegisterToken;

public class RegisterTokenHandler
{
    private readonly ITokenRepository _tokenRepository;
    public RegisterTokenHandler(ITokenRepository tokenRepository)
    {
        _tokenRepository = tokenRepository;
    }
    public async Task<bool> Handle(RegisterTokenCommand command)
    {
        var token = new Token
        {
            TokenHash = command.Token
        };
       return await _tokenRepository.AddAsync(token);
    }
}
