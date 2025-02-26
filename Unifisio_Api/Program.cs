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
builder.Services.AddScoped<IHistoricoClinicoService, HistoricoClinicoService>();
builder.Services.AddScoped<IEvolucaoPacienteService, EvolucaoPacienteService>();
builder.Services.AddScoped<IDocumentoPacienteService, DocumentoPacienteService>();
builder.Services.AddScoped<IPlanoTratamentoService, PlanoTratamentoService>();

builder.Services.AddScoped<IFisioterapeutaRepository, FisioterapeutaRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IHistoricoClinicoRepository, HistoricoClinicoRepository>();
builder.Services.AddScoped<IEvolucaoPacienteRepository, EvolucaoPacienteRepository>();
builder.Services.AddScoped<IDocumentoPacienteRepository, DocumentoPacienteRepository>();
builder.Services.AddScoped<IPlanoTratamentoRepository, PlanoTratamentoRepository>();

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
