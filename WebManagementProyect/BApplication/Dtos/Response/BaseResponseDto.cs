namespace WebManagementProyect.BApplication.Dtos.Response;

public class BaseResponseDto
{
    public bool Success { get; set; } = false;
    public string? Message { get; set; } = "";
}
