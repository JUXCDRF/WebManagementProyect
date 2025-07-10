using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebManagementProyect.BApplication.Dtos;
using WebManagementProyect.BApplication.UseCases.TokenUseCases.ListarToken;
using WebManagementProyect.BApplication.UseCases.TokenUseCases.RegisterToken;
using WebManagementProyect.EShared.Share;

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

        [HttpPost("Registrar")]
        public async Task<Results<Created<BaseResponseDto>,BadRequest<BaseResponseDto>,BadRequest<string>>> RegistrarTokenAsync([FromBody] RegistrarTokenDtoRequest register)
        {
            var response = new BaseResponseDto();
            if (!ModelState.IsValid)
            {
                var modalStateListaError = ConstantesFunciones.ObtenerModalStateError(ModelState);
                response.Message = string.Join("&", modalStateListaError);

                return TypedResults.BadRequest(response); // devuelve errores de validación automáticamente
            }
            var aliasByte = Convert.FromBase64String(register.Alias);
            var aliasDecode = System.Text.Encoding.UTF8.GetString(aliasByte);
            var tokenByte = Convert.FromBase64String(register.Token);
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var tokenHash = sha256.ComputeHash(tokenByte);
            var tokenHashString = BitConverter.ToString(tokenHash).Replace("-", "").ToUpper();
            var registerCommand = new RegisterTokenCommand
            {
                Alias = aliasDecode,
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
