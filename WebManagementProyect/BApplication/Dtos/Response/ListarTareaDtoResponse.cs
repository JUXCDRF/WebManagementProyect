namespace WebManagementProyect.BApplication.Dtos.Response;

public class ProyectoPrincipalDtoResponse
{
    public string tituloprincipal { get; set; } = "";
    public List<ListarTareaDtoResponse> tareas { get; set; } = new List<ListarTareaDtoResponse>();
}
public class ListarTareaDtoResponse
{
    public string Id { get; set; } = "";
    public string fecha { get; set; } = "";
    public string horainicio { get; set; } = "";
    public string horafin { get; set; } = "";
    public string titulo { get; set; } = "";
    public string descripcion { get; set; } = "";
}
