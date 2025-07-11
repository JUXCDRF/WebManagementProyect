using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebManagementProyect.BApplication.Dtos.Request;

public class TareaListarDtoRequest
{
    [Required(ErrorMessage = "Requiere id")]
    [FromRoute]
    public Guid id { get; set; } // Assuming this is a Guid representing the task ID
    [FromQuery]
    [Required(ErrorMessage ="Requiere el token")]
    public string token { get; set; } = null!;//
}
