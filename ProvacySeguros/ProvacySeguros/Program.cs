using Aplicacion.Interfaces;
using Aplicacion.Clases;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using APIBlockchain.Clases;
using APIBlockchain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("AppCon");
builder.Services.AddDbContext<ProvacySegurosContext>(x => x.UseSqlServer(conn));

builder.Services.AddScoped<IUsuario, UsuarioApp>();
builder.Services.AddScoped<IHash, Hash>();

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

app.Run();
