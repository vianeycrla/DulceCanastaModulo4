using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DulceCanastaModulo4.ViewModels
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string NombreCliente { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido paterno es obligatorio.")]
        public string ApellidoPaternoCliente { get; set; } = string.Empty;

        public string? ApellidoMaternoCliente { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string Telefono { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? FechaNacimientoCliente { get; set; }

        [Required(ErrorMessage = "Selecciona el tipo de entrega.")]
        public string TipoEntrega { get; set; } = "RecogerEnTienda";

        public string? DireccionEntrega { get; set; }

        public string? Notas { get; set; }

        public decimal Total { get; set; }

        public List<SessionCartItemViewModel> Items { get; set; } = new();
    }
}