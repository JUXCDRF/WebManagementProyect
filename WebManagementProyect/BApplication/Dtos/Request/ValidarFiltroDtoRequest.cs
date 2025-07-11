using System.ComponentModel.DataAnnotations;

namespace WebManagementProyect.BApplication.Dtos.Request
{
    public class ValidarFiltroDtoRequest
    {
        [Required(ErrorMessage = "Requiere Token")]
        [MinLength(10, ErrorMessage = "Minimo de 10 caracteres")]
        public string token { get; set; } = null!;
        public string filtro { get; set; } = "";
    }
}
