using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebManagementProyect.BApplication.Dtos;
using WebManagementProyect.BApplication.UseCases.TokenUseCases.ListarToken;
using WebManagementProyect.BApplication.UseCases.TokenUseCases.RegisterToken;

namespace WebManagementProyect.DPresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly RegisterTokenHandler _handlerRegistrar;
        private readonly ListarTokenHandler _handlerListar;

        public TokenController(RegisterTokenHandler handlerRegistrar, ListarTokenHandler handlerListar)
        {
            _handlerRegistrar = handlerRegistrar;
            _handlerListar = handlerListar;
        }

        [HttpPost]
        public async Task<Results<Created,BadRequest<List<ModalStateErrorDtoResponse>>,BadRequest<string>>> RegistrarTokenAsync([FromBody] RegisterTokenCommand register)
        {
            if (!ModelState.IsValid)
            {
                var modalStateListaError = ModelState.Where(x => x.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors.Select(e => new ModalStateErrorDtoResponse { Campo=x.Key,Message=e.ErrorMessage })).ToList();
                return TypedResults.BadRequest(modalStateListaError); // devuelve errores de validación automáticamente
            }
            var resultado = await _handlerRegistrar.Handle(register);
            if (!resultado)
            {
                return TypedResults.BadRequest("No se Pudo Registrar"); // devuelve 204 No Content si no se pudo registrar el token
            }
            return TypedResults.Created();
        }


        [HttpGet]
        public async Task<Results<Ok<List<ListarTokenCommand>>,NotFound>> ListarTokenAsync()
        {
            var resultado = await _handlerListar.Handle();
            if (resultado == null || !resultado.Any())
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(resultado);
        }
    }
}
