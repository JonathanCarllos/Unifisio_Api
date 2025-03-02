using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unifisio_Api.Migrations
{
    /// <inheritdoc />
    public partial class CriadoRelatorioProdutividade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RelatorioProdutividades",
                columns: table => new
                {
                    RelatorioProdutividadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FisioterapeutaId = table.Column<int>(type: "int", nullable: false),
                    NomeFisioterapeuta = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalConsultas = table.Column<int>(type: "int", nullable: false),
                    PeriodoInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PeriodoFim = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatorioProdutividades", x => x.RelatorioProdutividadeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelatorioProdutividades");
        }
    }
}
