using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DulceCanastaModulo4.Migrations
{
    /// <inheritdoc />
    public partial class AjustarPedidoEntrega : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Pedidos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<string>(
                name: "NombreCliente",
                table: "Pedidos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "DireccionEntrega",
                table: "Pedidos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "ApellidoMaternoCliente",
                table: "Pedidos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApellidoPaternoCliente",
                table: "Pedidos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimientoCliente",
                table: "Pedidos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoEntrega",
                table: "Pedidos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApellidoMaternoCliente",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ApellidoPaternoCliente",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "FechaNacimientoCliente",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "TipoEntrega",
                table: "Pedidos");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Pedidos",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "NombreCliente",
                table: "Pedidos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "DireccionEntrega",
                table: "Pedidos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
