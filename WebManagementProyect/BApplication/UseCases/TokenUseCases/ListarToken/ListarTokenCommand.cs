namespace WebManagementProyect.BApplication.UseCases.TokenUseCases.ListarToken;

public class ListarTokenCommand
{
    public string token { get; set; } = string.Empty;
    public string usuario { get; set; } = string.Empty;
    public string fechaCreacion { get; set; } = string.Empty;
}
