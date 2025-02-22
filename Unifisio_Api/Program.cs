using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Unifisio_Api.Context;
using Unifisio_Api.Repository;
using Unifisio_Api.Repository.Interface;
using Unifisio_Api.Services;
using Unifisio_Api.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var mySql = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
             options.UseMySql(mySql, ServerVersion
                    .AutoDetect(mySql)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IFisioterapeutaService, FisioterapeutaService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IFisioterapeutaRepository, FisioterapeutaRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();

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

app.Run();
