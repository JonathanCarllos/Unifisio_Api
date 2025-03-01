﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Unifisio_Api.Context;

#nullable disable

namespace Unifisio_Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250228225907_AtualizadoFisioterapeuta")]
    partial class AtualizadoFisioterapeuta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Unifisio_Api.Models.DocumentoPaciente", b =>
                {
                    b.Property<int>("DocumentoPacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("DocumentoPacienteId"));

                    b.Property<string>("CaminhoArquivo")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DataUpload")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomeArquivo")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("DocumentoPacienteId");

                    b.HasIndex("PacienteId");

                    b.ToTable("DocumentoPacientes");
                });

            modelBuilder.Entity("Unifisio_Api.Models.EvolucaoPaciente", b =>
                {
                    b.Property<int>("EvolucaoPacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("EvolucaoPacienteId"));

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FisioterapeutaId")
                        .HasColumnType("int");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("PlanoProximoPasso")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("EvolucaoPacienteId");

                    b.HasIndex("FisioterapeutaId");

                    b.HasIndex("PacienteId");

                    b.ToTable("EvolucaoPacientes");
                });

            modelBuilder.Entity("Unifisio_Api.Models.Fisioterapeuta", b =>
                {
                    b.Property<int>("FisioterapeutaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("FisioterapeutaId"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Crefito")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar(75)");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("FisioterapeutaId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Fisioterapeutas");
                });

            modelBuilder.Entity("Unifisio_Api.Models.HistoricoClinico", b =>
                {
                    b.Property<int>("HistoricoClinicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("HistoricoClinicoId"));

                    b.Property<string>("Diagnostico")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("Restricoes")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("TratamentosAnteriores")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("HistoricoClinicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("HistoricoClinico");
                });

            modelBuilder.Entity("Unifisio_Api.Models.Paciente", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PacienteId"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("BairroConv")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("CelularResponsavel")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("CepConv")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CidadeConv")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cnpj")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CpfResponsavel")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar(75)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("EstadoCivil")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LogradouroConv")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NomeResponsavel")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NumeroCasa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("NumeroConv")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ObsMedica")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("RazaoSocial")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("TelefoneConv")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("TipoPlanos")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UfConvenio")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("PacienteId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Unifisio_Api.Models.PlanoTratamento", b =>
                {
                    b.Property<int>("PlanoTratamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PlanoTratamentoId"));

                    b.Property<bool>("Concluido")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int>("SessoesRealizadas")
                        .HasColumnType("int");

                    b.Property<int>("TotalSessoes")
                        .HasColumnType("int");

                    b.HasKey("PlanoTratamentoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("PlanoTratamentos");
                });

            modelBuilder.Entity("Unifisio_Api.Models.DocumentoPaciente", b =>
                {
                    b.HasOne("Unifisio_Api.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Unifisio_Api.Models.EvolucaoPaciente", b =>
                {
                    b.HasOne("Unifisio_Api.Models.Fisioterapeuta", "Fisioterapeuta")
                        .WithMany()
                        .HasForeignKey("FisioterapeutaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unifisio_Api.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fisioterapeuta");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Unifisio_Api.Models.Fisioterapeuta", b =>
                {
                    b.HasOne("Unifisio_Api.Models.Paciente", "Paciente")
                        .WithMany("Fisioterapeutas")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Unifisio_Api.Models.HistoricoClinico", b =>
                {
                    b.HasOne("Unifisio_Api.Models.Paciente", "Paciente")
                        .WithMany("HistoricosClinicos")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Unifisio_Api.Models.PlanoTratamento", b =>
                {
                    b.HasOne("Unifisio_Api.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Unifisio_Api.Models.Paciente", b =>
                {
                    b.Navigation("Fisioterapeutas");

                    b.Navigation("HistoricosClinicos");
                });
#pragma warning restore 612, 618
        }
    }
}
