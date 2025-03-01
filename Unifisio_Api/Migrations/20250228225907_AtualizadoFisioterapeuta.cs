﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unifisio_Api.Migrations
{
    /// <inheritdoc />
    public partial class AtualizadoFisioterapeuta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Especialidade",
                table: "Fisioterapeutas",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Especialidade",
                table: "Fisioterapeutas");
        }
    }
}
