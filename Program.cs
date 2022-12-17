using Microsoft.EntityFrameworkCore;
using MaderasProveedores.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// lineas que necesita entity framework para establecer la conexiòn con la Db (paso 7)
var connectionString = builder.Configuration.GetConnectionString("AppConnection");
builder.Services.AddDbContext<MaderasProveedoresContext>(x => x.UseSqlServer(connectionString));
//Paso 10 obtiene los ensamblados de los componentes para que podamos utilizarlos 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//

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
