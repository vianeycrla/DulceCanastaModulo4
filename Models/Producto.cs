using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DulceCanastaModulo4.Models;

public class Producto
{
    public int ProductoId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(80)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(250)]
    public string? Descripcion { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    [Range(0.01, 99999, ErrorMessage = "Capture un precio válido")]
    public decimal Precio { get; set; }

    [Range(0, 9999)]
    public int Stock { get; set; }

    [Display(Name = "Tipo de venta")]
    public string TipoVenta { get; set; } = "Pieza";

    public bool Activo { get; set; } = true;

    [Display(Name = "Fecha de registro")]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    [Display(Name = "Imagen")]
    [StringLength(150)]
    public string? ImagenUrl { get; set; }

    [Display(Name = "Categoría")]
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }

    public List<PedidoDetalle> PedidoDetalles { get; set; } = new();
}
