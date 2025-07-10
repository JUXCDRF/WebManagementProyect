using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebManagementProyect.BApplication.UseCases.ProyectoUseCases.ListaProyecto;
using WebManagementProyect.BApplication.UseCases.TokenUseCases.ListarToken;

namespace WebManagementProyect.DPresentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProyectoController : ControllerBase
{
    private readonly ListarProyectoHandler _handlerListar;

    public ProyectoController(ListarProyectoHandler handlerListar)
    {
        _handlerListar = handlerListar;
    }

    [HttpGet("Listar")]
    public async Task<Results<Ok<List<ListarProyectoCommand>>, NotFound>> ListarProyectoAsync()
    {
        //var resultado = await _handlerListar.Handle();
        return TypedResults.Ok(new List<ListarProyectoCommand>() { new ListarProyectoCommand { Id = "", nombre = "No se encontro Proyectos", fecha = $"{DateTime.Now:dd/MM/yyyy}" } });
        //return TypedResults.Ok(resultado);
    }

    [HttpPost("Registrar")]
    public async Task<Results<Ok<bool>>, NotFound>> RegistraProyectoAsync()
    { 

    }
}