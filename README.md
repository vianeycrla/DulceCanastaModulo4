# Dulce Canasta 🍓

## Descripción del proyecto
**Dulce Canasta** es una aplicación web desarrollada con **ASP.NET Core MVC** para una tienda local de frutas.  
El sistema permite trasladar un proceso de compra tradicional al entorno digital, facilitando que los clientes puedan realizar pedidos de forma sencilla, intuitiva y cercana.

La propuesta está pensada para un pequeño negocio local que desea modernizar su forma de venta sin perder su esencia de atención práctica, directa y accesible para la comunidad.

## Objetivo
El objetivo principal del proyecto es ofrecer una solución web que permita a los clientes consultar un catálogo de frutas, registrarse, iniciar sesión, agregar productos a una canasta y generar pedidos, ya sea para:

- **Entrega a domicilio**
- **Recoger en tienda**

## Enfoque del sistema
Este proyecto no solo busca cumplir con la estructura técnica del patrón **Modelo Vista Controlador (MVC)**, sino también representar la lógica básica de un negocio local real, donde la compra debe ser:

- fácil
- intuitiva
- visualmente agradable
- cercana al usuario

## Funcionalidades implementadas

### Cliente
- Registro de usuario
- Inicio de sesión
- Cierre de sesión
- Perfil de usuario
- Consulta del catálogo
- Filtro de productos por categoría
- Agregar productos a la canasta
- Confirmación de pedido
- Selección de tipo de entrega:
  - Recoger en tienda
  - Entrega a domicilio

### Administrador
- Inicio de sesión
- Consulta de productos
- Alta de productos
- Edición de productos
- Eliminación de productos
- Consulta de pedidos

## Tecnologías utilizadas
- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- Razor Views
- HTML
- CSS
- Git y GitHub

## Arquitectura
El proyecto fue desarrollado bajo el patrón **MVC**:

- **Models**: representan las entidades principales como Usuario, Producto, Categoria, Pedido y PedidoDetalle.
- **Views**: contienen las pantallas del sistema para cliente y administrador.
- **Controllers**: manejan la lógica del flujo, autenticación, catálogo, carrito, pedidos y administración.

También se emplearon:
- **ViewModels** para formularios específicos como login y checkout
- **DbContext** para la persistencia con base de datos
- **Migraciones** con Entity Framework Core

## Flujo principal
1. El usuario se registra o inicia sesión
2. Consulta el catálogo de frutas
3. Agrega productos a la canasta
4. Confirma su pedido
5. Selecciona el tipo de entrega
6. Se genera el pedido en el sistema

## Identidad visual
La interfaz fue diseñada con una estética más **hogareña, cálida y de campo**, buscando transmitir cercanía y confianza, en lugar de una apariencia fría o demasiado técnica.

## Estado actual del proyecto
Actualmente el sistema ya cuenta con:
- Login
- Registro
- Carrito
- Pedidos
- Administración de productos

Aún se pueden seguir puliendo algunas vistas y mejorar visualmente ciertas partes del catálogo.

## Mejoras futuras
- Pulir más vistas del sistema
- Mejorar la presentación del catálogo
- Reforzar algunas validaciones
- Ampliar funcionalidades del flujo de pedido

## Repositorio
[Repositorio en GitHub](https://github.com/vianeycrla/DulceCanastaModulo4)

## Autora
**Vianey Alcantar Correa**
