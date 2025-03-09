using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unifisio_Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateFisioterapeutaDisponibilidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FisioterapeutaDisponibilidades",
                columns: table => new
                {
                    FisioterapeutaDisponibilidadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FisioterapeutaId = table.Column<int>(type: "int", nullable: false),
                    DiaSemana = table.Column<int>(type: "int", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    HoraFim = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FisioterapeutaDisponibilidades", x => x.FisioterapeutaDisponibilidadeId);
                    table.ForeignKey(
                        name: "FK_FisioterapeutaDisponibilidades_Fisioterapeutas_Fisioterapeut~",
                        column: x => x.FisioterapeutaId,
                        principalTable: "Fisioterapeutas",
                        principalColumn: "FisioterapeutaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FisioterapeutaDisponibilidades_FisioterapeutaId",
                table: "FisioterapeutaDisponibilidades",
                column: "FisioterapeutaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FisioterapeutaDisponibilidades");
        }
    }
}
