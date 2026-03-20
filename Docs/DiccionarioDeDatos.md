# Diccionario de datos / lista de clases

## 1. Categoria
Representa la clasificación de los productos.
- CategoriaId: identificador único.
- Nombre: nombre de la categoría.
- Descripcion: detalle descriptivo.
- Activo: indica si la categoría está habilitada.
- Productos: colección de productos relacionados.

## 2. Producto
Representa cada fruta o producto que vende la frutería.
- ProductoId: identificador único.
- Nombre: nombre comercial.
- Descripcion: detalle del producto.
- Precio: costo de venta.
- Stock: existencias disponibles.
- TipoVenta: pieza, kilo o caja.
- Activo: indica disponibilidad lógica.
- FechaRegistro: fecha de alta.
- ImagenUrl: ruta de la imagen.
- CategoriaId: llave foránea.
- Categoria: navegación a la categoría.

## 3. Usuario
Representa a las personas que pueden acceder al sistema.
- UsuarioId: identificador único.
- Nombre: nombre del usuario.
- Email: correo electrónico.
- PasswordHash: contraseña almacenada.
- Telefono: teléfono de contacto.
- FechaRegistro: fecha de alta.
- Activo: indica si el usuario sigue habilitado.
- Rol: Admin o Cliente.
- Pedidos: pedidos asociados.

## 4. Pedido
Representa una compra generada por el cliente.
- PedidoId: identificador único.
- UsuarioId: referencia opcional al usuario.
- FechaPedido: fecha y hora de creación.
- Estatus: Pendiente, Preparando o Entregado.
- Total: total monetario del pedido.
- NombreCliente: nombre capturado en checkout.
- Telefono: contacto del pedido.
- DireccionEntrega: domicilio o referencia.
- Notas: comentarios del cliente.
- Detalles: renglones del pedido.

## 5. PedidoDetalle
Representa cada producto dentro de un pedido.
- PedidoDetalleId: identificador único.
- PedidoId: pedido al que pertenece.
- ProductoId: producto relacionado.
- Cantidad: número de unidades o kilos.
- PrecioUnitario: precio al momento de la compra.
- Subtotal: importe parcial.

## 6. LoginViewModel
Modelo de apoyo para autenticar al administrador.
- Email: correo capturado.
- Password: contraseña capturada.

## 7. SessionCartItemViewModel
Modelo temporal para los productos guardados en sesión.
- ProductoId
- Nombre
- Precio
- Cantidad
- ImagenUrl
- Subtotal

## 8. CarritoViewModel
Modelo para pintar la vista del carrito.
- Items: lista de productos temporales.
- Total: suma total.

## 9. CheckoutViewModel
Modelo de captura del formulario final.
- NombreCliente
- Telefono
- DireccionEntrega
- Notas
- Items
- Total
