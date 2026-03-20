using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DulceCanastaModulo4.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    TipoVenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    FechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DireccionEntrega = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "PedidoDetalles",
                columns: table => new
                {
                    PedidoDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDetalles", x => x.PedidoDetalleId);
                    table.ForeignKey(
                        name: "FK_PedidoDetalles_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoDetalles_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Activo", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Fruta fresca para canasta", "Frutas dulces" },
                    { 2, true, "Frutas ricas en vitamina C", "Cítricos" },
                    { 3, true, "Frutas por temporada", "Temporada" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Activo", "Email", "FechaRegistro", "Nombre", "PasswordHash", "Rol", "Telefono" },
                values: new object[] { 1, true, "admin@dulcecanasta.com", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrador", "1234", "Admin", "5512345678" });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Activo", "CategoriaId", "Descripcion", "FechaRegistro", "ImagenUrl", "Nombre", "Precio", "Stock", "TipoVenta" },
                values: new object[,]
                {
                    { 1, true, 1, "Fresa fresca seleccionada", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/fresa.jpg", "Fresa", 65m, 30, "Caja" },
                    { 2, true, 2, "Naranja jugosa", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/naranja.jpg", "Naranja", 28m, 50, "Kilo" },
                    { 3, true, 1, "Manzana roja premium", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/manzana.jpg", "Manzana", 42m, 40, "Kilo" },
                    { 4, true, 3, "Mango dulce de temporada", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/mango.jpg", "Mango", 35m, 25, "Pieza" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalles_PedidoId",
                table: "PedidoDetalles",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalles_ProductoId",
                table: "PedidoDetalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoDetalles");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
