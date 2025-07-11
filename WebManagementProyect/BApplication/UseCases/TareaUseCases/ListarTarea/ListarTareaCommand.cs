using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebManagementProyect.BApplication.UseCases.TareaUseCases.ListarTarea;

public class ListarTareaCommand
{
    public Guid id { get; set; } // Assuming this is a Guid representing the task ID
    public string token { get; set; } = null!;//
}
