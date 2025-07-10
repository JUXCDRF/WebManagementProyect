using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using WebManagementProyect.BApplication.Dtos.Request;
using WebManagementProyect.BApplication.Dtos.Response;
using WebManagementProyect.BApplication.UseCases.ProyectoUseCases.CrearProyecto;
using WebManagementProyect.BApplication.UseCases.ProyectoUseCases.ListaProyecto;
using WebManagementProyect.BApplication.UseCases.TokenUseCases.CrearToken;
using WebManagementProyect.BApplication.UseCases.TokenUseCases.ListarToken;
using WebManagementProyect.EShared.Share;

namespace WebManagementProyect.DPresentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProyectoController : ControllerBase
{
    private readonly ListarProyectoHandler _handlerListar;
    private readonly RegistrarProyectoHandler _handlerRegistrar;

    public ProyectoController(ListarProyectoHandler handlerListar, RegistrarProyectoHandler handlerRegistrar)
    {
        _handlerListar = handlerListar;
        _handlerRegistrar = handlerRegistrar;
    }

    [HttpGet("Listar")]
    public async Task<Results<Ok<List<ListarProyectoCommand>>, NotFound>> ListarProyectoAsync()
    {
        //var resultado = await _handlerListar.Handle();
        return TypedResults.Ok(new List<ListarProyectoCommand>() { new ListarProyectoCommand { Id = "", nombre = "No se encontro Proyectos", fecha = $"{DateTime.Now:dd/MM/yyyy}" } });
        //return TypedResults.Ok(resultado);
    }

    [HttpPost("Registrar")]
    public async Task<Results<Created<BaseResponseDto>,BadRequest<BaseResponseDto>>> RegistraProyectoAsync([FromBody] RegistrarProyectoDtoRequest request)
    {
        var response = new BaseResponseDto();
        if (!ModelState.IsValid)
        {
            var modalStateListaError = ConstantesFunciones.ObtenerModalStateError(ModelState);
            response.Message = string.Join("&", modalStateListaError);

            return TypedResults.BadRequest(response); // devuelve errores de validación automáticamente
        }
        var nombreDecode = ConstantesFunciones.Base64Decode(request.nombre);
        var tokenHashString = ConstantesFunciones.Sha256Hash(request.token);
        var registerCommand = new RegistrarProyectoCommand
        {
            Token = tokenHashString,
            Nombre = nombreDecode,
            TipoToken = request.tipotoken,
            Permiso = request.permiso,
            FechaInicio = request.fechainicio
        };
        var resultado = await _handlerRegistrar.Handle(registerCommand);
        if (!resultado)
        {
            response.Message = "No se Pudo Registrar Usuario";
            return TypedResults.BadRequest(response); // devuelve 204 No Content si no se pudo registrar el token
        }
        response = new BaseResponseDto
        {
            Message = "Proyecto registrado correctamente",
            Success = true
        };
        return TypedResults.Created("/", response);
    }
}