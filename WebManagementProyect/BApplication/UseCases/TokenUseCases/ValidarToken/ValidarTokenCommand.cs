using System.ComponentModel.DataAnnotations;

namespace WebManagementProyect.BApplication.UseCases.TokenUseCases.ValidarToken;

public class ValidarTokenCommand
{
    [Required]
    [MaxLength(256)]
    [MinLength(256)]
    public string Token { get; set; } = null!;
}
