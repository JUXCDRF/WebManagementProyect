using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebManagementProyect.BApplication.Dtos.Request
{
    public class ObtenerTareaDtoRequest
    {
        [Required(ErrorMessage = "Requiere Token de Autenticación")]
        [FromBody]
        public string token { get; set; } = string.Empty!;
    }
}
