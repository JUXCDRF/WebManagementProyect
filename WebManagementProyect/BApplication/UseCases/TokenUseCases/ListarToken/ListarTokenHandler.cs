using Microsoft.EntityFrameworkCore;
using WebManagementProyect.ADomain.InterfacesRepository;

namespace WebManagementProyect.BApplication.UseCases.TokenUseCases.ListarToken;

public class ListarTokenHandler
{
    private readonly ITokenRepository _tokenRepository;
    public ListarTokenHandler(ITokenRepository tokenRepository)
    {
        _tokenRepository = tokenRepository;
    }
    public async Task<List<ListarTokenCommand>> Handle()
    {
        var tokens =  _tokenRepository.GetAllQueryAsync();
        return await tokens.Select(t => new ListarTokenCommand
        {
            token = t.TokenHash,
            usuario = t.Id.ToString(), // Assuming Usuario is a property in your Token entity
            fechaCreacion = $"{t.FechaCreacion:dd/MM/yyyy}" // ISO 8601 format
        }).ToListAsync();
    }
}
