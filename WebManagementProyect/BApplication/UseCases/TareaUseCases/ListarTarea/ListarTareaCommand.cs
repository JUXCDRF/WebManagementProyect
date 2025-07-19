using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebManagementProyect.BApplication.UseCases.TareaUseCases.ListarTarea;

public class ListarTareaCommand
{
    public Guid Id { get; set; } // Assuming this is a Guid representing the task ID
    public string Token { get; set; } = null!;//
    public int PageSize { get; set; } = 5; //por defecto de 5 en 5 
    public int PageNumber { get; set; } = 1;//por defecto la primera pagina
}
