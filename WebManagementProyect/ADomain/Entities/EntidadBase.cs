namespace WebManagementProyect.ADomain.Entities
{
    public class EntidadBase
    {
        public Guid Id { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public bool Eliminado { get; set; } = false;
        public DateTime? FechaEliminado { get; set; }
        public string? MotivoEliminado { get; set; }
    }
}
