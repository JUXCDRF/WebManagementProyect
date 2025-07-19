using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.BApplication.Dtos.Response;
using WebManagementProyect.BApplication.UseCases.TareaUseCases.CambiarEstadoTareal;
using WebManagementProyect.EShared.Share;

namespace WebManagementProyect.BApplication.UseCases.TareaUseCases.CambiarEstadoTarea;

public class EstadoTareaHandler
{
    private readonly ITareaRepository _tareaRepository;
    private readonly ITokenRepository _tokenRepository;
    public EstadoTareaHandler(ITareaRepository tareaRepository, ITokenRepository tokenRepository)
    {
        _tareaRepository = tareaRepository;
        _tokenRepository = tokenRepository;
    }

    public async Task<BaseResponseDto> Handle(EstadoTareaCommand command)
    {
        var response = new BaseResponseDto();
        // Validar el estado de la tarea
        var tokenExite = await _tokenRepository.ValidarTokenHashAsync(command.Token);
        if (!tokenExite)
        {
            response.Success = false;
            response.Message = "Token inválido o no encontrado.";
            return response;
        }
        if (command.Estado<=1 || command.Estado>3)
        {
            response.Success = false;
            response.Message = "El estado de la tarea no puede estar vacío.";
            return response;
        }
        // Obtener la tarea por ID
        var tarea = await _tareaRepository.GetByIdAsync(command.IdTarea);
        if (tarea == null)
        {
            throw new KeyNotFoundException("Tarea no encontrada.");
        }

        // Cambiar el estado de la tarea
        tarea.Estado = command.Estado;
        tarea.DescEstado = ConstantesParamentros.ESTADO_FINALIZADO;

        if (tarea.Estado==3)
        {
            tarea.DescEstado = ConstantesParamentros.ESTADO_ELIMINADO;
            tarea.Eliminado = true;
            tarea.FechaEliminado = DateTime.Now;
            tarea.MotivoEliminado = "Eliminada";
        }
        // Guardar los cambios en el repositorio
        var resultado = await _tareaRepository.SaveAsync();
        if (!resultado)
        {
            response.Success = false;
            response.Message = "Error al actualizar estado de la tarea";
            return response; // Error updating task
        }

        response.Success = true;
        response.Message = "Estado de la Tarea actualizada correctamente";

        return response;
    }
}
