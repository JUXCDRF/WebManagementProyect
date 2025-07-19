namespace WebManagementProyect.BApplication.Dtos.Response;

public class ProyectoPrincipalDtoResponse
{
    public string tituloprincipal { get; set; } = "";
    public List<ListarTareaDtoResponse> tareas { get; set; } = new List<ListarTareaDtoResponse>();

    public int pagesize { get; set; } = 5; //bloque de cuanto en cuanto muestra
    public int pagenumber { get; set; } = 1; //numero de la pagina
    public int totalcount { get; set; } = 0; //total en la lista
}
public class ListarTareaDtoResponse
{
    public string id { get; set; } = "";
    public string fecha { get; set; } = "";
    public string horainicio { get; set; } = "";
    public string horafin { get; set; } = "";
    public string titulo { get; set; } = "";
    public string descripcion { get; set; } = "";
    public int estado { get; set; } = 0;
}
