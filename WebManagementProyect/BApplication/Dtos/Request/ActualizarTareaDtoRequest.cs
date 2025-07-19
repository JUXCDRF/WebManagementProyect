using System.ComponentModel.DataAnnotations;

namespace WebManagementProyect.BApplication.Dtos.Request;

public class ActualizarTareaDtoRequest
{
    [Required(ErrorMessage = "Requiere id Tarea")]
    public Guid id { get; set; } // Assuming this is a Guid representing the task ID

    [Required(ErrorMessage = "Requiere el token")]
    [MinLength(10, ErrorMessage = "El token debe tener al menos 10 caracteres")]
    public string token { get; set; } = null!;//

    [Required(ErrorMessage = "Requiere el titulo")]
    [MinLength(10, ErrorMessage = "El titulo debe tener al menos 10 caracteres")]
    public string titulo { get; set; } = null!;

    [Required(ErrorMessage = "Requiere el descripcion")]
    public string descripcion { get; set; } = null!;

    [Required(ErrorMessage = "Requiere el fecha")]
    public DateTime fecha { get; set; }

    [Required(ErrorMessage = "Requiere el horaInicio")]
    public string horainicio { get; set; } = null!;

    [Required(ErrorMessage = "Requiere el horaFin")]
    public string horafin { get; set; } = null!;
}
