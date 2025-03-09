using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unifisio_Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateRegistroDePresenca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistroPresencas",
                columns: table => new
                {
                    RegistroPresencaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    FisioterapeutaId = table.Column<int>(type: "int", nullable: false),
                    DataAtendimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Compareceu = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Observacoes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroPresencas", x => x.RegistroPresencaId);
                    table.ForeignKey(
                        name: "FK_RegistroPresencas_Fisioterapeutas_FisioterapeutaId",
                        column: x => x.FisioterapeutaId,
                        principalTable: "Fisioterapeutas",
                        principalColumn: "FisioterapeutaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroPresencas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPresencas_FisioterapeutaId",
                table: "RegistroPresencas",
                column: "FisioterapeutaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPresencas_PacienteId",
                table: "RegistroPresencas",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroPresencas");
        }
    }
}
