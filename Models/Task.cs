using System.ComponentModel.DataAnnotations;

namespace TaskTest.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public required string Descripcion { get; set; }
        public DateOnly FechaTarea { get; set; }
        public bool Public { get; set; }
        public int Estado { get; set; }
        public int Estimacion { get; set; }
    }
}
