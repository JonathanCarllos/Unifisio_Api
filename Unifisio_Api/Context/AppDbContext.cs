﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Unifisio_Api.Models;

namespace Unifisio_Api.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Fisioterapeuta> Fisioterapeutas { get; set; }
        public DbSet<HistoricoClinico> HistoricoClinico { get; set; }
        public DbSet<EvolucaoPaciente> EvolucaoPacientes { get; set; }
        public DbSet<DocumentoPaciente> DocumentoPacientes { get; set; }
        public DbSet<PlanoTratamento> PlanoTratamentos { get; set; }
        public DbSet<HorarioAtendimento> HorarioAtendimentos { get; set; }
        public DbSet<ConsultaProcedimento> ConsultaProcedimentos { get; set; }
        public DbSet<RelatorioProdutividade> RelatorioProdutividades { get; set; }
        public DbSet<AgendamentoConsulta> AgendamentoConsultas { get; set; }
        public DbSet<FisioterapeutaDisponibilidade> FisioterapeutaDisponibilidades { get; set; }
        public DbSet<RegistroPresenca> RegistroPresencas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        } 

    }
}
