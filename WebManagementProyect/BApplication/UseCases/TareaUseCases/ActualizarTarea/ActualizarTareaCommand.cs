namespace WebManagementProyect.BApplication.UseCases.TareaUseCases.ActualizarTarea;

public class ActualizarTareaCommand
{
    public string Token { get; set; } = string.Empty!; // Assuming this is a string representation of a Guid
    public Guid IdTarea { get; set; }
    public string Titulo { get; set; } = string.Empty!;
    public TimeOnly HoraInicio { get; set; }
    public TimeOnly HoraFin { get; set; }
    public DateTime Fecha { get; set; }
    public string Descripcion { get; set; } = "";
}
