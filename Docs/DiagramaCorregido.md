# Ajustes recomendados al diagrama de clases / entidad relación

## Qué corregir del diagrama que me compartiste
1. **Categoria no debe relacionarse con Usuario.**
   La relación correcta es:
   - `Categoria 1 --- N Producto`

2. Para este avance del módulo 4 conviene **simplificar la persistencia**:
   - mantener en base de datos: `Categoria`, `Producto`, `Usuario`, `Pedido`, `PedidoDetalle`
   - manejar `Carrito` en **Session**
   - dejar `Pago` como fase futura

3. La relación correcta del núcleo de ventas queda así:
   - `Usuario 1 --- N Pedido`
   - `Pedido 1 --- N PedidoDetalle`
   - `Producto 1 --- N PedidoDetalle`
   - `Categoria 1 --- N Producto`

## Versión actual recomendada para entregar
```text
Categoria (1) -------- (N) Producto
Usuario   (1) -------- (N) Pedido
Pedido    (1) -------- (N) PedidoDetalle
Producto  (1) -------- (N) PedidoDetalle
```

## Versión futura del proyecto completo
Cuando avances a módulos posteriores o a la entrega final completa, puedes reincorporar:
- Carrito
- CarritoItem
- Pago
- API
- App móvil
- Despliegue en nube
