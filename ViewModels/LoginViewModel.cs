using System.ComponentModel.DataAnnotations;

namespace DulceCanastaModulo4.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}
