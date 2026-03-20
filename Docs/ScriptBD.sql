CREATE DATABASE DulceCanastaModulo4DB;
GO
USE DulceCanastaModulo4DB;
GO

CREATE TABLE Categoria (
    CategoriaId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(60) NOT NULL,
    Descripcion NVARCHAR(200) NULL,
    Activo BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE Usuario (
    UsuarioId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(120) NOT NULL,
    PasswordHash NVARCHAR(200) NOT NULL,
    Telefono NVARCHAR(20) NULL,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    Activo BIT NOT NULL DEFAULT 1,
    Rol NVARCHAR(20) NOT NULL DEFAULT 'Cliente'
);
GO

CREATE TABLE Producto (
    ProductoId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(80) NOT NULL,
    Descripcion NVARCHAR(250) NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    TipoVenta NVARCHAR(20) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    ImagenUrl NVARCHAR(150) NULL,
    CategoriaId INT NOT NULL,
    CONSTRAINT FK_Producto_Categoria FOREIGN KEY (CategoriaId) REFERENCES Categoria(CategoriaId)
);
GO

CREATE TABLE Pedido (
    PedidoId INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT NULL,
    FechaPedido DATETIME NOT NULL DEFAULT GETDATE(),
    Estatus NVARCHAR(30) NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    NombreCliente NVARCHAR(150) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL,
    DireccionEntrega NVARCHAR(200) NOT NULL,
    Notas NVARCHAR(250) NULL,
    CONSTRAINT FK_Pedido_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuario(UsuarioId)
);
GO

CREATE TABLE PedidoDetalle (
    PedidoDetalleId INT IDENTITY(1,1) PRIMARY KEY,
    PedidoId INT NOT NULL,
    ProductoId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_PedidoDetalle_Pedido FOREIGN KEY (PedidoId) REFERENCES Pedido(PedidoId),
    CONSTRAINT FK_PedidoDetalle_Producto FOREIGN KEY (ProductoId) REFERENCES Producto(ProductoId)
);
GO

INSERT INTO Categoria (Nombre, Descripcion, Activo) VALUES
('Frutas dulces', 'Fruta fresca para canasta', 1),
('Cítricos', 'Frutas ricas en vitamina C', 1),
('Temporada', 'Frutas por temporada', 1);
GO

INSERT INTO Usuario (Nombre, Email, PasswordHash, Telefono, FechaRegistro, Activo, Rol) VALUES
('Administrador', 'admin@dulcecanasta.com', '1234', '5512345678', GETDATE(), 1, 'Admin');
GO

INSERT INTO Producto (Nombre, Descripcion, Precio, Stock, TipoVenta, Activo, FechaRegistro, ImagenUrl, CategoriaId) VALUES
('Fresa', 'Fresa fresca seleccionada', 65.00, 30, 'Caja', 1, GETDATE(), '/images/fresa.jpg', 1),
('Naranja', 'Naranja jugosa', 28.00, 50, 'Kilo', 1, GETDATE(), '/images/naranja.jpg', 2),
('Manzana', 'Manzana roja premium', 42.00, 40, 'Kilo', 1, GETDATE(), '/images/manzana.jpg', 1),
('Mango', 'Mango dulce de temporada', 35.00, 25, 'Pieza', 1, GETDATE(), '/images/mango.jpg', 3);
GO
