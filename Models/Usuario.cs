using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DulceCanastaModulo4.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(60)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido paterno es obligatorio.")]
        [StringLength(60)]
        [Display(Name = "Apellido paterno")]
        public string ApellidoPaterno { get; set; } = string.Empty;

        [StringLength(60)]
        [Display(Name = "Apellido materno")]
        public string? ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Ingresa un correo válido.")]
        [StringLength(120)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(200)]
        [Display(Name = "Contraseña")]
        public string PasswordHash { get; set; } = string.Empty;

        [StringLength(20)]
        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [StringLength(200)]
        [Display(Name = "Dirección")]
        public string? Direccion { get; set; }

        [StringLength(100)]
        [Display(Name = "Ciudad o municipio")]
        public string? Ciudad { get; set; }

        [StringLength(10)]
        [Display(Name = "Código postal")]
        public string? CodigoPostal { get; set; }

        [StringLength(200)]
        [Display(Name = "Referencias")]
        public string? Referencias { get; set; }

        [StringLength(150)]
        [Display(Name = "Foto de perfil")]
        public string? FotoUrl { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public bool Activo { get; set; } = true;

        [Required]
        [StringLength(20)]
        public string Rol { get; set; } = "Cliente";

        [NotMapped]
        public string NombreCompleto =>
            $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}".Replace("  ", " ").Trim();
    }
}