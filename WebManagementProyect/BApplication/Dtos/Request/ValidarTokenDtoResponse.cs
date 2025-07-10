using System.ComponentModel.DataAnnotations;

namespace WebManagementProyect.BApplication.Dtos.Request
{
    public class ValidarTokenDtoResponse
    {
        [Required(ErrorMessage ="Requiere Token")]
        [MinLength(10,ErrorMessage ="Minimo de 10 caracteres")]
        public string Token { get; set; } = null!;
    }
}
