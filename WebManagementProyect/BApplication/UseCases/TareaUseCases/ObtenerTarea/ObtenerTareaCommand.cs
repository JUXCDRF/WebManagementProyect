namespace WebManagementProyect.BApplication.UseCases.TareaUseCases.ObtenerTarea;

public class ObtenerTareaCommand
{ 
    public bool Success { get; set; } = false;
    public string Message { get; set; } = "";
    public string Titulo { get; set; } = "";
    public string Horainicio { get; set; }="HH:mm";
    public string Horafin { get; set; } = "HH:mm";
    public string Fecha { get; set; } = $"{DateTime.Now:dd/MM/yyyy}";
    public string Descripcion { get; set; } = "";
}
