using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebManagementProyect.BApplication.Dtos;

namespace WebManagementProyect.EShared.Share;

public static class ConstantesFunciones
{
    public static List<string> ObtenerModalStateError(ModelStateDictionary ModelState)
    {
        var modalStateListaError = ModelState.Where(x => x.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors.Select(e => $"{x.Key}:{e.ErrorMessage}")).ToList();
        return  modalStateListaError;
    }
}
