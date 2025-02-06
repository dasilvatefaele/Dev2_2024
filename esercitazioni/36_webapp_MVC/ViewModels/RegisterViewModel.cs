using System.ComponentModel.DataAnnotations;

namespace _36_webapp_MVC.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "L'email è obbligatoria.")]
    [EmailAddress(ErrorMessage = "Inserisci un'email valida.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "La password è obbligatoria.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Le password non coincidono.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Devi selezionare un ruolo.")]
    public string Role { get; set; }
}