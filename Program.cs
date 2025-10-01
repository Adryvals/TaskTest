using Microsoft.EntityFrameworkCore;
using TaskTest.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("Tarea");
builder.Services.AddDbContext<ApplicationDbContext>(context => context.UseNpgsql(connection));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Endpoint Test
app.MapGet("/Tarea", async (ApplicationDbContext db) => await db.Tareas.ToListAsync());


app.Run();
