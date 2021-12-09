using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProyect.Migrations
{
    public partial class AgregandoClientealdetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 12, 7, 11, 35, 14, 546, DateTimeKind.Local).AddTicks(6098));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 12, 7, 10, 57, 11, 253, DateTimeKind.Local).AddTicks(3583));
        }
    }
}
