namespace WebManagementProyect.BApplication.UseCases.TareaUseCases.CambiarEstadoTareal;

public class EstadoTareaCommand
{
    public Guid IdTarea { get; set; }
    public int Estado { get; set; } = 0;// "Pendiente", "En Progreso", "Completada", etc.
    public string Token { get; set; } = null!;// Token de autenticación o autorización
}
