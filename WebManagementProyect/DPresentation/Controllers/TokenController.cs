using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebManagementProyect.BApplication.Dtos.Request;
using WebManagementProyect.BApplication.Dtos.Response;
using WebManagementProyect.BApplication.UseCases.TokenUseCases.ListarToken;
using WebManagementProyect.BApplication.UseCases.TokenUseCases.CrearToken;
using WebManagementProyect.EShared.Share;
using WebManagementProyect.BApplication.UseCases.TokenUseCases.ValidarToken;
using Microsoft.IdentityModel.Tokens;

namespace WebManagementProyect.DPresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly RegistrarTokenHandler _handlerRegistrar;
        private readonly ListarTokenHandler _handlerListar;
        private readonly ValidarTokenHandler _handlerValidar;

        public TokenController(RegistrarTokenHandler handlerRegistrar, ListarTokenHandler handlerListar,ValidarTokenHandler validarTokenHandler)
        {
            _handlerRegistrar = handlerRegistrar;
            _handlerListar = handlerListar;
            _handlerValidar = validarTokenHandler;
        }

        [HttpPost("Registrar")]
        public async Task<Results<Created<BaseResponseDto>,BadRequest<BaseResponseDto>>> RegistrarTokenAsync([FromBody] RegistrarTokenDtoRequest register)
        {
            var response = new BaseResponseDto();
            if (!ModelState.IsValid)
            {
                var modalStateListaError = ConstantesFunciones.ObtenerModalStateError(ModelState);
                response.Message = string.Join("&", modalStateListaError);

                return TypedResults.BadRequest(response); // devuelve errores de validación automáticamente
            }

            //var aliasDecode = ConstantesFunciones.Base64Decode(register.Alias);
            var tokenHashString = ConstantesFunciones.Sha256Hash(register.Token);
            var registerCommand = new RegistrarTokenCommand
            {
                Alias = register.Alias,
                Token = tokenHashString
            };
            var resultado = await _handlerRegistrar.Handle(registerCommand);
            if (!resultado)
            {
                response.Message = "No se Pudo Registrar Usuario, token similar";
                return TypedResults.BadRequest(response); // devuelve 204 No Content si no se pudo registrar el token
            }
            response = new BaseResponseDto
            {
                Message = "Usuario registrado correctamente",
                Success = true
            };
            return TypedResults.Created("/",response);
        }


        ////[HttpGet]
        ////public async Task<Results<Ok<List<ListarTokenCommand>>,NotFound>> ListarTokenAsync()
        ////{
        ////    var resultado = await _handlerListar.Handle();
        ////    if (resultado == null || !resultado.Any())
        ////    {
        ////        return TypedResults.NotFound();
        ////    }
        ////    return TypedResults.Ok(resultado);
        ////}


        [HttpPost("Validar")]
        public async Task<Results<Ok<BaseResponseDto>, BadRequest<BaseResponseDto>>> ValidarTokenAsync([FromBody] ValidarTokenDtoResponse request)
        {
            var response = new BaseResponseDto();
            if (!ModelState.IsValid)
            {
                var modalStateListaError = ConstantesFunciones.ObtenerModalStateError(ModelState);
                response.Message = string.Join("&", modalStateListaError);

                return TypedResults.BadRequest(response); // devuelve errores de validación automáticamente
            }
            var tokenHashString = ConstantesFunciones.Sha256Hash(request.Token);
            var validarTokenCommand = new ValidarTokenCommand
            {
                Token = tokenHashString
            };
            var resultado = await _handlerValidar.Handle(validarTokenCommand);
            if (resultado.IsNullOrEmpty())
            {
                response.Message = "No existe el usuario";
                return TypedResults.BadRequest(response); // devuelve 204 No Content si no se pudo registrar el token
            }
            response = new BaseResponseDto
            {
                Message = resultado,
                Success = true
            };
            return TypedResults.Ok(response);
        }
    }
}
