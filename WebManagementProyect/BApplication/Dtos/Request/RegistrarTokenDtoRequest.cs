using System.ComponentModel.DataAnnotations;

namespace WebManagementProyect.BApplication.Dtos.Request
{
    public class RegistrarTokenDtoRequest
    {
        [Required(ErrorMessage ="Requiere Token")]
        [MinLength(10,ErrorMessage ="Toke requiere minimo 10 caracteres")]
        public string Token { get; set; } = null!;

        [Required(ErrorMessage = "Requiere Alias")]
        [MaxLength(100, ErrorMessage = "Toke requiere maximo 100 caracteres")]
        [MinLength(1, ErrorMessage = "Toke requiere minimo 1 caracteres")]
        public string Alias { get; set; } = null!;
    }
}
