using System.ComponentModel.DataAnnotations;

namespace WebManagementProyect.BApplication.Dtos.Request;

public class RegistrarProyectoDtoRequest
{
    [Required(ErrorMessage = "Requiere Token")]
    public string token { get; set; } = string.Empty!;
    [Required(ErrorMessage = "Requiere Nombre")]
    public string nombre { get; set; } = string.Empty!;
    public string tipotoken { get; set; } = "Proyecto"; // Asignar el tipo de token por defecto
    [Required(ErrorMessage = "Requiere Permisos")]
    [Range(1, 2, ErrorMessage ="Solo se puede 1 Editar o 2 Lectura")]
    public int permiso { get; set; } = 0;
    [Required(ErrorMessage ="Requiere Fecha Inicio")]
    public DateTime fechainicio { get; set; }
}
