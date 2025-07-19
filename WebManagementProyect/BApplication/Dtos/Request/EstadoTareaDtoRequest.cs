using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebManagementProyect.BApplication.Dtos.Request;

public class EstadoTareaDtoRequest
{
    [Required(ErrorMessage = "Requiere el token")]
    public string token { get; set; } = null!;

    [Required(ErrorMessage ="Requiere el campo Estado")]
    [Range(2, 3, ErrorMessage = "El estado debe ser 1 (Pendiente) o 2 (Finalizado)")]
    public int estado { get; set; }
}
