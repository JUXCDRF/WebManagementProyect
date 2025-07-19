using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.BApplication.Dtos.Response;

namespace WebManagementProyect.BApplication.UseCases.TareaUseCases.ListarTarea;

public class ListarTareaHandler
{
    readonly ITareaRepository _tareaRepository;
    readonly ITokenRepository _tokenRepository;

    public ListarTareaHandler(ITareaRepository tareaRepository, ITokenRepository tokenRepository)
    {
        _tareaRepository = tareaRepository;
        _tokenRepository = tokenRepository;
    }

    public async Task<ProyectoPrincipalDtoResponse> Handle(ListarTareaCommand request)
    {
        var response = new ProyectoPrincipalDtoResponse();
        var exiteToken = await _tokenRepository.ValidarTokenHashAsync(request.Token);
        if (!exiteToken)
        {
            response.tituloprincipal = "No token Validdo";
            response.tareas = new List<ListarTareaDtoResponse>() { new ListarTareaDtoResponse { id = "", titulo = "No hay Token", fecha = $"{DateTime.Now:dd/MM/yyyy}", }, };
            return response; // Si el token no es válido, no se listan las tareas
        }
        var proyectotareas = await _tareaRepository.ListarTareaByIdProyectoAync(request.Id,request.PageSize,request.PageNumber);
        if (proyectotareas == null)
        {
            response.tituloprincipal = "No se encontraron tareas";
            response.tareas = new List<ListarTareaDtoResponse>() { new ListarTareaDtoResponse { id = "", titulo = "No hay Tareas", fecha = $"{DateTime.Now:dd/MM/yyyy}" } };
            return response;
        }

        return proyectotareas;
    }
}
