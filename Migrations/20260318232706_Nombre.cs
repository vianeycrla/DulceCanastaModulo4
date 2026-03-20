using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DulceCanastaModulo4.Migrations
{
    /// <inheritdoc />
    public partial class Nombre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ApellidoMaterno",
                table: "Usuarios",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApellidoPaterno",
                table: "Usuarios",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoPostal",
                table: "Usuarios",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Usuarios",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Usuarios",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Referencias",
                table: "Usuarios",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                columns: new[] { "ApellidoMaterno", "ApellidoPaterno", "Ciudad", "CodigoPostal", "Direccion", "FechaNacimiento", "FechaRegistro", "FotoUrl", "Referencias" },
                values: new object[] { "Sistema", "General", "Ciudad de México", "01000", "Sucursal Central", new DateTime(1995, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/admin.jpg", "Acceso interno de administración" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Activo", "ApellidoMaterno", "ApellidoPaterno", "Ciudad", "CodigoPostal", "Direccion", "Email", "FechaNacimiento", "FechaRegistro", "FotoUrl", "Nombre", "PasswordHash", "Referencias", "Rol", "Telefono" },
                values: new object[] { 2, true, "Correa", "Alcantar", "Ecatepec", "55000", "Calle Primavera 123", "cliente@dulcecanasta.com", new DateTime(2001, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/cliente-demo.jpg", "Vianey", "1234", "Casa color beige, portón negro", "Cliente", "5598765432" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ApellidoMaterno",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ApellidoPaterno",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CodigoPostal",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Referencias",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
