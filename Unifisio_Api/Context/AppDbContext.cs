using Microsoft.EntityFrameworkCore;
using Unifisio_Api.Models;

namespace Unifisio_Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Fisioterapeuta> Fisioterapeutas { get; set; }      
        public DbSet<HistoricoClinico> HistoricoClinico { get; set; }
        public DbSet<EvolucaoPaciente> EvolucaoPacientes { get; set; }
        public DbSet<DocumentoPaciente> DocumentoPacientes { get; set; }
        public DbSet<PlanoTratamento> PlanoTratamentos { get; set; }

    }
}
