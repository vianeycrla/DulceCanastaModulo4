using DulceCanastaModulo4.Models;
using Microsoft.EntityFrameworkCore;

namespace DulceCanastaModulo4.Data
{
    public class DulceCanastaContext : DbContext
    {
        public DulceCanastaContext(DbContextOptions<DulceCanastaContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<PedidoDetalle> PedidoDetalles => Set<PedidoDetalle>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria
                {
                    CategoriaId = 1,
                    Nombre = "Frutas dulces",
                    Descripcion = "Fruta fresca para canasta",
                    Activo = true
                },
                new Categoria
                {
                    CategoriaId = 2,
                    Nombre = "Cítricos",
                    Descripcion = "Frutas ricas en vitamina C",
                    Activo = true
                },
                new Categoria
                {
                    CategoriaId = 3,
                    Nombre = "Temporada",
                    Descripcion = "Frutas por temporada",
                    Activo = true
                }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    UsuarioId = 1,
                    Nombre = "Administrador",
                    ApellidoPaterno = "General",
                    ApellidoMaterno = "Sistema",
                    Email = "admin@dulcecanasta.com",
                    PasswordHash = "1234",
                    Telefono = "5512345678",
                    FechaNacimiento = new DateTime(1995, 5, 20),
                    Direccion = "Sucursal Central",
                    Ciudad = "Ciudad de México",
                    CodigoPostal = "01000",
                    Referencias = "Acceso interno de administración",
                    FotoUrl = "/images/admin.jpg",
                    FechaRegistro = new DateTime(2026, 3, 18),
                    Activo = true,
                    Rol = "Admin"
                },
                new Usuario
                {
                    UsuarioId = 2,
                    Nombre = "Vianey",
                    ApellidoPaterno = "Alcantar",
                    ApellidoMaterno = "Correa",
                    Email = "cliente@dulcecanasta.com",
                    PasswordHash = "1234",
                    Telefono = "5598765432",
                    FechaNacimiento = new DateTime(2001, 8, 14),
                    Direccion = "Calle Primavera 123",
                    Ciudad = "Ecatepec",
                    CodigoPostal = "55000",
                    Referencias = "Casa color beige, portón negro",
                    FotoUrl = "/images/cliente-demo.jpg",
                    FechaRegistro = new DateTime(2026, 3, 18),
                    Activo = true,
                    Rol = "Cliente"
                }
            );

            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    ProductoId = 1,
                    Nombre = "Fresa",
                    Descripcion = "Fresa fresca seleccionada",
                    Precio = 65m,
                    Stock = 30,
                    TipoVenta = "Caja",
                    Activo = true,
                    FechaRegistro = new DateTime(2026, 3, 1),
                    ImagenUrl = "/images/fresa.jpg",
                    CategoriaId = 1
                },
                new Producto
                {
                    ProductoId = 2,
                    Nombre = "Naranja",
                    Descripcion = "Naranja jugosa",
                    Precio = 28m,
                    Stock = 50,
                    TipoVenta = "Kilo",
                    Activo = true,
                    FechaRegistro = new DateTime(2026, 3, 1),
                    ImagenUrl = "/images/naranja.jpg",
                    CategoriaId = 2
                },
                new Producto
                {
                    ProductoId = 3,
                    Nombre = "Manzana",
                    Descripcion = "Manzana roja premium",
                    Precio = 42m,
                    Stock = 40,
                    TipoVenta = "Kilo",
                    Activo = true,
                    FechaRegistro = new DateTime(2026, 3, 1),
                    ImagenUrl = "/images/manzana.jpg",
                    CategoriaId = 1
                },
                new Producto
                {
                    ProductoId = 4,
                    Nombre = "Mango",
                    Descripcion = "Mango dulce de temporada",
                    Precio = 35m,
                    Stock = 25,
                    TipoVenta = "Pieza",
                    Activo = true,
                    FechaRegistro = new DateTime(2026, 3, 1),
                    ImagenUrl = "/images/mango.jpg",
                    CategoriaId = 3
                }
            );
        }
    }
}