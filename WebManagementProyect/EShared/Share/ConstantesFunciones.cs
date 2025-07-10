using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Win32;
using WebManagementProyect.BApplication.Dtos;

namespace WebManagementProyect.EShared.Share;

public static class ConstantesFunciones
{
    public static List<string> ObtenerModalStateError(ModelStateDictionary ModelState)
    {
        var modalStateListaError = ModelState.Where(x => x.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors.Select(e => $"{x.Key} : {e.ErrorMessage}")).ToList();
        return  modalStateListaError;
    }
    public static string Sha256Hash(string token)
    {
        var tokenByte = Convert.FromBase64String(token);
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var tokenHash = sha256.ComputeHash(tokenByte);
        return BitConverter.ToString(tokenHash).Replace("-", "").ToUpper();
    }
    public static string Base64Decode(string base64String)
    {
        var base64Byte = Convert.FromBase64String(base64String);
        return System.Text.Encoding.UTF8.GetString(base64Byte);
    }
}
