using System.ComponentModel.DataAnnotations;

namespace WebManagementProyect.BApplication.Dtos
{
    public class RegistrarTokenDtoRequest
    {
        [Required]
        [MinLength(10)]
        public string Token { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Alias { get; set; } = null!;
    }
}
