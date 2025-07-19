using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebManagementProyect.BApplication.Dtos.Request;

public class TareaListarDtoRequest
{
    [Required(ErrorMessage = "Requiere id")]
    [FromRoute]
    public Guid id { get; set; } // Assuming this is a Guid representing the task ID
    [Required(ErrorMessage ="Requiere el token")]
    [FromQuery]
    public string token { get; set; } = null!;//
    [Required(ErrorMessage = "Requiere el numero de elementos por pagina")]
    [FromQuery]
    public int pagesize { get; set; } = 5; //por defecto de 5 en 5 
    [Required(ErrorMessage = "Requiere el la pagina actual")]
    [FromQuery]
    public int pagenumber { get; set; } = 1;//por defecto la primera pagina

}
