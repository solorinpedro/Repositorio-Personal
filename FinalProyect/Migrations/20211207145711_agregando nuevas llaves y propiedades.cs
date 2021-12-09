using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProyect.Migrations
{
    public partial class agregandonuevasllavesypropiedades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Devolucion",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Efectivo",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Condominios");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "Condominios",
                newName: "Costo");

            migrationBuilder.AddColumn<int>(
                name: "TipoCondominiosId",
                table: "Condominios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CondominioId",
                table: "Clientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CondominiosCondominioId",
                table: "Clientes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Recibos",
                columns: table => new
                {
                    ReciboId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CondominioId = table.Column<int>(type: "INTEGER", nullable: false),
                    CondominiosCondominioId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientesClienteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibos", x => x.ReciboId);
                    table.ForeignKey(
                        name: "FK_Recibos_Clientes_ClientesClienteId",
                        column: x => x.ClientesClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recibos_Condominios_CondominiosCondominioId",
                        column: x => x.CondominiosCondominioId,
                        principalTable: "Condominios",
                        principalColumn: "CondominioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoCondominios",
                columns: table => new
                {
                    TipoCondominioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCondominios", x => x.TipoCondominioId);
                });

            migrationBuilder.InsertData(
                table: "TipoCondominios",
                columns: new[] { "TipoCondominioId", "Tipo" },
                values: new object[] { 1, "Apartamento" });

            migrationBuilder.InsertData(
                table: "TipoCondominios",
                columns: new[] { "TipoCondominioId", "Tipo" },
                values: new object[] { 2, "Parqueo" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 12, 7, 10, 57, 11, 253, DateTimeKind.Local).AddTicks(3583));

            migrationBuilder.CreateIndex(
                name: "IX_Condominios_TipoCondominiosId",
                table: "Condominios",
                column: "TipoCondominiosId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CondominiosCondominioId",
                table: "Clientes",
                column: "CondominiosCondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_ClientesClienteId",
                table: "Recibos",
                column: "ClientesClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_CondominiosCondominioId",
                table: "Recibos",
                column: "CondominiosCondominioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Condominios_CondominiosCondominioId",
                table: "Clientes",
                column: "CondominiosCondominioId",
                principalTable: "Condominios",
                principalColumn: "CondominioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Condominios_TipoCondominios_TipoCondominiosId",
                table: "Condominios",
                column: "TipoCondominiosId",
                principalTable: "TipoCondominios",
                principalColumn: "TipoCondominioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Condominios_CondominiosCondominioId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Condominios_TipoCondominios_TipoCondominiosId",
                table: "Condominios");

            migrationBuilder.DropTable(
                name: "Recibos");

            migrationBuilder.DropTable(
                name: "TipoCondominios");

            migrationBuilder.DropIndex(
                name: "IX_Condominios_TipoCondominiosId",
                table: "Condominios");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_CondominiosCondominioId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TipoCondominiosId",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "CondominioId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CondominiosCondominioId",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Costo",
                table: "Condominios",
                newName: "Precio");

            migrationBuilder.AddColumn<float>(
                name: "Devolucion",
                table: "Condominios",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Efectivo",
                table: "Condominios",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Condominios",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 11, 27, 14, 16, 33, 975, DateTimeKind.Local).AddTicks(4317));
        }
    }
}
