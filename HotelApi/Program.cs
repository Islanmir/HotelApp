using HotelApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 👇 Ligar ao MySQL com o connection string do appsettings.json
var cs = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<HotelContext>(options =>
{
    options.UseMySql(
        cs,
        ServerVersion.AutoDetect(cs),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
    );
});

// 👇 Adicionar controladores (necessário para as rotas da API)
builder.Services.AddControllers();

// 👇 Ativar CORS para permitir pedidos do Blazor (http://localhost:5201)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
    {
        policy.WithOrigins("http://localhost:5201") // endereço do HotelWeb
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// 👇 Configuração básica de pipeline HTTP
app.UseHttpsRedirection();

// 👇 Aplicar a política de CORS
app.UseCors("AllowBlazor");

app.MapControllers();

app.Run();

