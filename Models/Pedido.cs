using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DulceCanastaModulo4.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }

        public int? UsuarioId { get; set; }

        public DateTime FechaPedido { get; set; } = DateTime.Now;

        [Required]
        [StringLength(30)]
        public string Estatus { get; set; } = "Pendiente";

        [Required]
        public decimal Total { get; set; }

        [Required]
        [StringLength(80)]
        public string NombreCliente { get; set; } = string.Empty;

        [Required]
        [StringLength(80)]
        public string ApellidoPaternoCliente { get; set; } = string.Empty;

        [StringLength(80)]
        public string? ApellidoMaternoCliente { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? FechaNacimientoCliente { get; set; }

        [Required]
        [StringLength(30)]
        public string TipoEntrega { get; set; } = "RecogerEnTienda";

        [StringLength(200)]
        public string? DireccionEntrega { get; set; }

        [StringLength(250)]
        public string? Notas { get; set; }

        public Usuario? Usuario { get; set; }
        public ICollection<PedidoDetalle>? Detalles { get; set; }
    }
}