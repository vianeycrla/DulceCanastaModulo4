using System.ComponentModel.DataAnnotations;

namespace DulceCanastaModulo4.Models;

public class Categoria
{
    public int CategoriaId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(60)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(200)]
    public string? Descripcion { get; set; }

    public bool Activo { get; set; } = true;

    public List<Producto> Productos { get; set; } = new();
}
