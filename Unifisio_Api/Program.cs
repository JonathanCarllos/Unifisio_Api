using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using Unifisio_Api.Context;
using Unifisio_Api.Models;
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

var secretKey = builder.Configuration["JWT:SecretKey"]
                   ?? throw new ArgumentException("Invalid secret key!!");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes(secretKey))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));

    options.AddPolicy("SuperAdminOnly", policy =>
                       policy.RequireRole("Admin").RequireClaim("id", "JonathanCarlos"));

    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));

    options.AddPolicy("ExclusiveOnly", policy =>
                      policy.RequireAssertion(context =>
                      context.User.HasClaim(claim =>
                                           claim.Type == "id" && claim.Value == "JonathanCarlos")
                                           || context.User.IsInRole("SuperAdmin")));
});


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IFisioterapeutaService, FisioterapeutaService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IHistoricoClinicoService, HistoricoClinicoService>();
builder.Services.AddScoped<IEvolucaoPacienteService, EvolucaoPacienteService>();
builder.Services.AddScoped<IDocumentoPacienteService, DocumentoPacienteService>();
builder.Services.AddScoped<IPlanoTratamentoService, PlanoTratamentoService>();
builder.Services.AddScoped<IHorarioAtendimentoService, HorarioAtendimentoService>();
builder.Services.AddScoped<IConsultaProcedimentosService, ConsultaProcedimentoService>();
builder.Services.AddScoped<IRelatorioProdutividadeService, RelatorioProdutividadeService>();
builder.Services.AddScoped<IAgendamentoConsultaService, AgendamentoConsultaService>();
builder.Services.AddScoped<IFisioterapeutaDisponibilidadeService, FisioterapeutaDisponibilidadeService>();
builder.Services.AddScoped<IRegistroPresencaService, RegistroPresencaService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IFisioterapeutaRepository, FisioterapeutaRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IHistoricoClinicoRepository, HistoricoClinicoRepository>();
builder.Services.AddScoped<IEvolucaoPacienteRepository, EvolucaoPacienteRepository>();
builder.Services.AddScoped<IDocumentoPacienteRepository, DocumentoPacienteRepository>();
builder.Services.AddScoped<IPlanoTratamentoRepository, PlanoTratamentoRepository>();
builder.Services.AddScoped<IHorarioAtendimentoRepository, HorarioAtendimentoRepository>();
builder.Services.AddScoped<IConsultaProcedimentoRepository, ConsultaProcedimentoRepository>();
builder.Services.AddScoped<IRelatorioRepository, RelatorioRepository>();
builder.Services.AddScoped<IAgendamentoConsultaRepository, AgendamentoConsultaRepository>();
builder.Services.AddScoped<IFisioterapeutaDisponibilidadeRepository, FisioterapeutaDisponibilidadeRepository>();
builder.Services.AddScoped<IRegistroPresencaRepository, RegistroPresencaRepository>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "apicatalogo", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Bearer JWT ",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization();
//builder.Services.AddAuthentication("Bearer").AddJwtBearer(); 

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
