using Microsoft.EntityFrameworkCore;
using TaskTest.Context;
using TaskTest.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(context => context.UseNpgsql(connection));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Ejecutar migraciones al levantar la app
//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    db.Database.Migrate();
//}

// Endpoint Test
app.MapGet("/Tarea", async (ApplicationDbContext db) => await db.Tareas.ToListAsync());

app.MapPost("/tareas/seed", async (ApplicationDbContext db) =>
{
    if (await db.Tareas.AnyAsync())
        return Results.BadRequest("La tabla ya tiene registros, no se puede volver a sembrar.");

    var tareas = new List<Tarea>
    {
        new Tarea { Descripcion = "Diseñar la arquitectura del sistema", FechaTarea = new DateOnly(2025, 10, 1), Public = true, Estado = 1, Estimacion = 8 },
        new Tarea { Descripcion = "Implementar autenticación JWT", FechaTarea = new DateOnly(2025, 10, 2), Public = false, Estado = 0, Estimacion = 5 },
        new Tarea { Descripcion = "Configurar CI/CD en GitHub Actions", FechaTarea = new DateOnly(2025, 10, 3), Public = true, Estado = 2, Estimacion = 3 },
        new Tarea { Descripcion = "Crear pruebas unitarias para UserService", FechaTarea = new DateOnly(2025, 10, 4), Public = false, Estado = 1, Estimacion = 4 },
        new Tarea { Descripcion = "Optimizar consultas con EF Core", FechaTarea = new DateOnly(2025, 10, 5), Public = true, Estado = 0, Estimacion = 6 },
        new Tarea { Descripcion = "Integrar pagos con Stripe", FechaTarea = new DateOnly(2025, 10, 6), Public = false, Estado = 2, Estimacion = 7 },
        new Tarea { Descripcion = "Revisión de seguridad OWASP", FechaTarea = new DateOnly(2025, 10, 7), Public = true, Estado = 1, Estimacion = 5 },
        new Tarea { Descripcion = "Crear documentación de API con Swagger", FechaTarea = new DateOnly(2025, 10, 8), Public = true, Estado = 2, Estimacion = 2 },
        new Tarea { Descripcion = "Implementar notificaciones en tiempo real", FechaTarea = new DateOnly(2025, 10, 9), Public = false, Estado = 0, Estimacion = 6 },
        new Tarea { Descripcion = "Refactorizar código legacy", FechaTarea = new DateOnly(2025, 10, 10), Public = true, Estado = 1, Estimacion = 4 }
    };

    db.Tareas.AddRange(tareas);
    await db.SaveChangesAsync();

    return Results.Ok($"{tareas.Count} tareas insertadas correctamente.");
});


app.Run();
