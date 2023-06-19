using Aplicacion.Interfaces;
using Aplicacion.Clases;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using APIBlockchain.Clases;
using APIBlockchain.Interfaces;
using Web3.Storage.Interfaces;
using Web3.Storage.Clases; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("AppCon");
builder.Services.AddDbContext<ProvacySegurosContext>(x => x.UseSqlServer(conn));

//builder.Services.AddHttpClient<IWeb3StorageClient, Web3StorageClient>(client =>
//{
//    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("Endpoints:UrlWeb3Storage"));
//    client.Timeout = TimeSpan.FromSeconds(20);
//    client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJkaWQ6ZXRocjoweEVCMEE1MzhiRDgzRDQ1NDE5RDU0NUIyNTU5MTg5MWMwODU1QjQ1MTgiLCJpc3MiOiJ3ZWIzLXN0b3JhZ2UiLCJpYXQiOjE2ODcxNDY2ODMzNDgsIm5hbWUiOiJQcnVlYmFQcm92YWN5In0.xu0AxQvcCYB8Pqu2EGGc9giq4nWAqK4jeUYdGuSHfRA");
//});


builder.Services.AddControllers();
builder.Services.AddScoped<IUsuario, UsuarioApp>();
builder.Services.AddScoped<IHash, Hash>();
builder.Services.AddScoped<IColaborador, ColaboradorApp>();
builder.Services.AddScoped<IArchivoWeb, ArchivoWeb>();
builder.Services.AddScoped<IWeb3StorageClient, Web3StorageClient>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(p => p.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
