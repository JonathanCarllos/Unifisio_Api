using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unifisio_Api.Migrations
{
    /// <inheritdoc />
    public partial class AgendamentoConsultaCriada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgendamentoConsultas",
                columns: table => new
                {
                    AgendamentoConsultaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    FisioterapeutaId = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Observacoes = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentoConsultas", x => x.AgendamentoConsultaId);
                    table.ForeignKey(
                        name: "FK_AgendamentoConsultas_Fisioterapeutas_FisioterapeutaId",
                        column: x => x.FisioterapeutaId,
                        principalTable: "Fisioterapeutas",
                        principalColumn: "FisioterapeutaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentoConsultas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RelatorioProdutividades_FisioterapeutaId",
                table: "RelatorioProdutividades",
                column: "FisioterapeutaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaProcedimentos_FisioterapeutaId",
                table: "ConsultaProcedimentos",
                column: "FisioterapeutaId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoConsultas_FisioterapeutaId",
                table: "AgendamentoConsultas",
                column: "FisioterapeutaId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoConsultas_PacienteId",
                table: "AgendamentoConsultas",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaProcedimentos_Fisioterapeutas_FisioterapeutaId",
                table: "ConsultaProcedimentos",
                column: "FisioterapeutaId",
                principalTable: "Fisioterapeutas",
                principalColumn: "FisioterapeutaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelatorioProdutividades_Fisioterapeutas_FisioterapeutaId",
                table: "RelatorioProdutividades",
                column: "FisioterapeutaId",
                principalTable: "Fisioterapeutas",
                principalColumn: "FisioterapeutaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaProcedimentos_Fisioterapeutas_FisioterapeutaId",
                table: "ConsultaProcedimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_RelatorioProdutividades_Fisioterapeutas_FisioterapeutaId",
                table: "RelatorioProdutividades");

            migrationBuilder.DropTable(
                name: "AgendamentoConsultas");

            migrationBuilder.DropIndex(
                name: "IX_RelatorioProdutividades_FisioterapeutaId",
                table: "RelatorioProdutividades");

            migrationBuilder.DropIndex(
                name: "IX_ConsultaProcedimentos_FisioterapeutaId",
                table: "ConsultaProcedimentos");
        }
    }
}
