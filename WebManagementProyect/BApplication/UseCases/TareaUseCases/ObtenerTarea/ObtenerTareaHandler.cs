using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.EShared.Share;

namespace WebManagementProyect.BApplication.UseCases.TareaUseCases.ObtenerTarea;

public class ObtenerTareaHandler
{
    private readonly ITareaRepository _tareaRepository;
    private readonly ITokenRepository _tokenRepository;

    public ObtenerTareaHandler(ITareaRepository tareaRepository , ITokenRepository tokenRepository)
    {
        _tareaRepository = tareaRepository;
        _tokenRepository = tokenRepository;
    }
    public async Task<ObtenerTareaCommand> Handle(Guid Id,string token)
    {
        var valid = await _tokenRepository.ValidarTokenHashAsync(token);
        if (valid==false)
        {
            return new ObtenerTareaCommand { Success = false };
        }
        var tarea = await _tareaRepository.ObtenerTareaByIdAsync(Id);

        if (tarea == null)
        {
            return new ObtenerTareaCommand { Success = false, Message = "Tarea no encontrada" };
        }
        return tarea;

    }
}
