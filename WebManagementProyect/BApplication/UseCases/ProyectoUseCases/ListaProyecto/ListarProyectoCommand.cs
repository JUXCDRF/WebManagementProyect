namespace WebManagementProyect.BApplication.UseCases.ProyectoUseCases.ListaProyecto;

public class ListarProyectoCommand
{
    public string Id { get; set; } = string.Empty!; // Assuming this is a string representation of a Guid
    public string nombre { get; set; } = string.Empty!;
    public string fecha { get; set; } = string.Empty!;
}
