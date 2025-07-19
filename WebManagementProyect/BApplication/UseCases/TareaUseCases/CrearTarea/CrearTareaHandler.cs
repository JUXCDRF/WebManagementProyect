using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.BApplication.Dtos.Response;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;
using WebManagementProyect.EShared.Share;

namespace WebManagementProyect.BApplication.UseCases.TareaUseCases.CrearTarea;

public class CrearTareaHandler
{
    private readonly ITareaRepository _tareaRepository;
    private readonly ITokenRepository _tokenRepository;

    public CrearTareaHandler(ITareaRepository tareaRepository, ITokenRepository tokenRepository)
    {
        _tareaRepository = tareaRepository;
        _tokenRepository = tokenRepository;
    }

    public async Task<BaseResponseDto> Handle(CrearTareaCommand request)
    {
        var response = new BaseResponseDto();
        var validarToken = await _tokenRepository.ValidarTokenHashAsync(request.Token);
        if (!validarToken)
        {
            response.Success = false;
            response.Message = "Token inválido";
            return response; // Invalid token
        }
        var tarea = new Tarea
        {
            IdProyecto = request.IdProyecto,
            Titulo = request.Titulo,
            Descripcion = request.Descripcion,
            FechaTarea = request.Fecha,
            HoraInicio = request.HoraInicio,
            HoraFin = request.HoraFin,
            Estado = 1,
            DescEstado = ConstantesParamentros.ESTADO_CREADO,
        };
        var resultado = await _tareaRepository.AddAsync(tarea);
        if (!resultado)
        {
            response.Success = false;
            response.Message = "Error al Crear la tarea";
            return response; // Error updating task
        }

        response.Success = true;
        response.Message = "Tarea Creada correctamente";


        return response;
    }
}
