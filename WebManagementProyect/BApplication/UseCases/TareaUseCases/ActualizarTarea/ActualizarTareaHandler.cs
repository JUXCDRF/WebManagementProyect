using WebManagementProyect.ADomain.InterfacesRepository;
using WebManagementProyect.BApplication.Dtos.Response;
using WebManagementProyect.CInfrastructure.Persistence.AppDbContext;
using WebManagementProyect.EShared.Share;

namespace WebManagementProyect.BApplication.UseCases.TareaUseCases.ActualizarTarea
{
    public class ActualizarTareaHandler
    {
        private readonly ITareaRepository _tareaRepository;
        private readonly ITokenRepository _tokenRepository;

        public ActualizarTareaHandler(ITareaRepository tareaRepository, ITokenRepository tokenRepository)
        {
            _tareaRepository = tareaRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<BaseResponseDto> Handle(ActualizarTareaCommand request)
        {
            var response = new BaseResponseDto();
            var token = await _tokenRepository.ValidarTokenHashAsync(request.Token);
            if (token == false)
            {
                response.Success = false;
                response.Message = "Token no válido";
                return response; // Tarea not found
            }
            var tarea = await _tareaRepository.GetByIdAsync(request.IdTarea);
            if (tarea == null)
            {
                response.Success = false;
                response.Message = "Tarea no encontrada";
                return response; // Tarea not found
            }
            if (tarea.Estado >=2)
            {
                response.Success = false;
                response.Message = "Tarea Finalizada no se puede Actualizar";
                return response; // Tarea not foun
            }

            tarea.Titulo = request.Titulo;
            tarea.Descripcion = request.Descripcion;
            tarea.FechaTarea = request.Fecha;
            tarea.HoraInicio = request.HoraInicio;
            tarea.HoraFin = request.HoraFin;
            tarea.DescEstado = ConstantesParamentros.ESTADO_ACTUALIZADO;

            var resultado = await _tareaRepository.SaveAsync();
            if (!resultado) { 
                response.Success = false;
                response.Message = "Error al actualizar la tarea";
                return response; // Error updating task
            }

            response.Success = true;
            response.Message = "Tarea actualizada correctamente";

            return response;
        }
    }
}
