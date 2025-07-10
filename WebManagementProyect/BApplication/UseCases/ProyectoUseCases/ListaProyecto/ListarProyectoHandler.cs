using WebManagementProyect.ADomain.InterfacesRepository;

namespace WebManagementProyect.BApplication.UseCases.ProyectoUseCases.ListaProyecto;

public class ListarProyectoHandler
{
    readonly IProyectoRepository _proyectoRepository;

    public ListarProyectoHandler(IProyectoRepository proyectoRepository)
    {
        _proyectoRepository = proyectoRepository;
    }

    public async Task<List<ListarProyectoCommand>> Handle(Guid Idtoken, Guid Idproyecto)
    {
        var proyectos = await _proyectoRepository.GetNameProyectosByTokenAsync(Idtoken, Idproyecto);
        if (proyectos == null || !proyectos.Any())
        {
            return new List<ListarProyectoCommand>(){ new ListarProyectoCommand { Id="",nombre="No se encontro Proyectos", fecha=$"{DateTime.Now:dd/MM/yyyy}" } };
        }
        return proyectos;
    }
}
