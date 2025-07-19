namespace WebManagementProyect.BApplication.UseCases.TareaUseCases.CrearTarea
{
    public class CrearTareaCommand
    {
        public string Token { get; set; } = string.Empty!; // Assuming this is a string representation of a Guid
        public Guid IdProyecto { get; set; }
        public string Titulo { get; set; } = string.Empty!;
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = "";
    }
}
