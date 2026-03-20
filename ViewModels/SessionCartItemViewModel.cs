using System;

namespace DulceCanastaModulo4.ViewModels
{
    public class SessionCartItemViewModel
    {
        public int ProductoId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? ImagenUrl { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal { get; set; }
    }
}