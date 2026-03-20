using System.ComponentModel.DataAnnotations.Schema;

namespace DulceCanastaModulo4.Models;

public class PedidoDetalle
{
    public int PedidoDetalleId { get; set; }

    public int PedidoId { get; set; }
    public Pedido? Pedido { get; set; }

    public int ProductoId { get; set; }
    public Producto? Producto { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecioUnitario { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Subtotal { get; set; }
}
