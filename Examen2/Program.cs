using Examen2.Services;
using Examen2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

//Configurar conexion a DB 
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseDB")));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mi API de Examen2",
        Version = "v1.0",
        Description = "Documentacion de API para Aplicacion de Tareas"
    });
}
    );

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<TareaService>();

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();