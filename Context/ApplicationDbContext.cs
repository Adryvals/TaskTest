﻿using Microsoft.EntityFrameworkCore;
using TaskTest.Models;

namespace TaskTest.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext() { }
        public virtual DbSet<Tarea> Tareas { get; set; }
        public virtual DbSet<Estimacion> Estimaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estimacion>().HasData(
                new Estimacion { Id = 1, Duration = 5, Activo = true },
                new Estimacion { Id = 2, Duration = 10, Activo = true },
                new Estimacion { Id = 3, Duration = 15, Activo = true },
                new Estimacion { Id = 4, Duration = 20, Activo = true },
                new Estimacion { Id = 5, Duration = 25, Activo = true },
                new Estimacion { Id = 6, Duration = 30, Activo = true },
                new Estimacion { Id = 7, Duration = 40, Activo = true },
                new Estimacion { Id = 8, Duration = 50, Activo = true }
            );

            modelBuilder.Entity<Tarea>().HasData(
                new Tarea { Id = 1, Descripcion = "Diseñar la arquitectura del sistema", FechaTarea = new DateOnly(2025, 10, 1), Visibilidad = (int)EVisibility.Public, Estado = 1, EstimacionId = 8, Completado = true },
                new Tarea { Id = 2, Descripcion = "Implementar autenticación JWT", FechaTarea = new DateOnly(2025, 10, 2), Visibilidad = (int)EVisibility.Private, Estado = 0, EstimacionId = 5, Completado = true },
                new Tarea { Id = 3, Descripcion = "Configurar CI/CD en GitHub Actions", FechaTarea = new DateOnly(2025, 10, 3), Visibilidad = (int)EVisibility.Public, Estado = 2, EstimacionId = 3, Completado = true },
                new Tarea { Id = 4, Descripcion = "Crear pruebas unitarias para UserService", FechaTarea = new DateOnly(2025, 10, 4), Visibilidad = (int)EVisibility.Private, Estado = 1, EstimacionId = 4 , Completado = false },
                new Tarea { Id = 5, Descripcion = "Optimizar consultas con EF Core", FechaTarea = new DateOnly(2025, 10, 5), Visibilidad = (int)EVisibility.Public, Estado = 0, EstimacionId = 6 , Completado = true },
                new Tarea { Id = 6, Descripcion = "Integrar pagos con Stripe", FechaTarea = new DateOnly(2025, 10, 6), Visibilidad = (int)EVisibility.Private, Estado = 2, EstimacionId = 7 , Completado = false },
                new Tarea { Id = 7, Descripcion = "Revisión de seguridad OWASP", FechaTarea = new DateOnly(2025, 10, 7), Visibilidad = (int)EVisibility.Public, Estado = 1, EstimacionId = 5 , Completado = false },
                new Tarea { Id = 8, Descripcion = "Crear documentación de API con Swagger", FechaTarea = new DateOnly(2025, 10, 8), Visibilidad = (int)EVisibility.Public, Estado = 2, EstimacionId = 2, Completado = false },
                new Tarea { Id = 9, Descripcion = "Implementar notificaciones en tiempo real", FechaTarea = new DateOnly(2025, 10, 9), Visibilidad = (int)EVisibility.Private, Estado = 0, EstimacionId = 6, Completado = false },
                new Tarea { Id = 10, Descripcion = "Refactorizar código legacy", FechaTarea = new DateOnly(2025, 10, 10), Visibilidad = (int)EVisibility.Public, Estado = 1, EstimacionId = 4, Completado = true }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Usar la variable de entorno si existe
                var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

                if (!string.IsNullOrEmpty(connectionString))
                    optionsBuilder.UseNpgsql(connectionString);
                else
                    throw new InvalidOperationException("Connection string no encontrada.");
            }
        }
    }
}
