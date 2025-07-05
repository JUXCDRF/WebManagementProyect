using System.ComponentModel.DataAnnotations;

namespace WebManagementProyect.BApplication.UseCases.TokenUseCases.RegisterToken;

public class RegisterTokenCommand
{
    [Required]
    [MaxLength(256)]
    [MinLength(256)]
    public string Token { get; set; } = null!;
}
