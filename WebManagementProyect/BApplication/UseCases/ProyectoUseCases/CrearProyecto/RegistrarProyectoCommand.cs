using System.ComponentModel.DataAnnotations;

namespace WebManagementProyect.BApplication.UseCases.ProyectoUseCases.CrearProyecto;

public class RegistrarProyectoCommand
{
    public string Token { get; set; } = string.Empty!;
    public string Nombre { get; set; } = string.Empty!;
    public string TipoToken { get; set; } = "Proyecto"; // Asignar el tipo de token por defecto
    public int Permiso { get; set; }
    public DateTime FechaInicio { get; set; }
}
