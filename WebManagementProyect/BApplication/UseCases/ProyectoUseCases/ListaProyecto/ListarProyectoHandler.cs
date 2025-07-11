using WebManagementProyect.ADomain.InterfacesRepository;

namespace WebManagementProyect.BApplication.UseCases.ProyectoUseCases.ListaProyecto;

public class ListarProyectoHandler
{
    readonly IProyectoRepository _proyectoRepository;
    readonly ITokenRepository _tokenRepository;

    public ListarProyectoHandler(IProyectoRepository proyectoRepository , ITokenRepository tokenRepository)
    {
        _proyectoRepository = proyectoRepository;
        _tokenRepository = tokenRepository;
    }

    public async Task<List<ListarProyectoCommand>> Handle(string token,string filtro="")
    {
        var exiteToken = await _tokenRepository.ValidarTokenHashAsync(token);
        if (!exiteToken)
        {
            return new List<ListarProyectoCommand>() { new ListarProyectoCommand { Id = "", nombre = "No token Validdo", fecha = $"{DateTime.Now:dd/MM/yyyy}" } };
        }
        var Idtoken = await _tokenRepository.GetIdnByHashAsync(token);
        var proyectos = new List<ListarProyectoCommand>();
        if (string.IsNullOrEmpty(filtro))
        {
            proyectos = await _proyectoRepository.GetNameProyectosByTokenAsync(Idtoken);

            if (proyectos == null || !proyectos.Any())
            {
                return new List<ListarProyectoCommand>() { new ListarProyectoCommand { Id = "", nombre = "No se encontro Proyectos", fecha = $"{DateTime.Now:dd/MM/yyyy}" } };
            }
            return proyectos;
        }
            proyectos = await _proyectoRepository.GetNameProyectosByTokenAsync(Idtoken,filtro);

        if (proyectos == null || !proyectos.Any())
        {
            return new List<ListarProyectoCommand>(){ new ListarProyectoCommand { Id="",nombre="No se encontro Proyectos", fecha=$"{DateTime.Now:dd/MM/yyyy}" } };
        }
        return proyectos;
    }
}
