using System.ComponentModel.DataAnnotations;

namespace TaskTest.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public required string Descripcion { get; set; }
        public DateOnly FechaTarea { get; set; }
        public int Visibilidad { get; set; }
        public int Estado { get; set; }
        public int EstimacionId { get; set; }
        public Estimacion? Estimacion { get; set; }
        public bool Completado { get; set; }
    }

    public enum EVisibility
    {
        Public = 1,
        Private
    }

    public enum EEstado
    {
        Normal = 1,
        Prioridad,
    }
}
