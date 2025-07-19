using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebManagementProyect.BApplication.Dtos.Request;
using WebManagementProyect.BApplication.Dtos.Response;
using WebManagementProyect.BApplication.UseCases.ProyectoUseCases.CrearProyecto;
using WebManagementProyect.BApplication.UseCases.TareaUseCases.ActualizarTarea;
using WebManagementProyect.BApplication.UseCases.TareaUseCases.CambiarEstadoTarea;
using WebManagementProyect.BApplication.UseCases.TareaUseCases.CambiarEstadoTareal;
using WebManagementProyect.BApplication.UseCases.TareaUseCases.CrearTarea;
using WebManagementProyect.BApplication.UseCases.TareaUseCases.ObtenerTarea;
using WebManagementProyect.EShared.Share;

namespace WebManagementProyect.DPresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly CrearTareaHandler _handlerRegistrar;
        private readonly ObtenerTareaHandler _handlerObtener;
        private readonly ActualizarTareaHandler _actualizarTareaHandler;
        private readonly EstadoTareaHandler _actualizarEstadoTareaHandler;
        public TareaController(
            CrearTareaHandler handlerRegistrar, 
            ObtenerTareaHandler obtenerTareaHandler, 
            ActualizarTareaHandler actualizarTareaHandler,
            EstadoTareaHandler estadoTareaHandler)
        {
            _handlerRegistrar = handlerRegistrar;
            _handlerObtener = obtenerTareaHandler;
            _actualizarTareaHandler = actualizarTareaHandler;
            _actualizarEstadoTareaHandler = estadoTareaHandler;
        }

        //[Route("Proyecto/{id:guid}/Tarea")]
        [HttpPost("Registrar")]
        public async Task<Results<Created<BaseResponseDto>, BadRequest<BaseResponseDto>>> RegistraTareaAsync([FromBody] TareaRegistrarDtoRequest request)
        {
            var response = new BaseResponseDto();
            if (!ModelState.IsValid)
            {
                var modalStateListaError = ConstantesFunciones.ObtenerModalStateError(ModelState);
                response.Message = string.Join(",", modalStateListaError);

                return TypedResults.BadRequest(response); // devuelve errores de validación automáticamente
            }
            //var nombreDecode = ConstantesFunciones.Base64Decode(request.nombre);
            var tokenHashString = ConstantesFunciones.Sha256Hash(request.token);

            var tareaCommand = new CrearTareaCommand
            {
                IdProyecto = request.id,
                Titulo = request.titulo,
                Descripcion = request.descripcion,
                Fecha = request.fecha,
                HoraFin = TimeOnly.Parse(request.horafin),
                HoraInicio = TimeOnly.Parse(request.horainicio),
                Token = tokenHashString
            };

            var resultado = await _handlerRegistrar.Handle(tareaCommand);

            return TypedResults.Created("/", resultado);
        }

        [HttpPost("{id:guid}")]
        public async Task<Results<Ok<ObtenerTareaCommand>, BadRequest<ObtenerTareaCommand>>> ObteneTareaById([FromRoute] Guid id, [FromBody] ObtenerTareaDtoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return TypedResults.BadRequest(new ObtenerTareaCommand
                {
                    Message = "El token es requerido",
                    Success = false
                });                
            }
            var tokenHashString = ConstantesFunciones.Sha256Hash(request.token);

            var resultado = await _handlerObtener.Handle(id, tokenHashString); // Replace null with actual repositories
            return TypedResults.Ok(resultado);
        }

        [HttpPost("Actualizar")]
        public async Task<Results<Ok<BaseResponseDto>, BadRequest<BaseResponseDto>>> ActualizarTareaAsync([FromBody] ActualizarTareaDtoRequest request)
        {
            var response = new BaseResponseDto();
            if (!ModelState.IsValid)
            {
                var modalStateListaError = ConstantesFunciones.ObtenerModalStateError(ModelState);
                response.Message = string.Join(",", modalStateListaError);

                return TypedResults.BadRequest(response); // devuelve errores de validación automáticamente
            }
            var tokenHashString = ConstantesFunciones.Sha256Hash(request.token);

            var tareaCommand = new ActualizarTareaCommand
            {
                IdTarea = request.id,
                Titulo = request.titulo,
                Descripcion = request.descripcion,
                Fecha = request.fecha,
                HoraFin = TimeOnly.Parse(request.horafin),
                HoraInicio = TimeOnly.Parse(request.horainicio),
                Token = tokenHashString
            };

            var resultado = await _actualizarTareaHandler.Handle(tareaCommand); // Replace null with actual repositories

            return TypedResults.Ok(resultado);
        }

        [HttpPost("{id:guid}/Estado")]
        public async Task<Results<Ok<BaseResponseDto>, BadRequest<BaseResponseDto>>> ActualizarTareaAsync([FromRoute] Guid id,[FromBody] EstadoTareaDtoRequest request)
        {
            var response = new BaseResponseDto();
            if (!ModelState.IsValid)
            {
                var modalStateListaError = ConstantesFunciones.ObtenerModalStateError(ModelState);
                response.Message = string.Join(",", modalStateListaError);

                return TypedResults.BadRequest(response); // devuelve errores de validación automáticamente
            }
            var tokenHashString = ConstantesFunciones.Sha256Hash(request.token);

            var tareaCommand = new EstadoTareaCommand
            {
                IdTarea = id,
                Token = tokenHashString,
                Estado = request.estado
            };

            var resultado = await _actualizarEstadoTareaHandler.Handle(tareaCommand); // Replace null with actual repositories

            return TypedResults.Ok(resultado);
        }

    }
}
