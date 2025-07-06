using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebManagementProyect.BApplication.Dtos;

namespace WebManagementProyect.EShared.Share;

public static class ConstantesFunciones
{
    public static List<ModalStateErrorDtoResponse> ObtenerModalStateError(ModelStateDictionary ModelState)
    {
        var modalStateListaError = ModelState.Where(x => x.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors.Select(e => new ModalStateErrorDtoResponse { Campo = x.Key, Message = e.ErrorMessage })).ToList();
        return  modalStateListaError;
    }
}
