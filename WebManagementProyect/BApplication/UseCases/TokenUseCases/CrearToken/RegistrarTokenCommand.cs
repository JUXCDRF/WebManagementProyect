using System.ComponentModel.DataAnnotations;

namespace WebManagementProyect.BApplication.UseCases.TokenUseCases.CrearToken;

public class RegistrarTokenCommand
{
    [Required]
    [MaxLength(256)]
    [MinLength(256)]
    public string Token { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    [MinLength(1)]
    public string Alias { get; set; } = null!;
}
