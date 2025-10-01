using Microsoft.EntityFrameworkCore;
using TaskTest.Models;

namespace TaskTest.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext() { }
        public virtual DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tarea>().HasData(
                new Tarea { Id = 1, Descripcion = "Diseñar la arquitectura del sistema", FechaTarea = new DateOnly(2025, 10, 1), Public = true, Estado = 1, Estimacion = 8 },
                new Tarea { Id = 2, Descripcion = "Implementar autenticación JWT", FechaTarea = new DateOnly(2025, 10, 2), Public = false, Estado = 0, Estimacion = 5 },
                new Tarea { Id = 3, Descripcion = "Configurar CI/CD en GitHub Actions", FechaTarea = new DateOnly(2025, 10, 3), Public = true, Estado = 2, Estimacion = 3 },
                new Tarea { Id = 4, Descripcion = "Crear pruebas unitarias para UserService", FechaTarea = new DateOnly(2025, 10, 4), Public = false, Estado = 1, Estimacion = 4 },
                new Tarea { Id = 5, Descripcion = "Optimizar consultas con EF Core", FechaTarea = new DateOnly(2025, 10, 5), Public = true, Estado = 0, Estimacion = 6 },
                new Tarea { Id = 6, Descripcion = "Integrar pagos con Stripe", FechaTarea = new DateOnly(2025, 10, 6), Public = false, Estado = 2, Estimacion = 7 },
                new Tarea { Id = 7, Descripcion = "Revisión de seguridad OWASP", FechaTarea = new DateOnly(2025, 10, 7), Public = true, Estado = 1, Estimacion = 5 },
                new Tarea { Id = 8, Descripcion = "Crear documentación de API con Swagger", FechaTarea = new DateOnly(2025, 10, 8), Public = true, Estado = 2, Estimacion = 2 },
                new Tarea { Id = 9, Descripcion = "Implementar notificaciones en tiempo real", FechaTarea = new DateOnly(2025, 10, 9), Public = false, Estado = 0, Estimacion = 6 },
                new Tarea { Id = 10, Descripcion = "Refactorizar código legacy", FechaTarea = new DateOnly(2025, 10, 10), Public = true, Estado = 1, Estimacion = 4 }
            );
        }
    }
}
